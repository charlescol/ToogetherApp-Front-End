using AppModel.Storage;
using System;

namespace DataLayer.Models
{
    /* Model used by the mobile app to store AppModel.Event.RestrictedPublicUser */
    public class RestrictedPublicUser : AbstractModel<string>
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ProfilePictureUri { get; set; } = "";
        public RestrictedPublicUser() { }
        public RestrictedPublicUser(ReferencedItem<Guid, AppModel.User.RestrictedPublicUser> restrictedPublicUser)
        {
            Id = restrictedPublicUser._id.ToString();
            FirstName = restrictedPublicUser.Item.FirstName;
            LastName = restrictedPublicUser.Item.LastName;
            ProfilePictureUri = restrictedPublicUser.Item.ProfilePictureUri;
        }
    }
}
