using System;
using System.Collections.Generic;
using AppModel.Storage;
using SQLite;

namespace DataLayer.Models
{
    /* Model used by the mobile app to store AppModel.Event.MapEvent */
    public class MapEvent : AbstractModel<string>
    {
        public int PinOnMapCode { get; set; } = 0;
        public double PinRay { get; set; } = 0;
        public double PositionX { get; set; } = 0;
        public double PositionY { get; set; } = 0;
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();
        public string OrganizerID { get; set; }
        public MapEvent() 
        {

        }
        public MapEvent(ReferencedItem<Guid, AppModel.Event.MapEvent> mapEvent)
        {
            Id = mapEvent._id.ToString();
            PinOnMapCode = mapEvent.Item.PinOnMapCode;
            PinRay = mapEvent.Item.PinRay;
            PositionX = mapEvent.Item.PositionX;
            PositionY = mapEvent.Item.PositionY;
            Title = mapEvent.Item.MainInfo.Address;
            Description = mapEvent.Item.MainInfo.Description;
            Type = nameof(mapEvent.Item.MainInfo.Type);
            Address = mapEvent.Item.MainInfo.Address;
            StartDate = mapEvent.Item.MainInfo.Date;
            EndDate = mapEvent.Item.MainInfo.Date;
            OrganizerID = mapEvent.Item.MainInfo.Organizer._id.ToString();
        }
    }
}
