using Android.App;
using Android.Content.PM;
using Android.OS;
using Android;
using Com.Mapbox.Mapboxsdk.Maps;
using Com.Mapbox.Mapboxsdk;
using Xamarin.Facebook;
using System;
using Android.Content;
using Java.Security;
using static Android.Content.PM.PackageManager;
using Android.Util;

namespace ToogetherApp.Droid
{
    [Activity(Label = "ToogetherApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, Name = "com.sylex.toogetherapp.MainActivity", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IOnMapReadyCallback, Style.IOnStyleLoaded
    {
        public static ICallbackManager CallbackManager; // Facebook callback manager
        public MapView MapView { get; set; } = null;
        public MapboxMap MapboxMap { get; set; } = null;
        public static MainActivity MainActivityInstance { get; private set; }
        const int RequestLocationId = 0;
        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            CallbackManager = CallbackManagerFactory.Create();
            base.OnCreate(savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            // set statut bar color
            Window.SetStatusBarColor(Android.Graphics.Color.Black);

            LoadApplication(new App());
            MainActivityInstance = this;
            
            Mapbox.GetInstance(this, "pk.eyJ1IjoiY2hhcmxlc2NvbCIsImEiOiJja3ZwdGNxaWI2d3pjMm5xcGNodWhwaTcxIn0.T4jpBeb638r9VOiu6tNxUg");
            MapView = new MapView(this);
            MapView.GetMapAsync(this);
            MapView.OnCreate(savedInstanceState);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            CallbackManager.OnActivityResult(requestCode, Convert.ToInt32(resultCode), intent);
        }
        protected override void OnStart()
        {
            base.OnStart();
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted
                }
            }
            MapView.OnStart();
        }
        protected override void OnResume()
        {
            base.OnResume();
            MapView.OnResume();
        }
        protected override void OnPause()
        {
            MapView.OnPause();
            base.OnPause();
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            MapView.OnSaveInstanceState(outState);
        }
        protected override void OnStop()
        {
            base.OnStop();
            MapView.OnStop();
        }
        protected override void OnDestroy()
        {
            MapView.OnDestroy();
            base.OnDestroy();
        }
        public override void OnLowMemory()
        {
            base.OnLowMemory();
            MapView.OnLowMemory();
        }
        public void OnMapReady(MapboxMap p0)
        {
            MapboxMap = p0;
            if (Renderer.MapViewRenderer.MapViewRendererInstance != null)
            {
                MapboxMap.AddOnMapClickListener(Renderer.MapViewRenderer.MapViewRendererInstance);
                Renderer.MapViewRenderer.MapViewRendererInstance.MapClickListenerAdded = true;
            }
            Renderer.MapViewRenderer.OnMapReady(p0);
        }
        public void OnStyleLoaded(Com.Mapbox.Mapboxsdk.Maps.Style p0)
        {
            Renderer.MapViewRenderer.OnStyleLoaded(p0);
        }
    }
}