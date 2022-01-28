using AppModel.Storage;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Adapters
{
    /* Adapter for MapEvent model object */
    public class MapEventAdapter
    {
        /* Convert container of AppModel.Event.MapEvent to list of DataLayer.Models.MapEvent */
        public List<DataLayer.Models.MapEvent> FromAppModel(IEnumerable<ReferencedItem<Guid, AppModel.Event.MapEvent>> items)
        {
            var returnList = new List<DataLayer.Models.MapEvent>();
            foreach (var item in items)
            {
                returnList.Add(new DataLayer.Models.MapEvent(item));
            }
            return returnList;
        }
        /* Convert DataLayer.Models.MapEvent to AppModel.Event.MapEvent */
        public ReferencedItem<Guid, AppModel.Event.MapEvent> ToAppModel(DataLayer.Models.MapEvent mapEvent)
        {
            var @event = new AppModel.Event.MapEvent(mapEvent.PinOnMapCode, mapEvent.PinRay, mapEvent.PositionX, mapEvent.PositionY);
            @event.MainInfo = new AppModel.Event.RestrictedEvent(mapEvent.Title, mapEvent.Description, mapEvent.Address, mapEvent.StartDate, null);
            return new ReferencedItem<Guid, AppModel.Event.MapEvent>(new Guid(mapEvent.Id), @event);
        }
    }
}
