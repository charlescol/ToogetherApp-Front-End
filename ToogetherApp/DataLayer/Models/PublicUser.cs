using AppModel.Storage;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class PublicUser : AbstractModel<string>
    {
        public string Sex { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ProfilePictureUri { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime BirthdayDate { get; set; } = new DateTime();
        [TextBlob("TagsBlobbed")]
        public IList<string> Tags { get; set; } = new List<string>();
        [TextBlob("FavoriteEventsBlobbed")]
        public IList<RestrictedEvent> FavoriteEvents { get; set; } = new List<RestrictedEvent>();
        [TextBlob("ParticipateEventsBlobbed")]
        public IList<RestrictedEvent> ParticipateEvents { get; set; } = new List<RestrictedEvent>();
        [TextBlob("HistoryEventsBlobbed")]
        public IList<RestrictedEvent> HistoryEvents { get; set; } = new List<RestrictedEvent>();
        public PublicUser(ReferencedItem<Guid, AppModel.User.PublicUser> publicUser)
        {
            Id = publicUser._id.ToString();
            BirthdayDate = publicUser.Item.BirthdayDate;
            Sex = nameof(publicUser.Item.Sex);
            FirstName = publicUser.Item.MainInfo.FirstName;
            Description = publicUser.Item.Description;
            LastName = publicUser.Item.MainInfo.LastName;
            ProfilePictureUri = publicUser.Item.MainInfo.ProfilePictureUri;
            Tags = publicUser.Item.Tags;
            publicUser.Item.FavoriteEvents.ForEach(x => FavoriteEvents.Add(new RestrictedEvent(x)));
            publicUser.Item.ParticipateEvents.ForEach(x => ParticipateEvents.Add(new RestrictedEvent(x)));
            publicUser.Item.HistoryEvents.ForEach(x => HistoryEvents.Add(new RestrictedEvent(x)));
        }
        public PublicUser() { }
        public PublicUser(PublicUser clone)
        {
            Id = clone.Id;
            BirthdayDate = clone.BirthdayDate;
            Sex = clone.Sex;
            FirstName = clone.FirstName;
            Description = clone.Description;
            LastName = clone.LastName;
            ProfilePictureUri = clone.ProfilePictureUri;
            Tags = new List<string>(clone.Tags);
            FavoriteEvents = new List<RestrictedEvent>(clone.FavoriteEvents);
            ParticipateEvents = new List<RestrictedEvent>(clone.ParticipateEvents);
            HistoryEvents = new List<RestrictedEvent>(clone.HistoryEvents);
        }
    }
}
