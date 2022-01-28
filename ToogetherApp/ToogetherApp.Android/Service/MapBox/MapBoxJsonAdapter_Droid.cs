using AppModel.Event;
using AppModel.Storage;
using System;
using System.Collections.Generic;

[assembly: Xamarin.Forms.Dependency(typeof(ToogetherApp.Droid.Service.MapBox.MapBoxAdapter.MapBoxJsonAdapter_Droid))]
namespace ToogetherApp.Droid.Service.MapBox.MapBoxAdapter
{
    public class MapBoxJsonAdapter_Droid : BusinessLogicLayer.Adapters.IMapBoxJsonAdapter
    {
        public string ToJson(IEnumerable<DataLayer.Models.MapEvent> events)
        {
            List<Com.Mapbox.Geojson.Feature> features = new List<Com.Mapbox.Geojson.Feature>();
            foreach (var @event in events)
            {
                Console.WriteLine(nameof(@event.Id));
                var coordinate = Com.Mapbox.Geojson.Gson.GeometryGeoJson.FromJson("{\"type\": \"Point\",\"coordinates\": " +
                    "[" + @event.PositionX.ToString() + "," + @event.PositionY.ToString() + ", 0.0]}");
                var feature = Com.Mapbox.Geojson.Feature.FromGeometry(coordinate);
                feature.AddStringProperty(nameof(@event.Id), (@event.Id));
                feature.AddNumberProperty(nameof(@event.PinRay), (Java.Lang.Number)@event.PinRay);
                feature.AddStringProperty(nameof(@event.StartDate), @event.StartDate.ToString());
                feature.AddStringProperty(nameof(@event.EndDate), @event.EndDate.ToString());
                feature.AddStringProperty(nameof(@event.Type), @event.Type);
                feature.AddNumberProperty(nameof(@event.PinOnMapCode), (Java.Lang.Number)@event.PinOnMapCode);
                features.Add(feature);
            }
            return Com.Mapbox.Geojson.FeatureCollection.FromFeatures(features).ToJson();
        }
    }
}
