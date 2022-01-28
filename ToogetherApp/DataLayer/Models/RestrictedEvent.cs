using AppModel.Storage;
using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    /* Model used by the mobile app to store AppModel.Event.RestrictedEvent */
    public class RestrictedEvent : AbstractModel<string>
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();
        public string OrganizerID { get; set; } = "";
        public RestrictedEvent() { }
        public RestrictedEvent(ReferencedItem<Guid, AppModel.Event.RestrictedEvent> restrictedEvent)
        {
            Id = restrictedEvent._id.ToString();
            Title = restrictedEvent.Item.Address;
            Description = restrictedEvent.Item.Description;
            Type = nameof(restrictedEvent.Item.Type);
            Address = restrictedEvent.Item.Address;
            StartDate = restrictedEvent.Item.Date;
            EndDate = restrictedEvent.Item.Date;
            OrganizerID = restrictedEvent.Item.Organizer._id.ToString();
        }
    }
}
