using Android.Content;
using Android.Graphics;
using Com.Mapbox.Mapboxsdk;
using Com.Mapbox.Mapboxsdk.Camera;
using Com.Mapbox.Mapboxsdk.Geometry;
using System;
using ToogetherApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Com.Mapbox.Mapboxsdk.Maps;
using AndroidX.AppCompat.App;
using static Com.Mapbox.Mapboxsdk.Maps.Style;
using Com.Mapbox.Mapboxsdk.Style.Sources;
using Com.Mapbox.Mapboxsdk.Style.Layers;

[assembly: ExportRenderer(typeof(ToogetherApp.Views.Map), typeof(MapViewRenderer))]
namespace ToogetherApp.Droid.Renderer
{
    public class MapViewRenderer : ViewRenderer<ContentView, Android.Views.View>, MapboxMap.IOnMapClickListener
    {
        public static MapViewRenderer MapViewRendererInstance { get; private set; } = null;
        public bool MapClickListenerAdded { get; set; } = false;
        private static GeoJsonSource eventSource = null;

        public MapViewRenderer(Context context) : base(context)
        {
            MapViewRendererInstance = this;
        }
        /* Handle each click on the map*/
        public bool OnMapClick(LatLng p0)
        {
            PointF location = MainActivity.MainActivityInstance.MapboxMap.Projection.ToScreenLocation(p0);
            RectF rectF = new RectF(location.X - 10, location.Y - 10, location.X + 10, location.Y + 10);
            var featureList = MainActivity.MainActivityInstance.MapboxMap.QueryRenderedFeatures(rectF, "background-layer");
            foreach (Com.Mapbox.Geojson.Feature feature in featureList)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(feature.ToJson());
                Console.WriteLine("------------------------");
            }
            return true;
        }
        /* Call by the Main activity when the map is ready, build the style ans instanciate the camera*/
        public static void OnMapReady(MapboxMap mapbox)
        {
            mapbox.UiSettings.CompassEnabled = false; // disable compass
            mapbox.UiSettings.LogoEnabled = false; // disable logo
            mapbox.UiSettings.AttributionEnabled = false; // disable info button
            MainActivity.MainActivityInstance.MapboxMap.CameraPosition = new CameraPosition.Builder().Target(new LatLng(40.73581, -73.99155)).Zoom(11).Build();
            MainActivity.MainActivityInstance.MapboxMap.SetStyle(new Com.Mapbox.Mapboxsdk.Maps.Style.Builder().FromUri("mapbox://styles/charlescol/ckvq7hj0h484o15nyspor9ah8"), MainActivity.MainActivityInstance);
        }
        /* Call by the main activity when the style is ready, build images */
        public static void OnStyleLoaded(Com.Mapbox.Mapboxsdk.Maps.Style p0)
        {
            var image = BitmapFactory.DecodeResource(MainActivity.MainActivityInstance.Resources, Resource.Drawable.addLocation_icon);
            p0.AddImage("background_pin", Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(MainActivity.MainActivityInstance.Resources, Resource.Drawable.background_marker), 100, 120, false));
            p0.AddImage("test_emoji_icon", Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(MainActivity.MainActivityInstance.Resources, Resource.Drawable.test_emoji_pin), 89, 89, false));
        }
        /* Build entities on the map with the json string input value. Create a layer for each part of the custom markers*/
        public void FromJson(string json_content)
        {
            /* Uses static MainActivity instance pointer the access to the the asset file*/
            /*Android.Content.Res.AssetManager assets = MainActivity.MainActivityInstance.Assets;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(assets.Open("entities.json")))
            {
                json_content = reader.ReadToEnd();
            }*/
            if (MainActivity.MainActivityInstance.MapboxMap.Style == null) return;

            var features = Com.Mapbox.Geojson.FeatureCollection.FromJson(json_content);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (eventSource == null) // If source needs to be created
                {

                    eventSource = new GeoJsonSource("events", features);

                    MainActivity.MainActivityInstance.MapboxMap.Style.AddSource(eventSource);

                    var background_image_property = new PropertyValue("icon-image", "background_pin");
                    var icon_image_property = new PropertyValue("icon-image", "test_emoji_icon");
                    var true_icon_overlap_property = new PropertyValue("icon-allow-overlap", true);
                    var background_color = new PropertyValue("icon-color", "red");
                    var icon_anchor_property = new PropertyValue("icon-anchor", "bottom");
                    var _icon_offset = new PropertyValue("icon-offset", new Java.Lang.Float[2] { new Java.Lang.Float(0), new Java.Lang.Float(-13) });

                    var layer_background = new SymbolLayer("background-layer", "events")
                        .WithProperties(background_image_property, true_icon_overlap_property, icon_anchor_property);

                    var layer_icon = new SymbolLayer("icon-layer", "events").
                        WithProperties(icon_image_property, _icon_offset, icon_anchor_property, true_icon_overlap_property);

                    MainActivity.MainActivityInstance.MapboxMap.Style.AddLayer(layer_background);
                    MainActivity.MainActivityInstance.MapboxMap.Style.AddLayer(layer_icon);

                }
                else // If source needs to be updated
                {
                    eventSource.SetGeoJson(features);
                }
            });
        }
        /* Call when each time the map view is generated */
        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = e.NewElement as ToogetherApp.Views.Map;
                view.HandlerEntitiesModified += FromJson;

                if (Control == null)
                {
                    SetNativeControl(MainActivity.MainActivityInstance.MapView);
                    if (MainActivity.MainActivityInstance.MapboxMap != null && !MapClickListenerAdded)
                    {
                        MainActivity.MainActivityInstance.MapboxMap.AddOnMapClickListener(this);
                        MapClickListenerAdded = true;
                    }
                }
            }
            if (e.OldElement != null || Element == null)
            {
                var view = e.OldElement as ToogetherApp.Views.Map;
                view.HandlerEntitiesModified -= FromJson;
            }
        }
        /* Remove the map from the disposed view each time the view is hide*/
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MainActivity.MainActivityInstance.MapboxMap.RemoveOnMapClickListener(this);
                MainActivity.MainActivityInstance.MapView.RemoveFromParent();
            }
            base.Dispose(disposing);
        }

    }
}