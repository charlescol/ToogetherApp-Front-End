using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EventService
    {
        public EventService() { }
        public static async Task<List<AppModel.Storage.ReferencedItem<Guid, AppModel.Event.MapEvent>>> GetMapEvent()
        {
            return AppModel.Test.Eventgenerator.Generate(10);
        }
        public static async Task<bool> PublishEvent(AppModel.Storage.ReferencedItem<Guid, AppModel.Event.MapEvent> @event)
        {
            return true;
        }
    }
}
