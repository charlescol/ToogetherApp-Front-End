using AppModel.Storage;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Adapters
{
    /* Adapter for RestrictedEvent model object */
    public class RestrictedEventAdapter
    {

        /* Convert DataLayer.Models.RestrictedEvent to AppModel.Event.RestrictedEvent */
        public ReferencedItem<Guid, AppModel.Event.RestrictedEvent> ToAppModel(DataLayer.Models.RestrictedEvent @event)
        {
            var modelEvent = new AppModel.Event.RestrictedEvent(@event.Title, @event.Description, @event.Address, @event.StartDate, null);
            return new ReferencedItem<Guid, AppModel.Event.RestrictedEvent>(new Guid(@event.Id), modelEvent);
        }
        /* Convert container of AppModel.Event.RestrictedEvent to list of DataLayer.Models.RestrictedEvent */
        public List<DataLayer.Models.RestrictedEvent> FromMapEvent(IEnumerable<DataLayer.Models.MapEvent> mapEvents)
        {
            var returnList = new List<DataLayer.Models.RestrictedEvent>();
            foreach (var item in mapEvents)
            {
                returnList.Add(new DataLayer.Models.RestrictedEvent(new ReferencedItem<Guid, AppModel.Event.RestrictedEvent>(new Guid(item.Id),
                    new AppModel.Event.RestrictedEvent(item.Title, item.Description, item.Address, item.StartDate, null))));
            }
            return returnList;
        }
    }
}
