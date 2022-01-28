using System;
using System.Collections.Generic;

using MapEventRef = AppModel.Storage.ReferencedItem<System.Guid, AppModel.Event.MapEvent>;
namespace BusinessLogicLayer.Adapters
{
    public interface IMapBoxJsonAdapter
    {
        public string ToJson(IEnumerable<DataLayer.Models.MapEvent> events);
    }
}
