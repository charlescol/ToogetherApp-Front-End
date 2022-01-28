using AppModel.Storage;
using System;

namespace BusinessLogicLayer.Adapters
{
    /* Adapter for RestrictedPublicUser model object */
    public class RestrictedPublicUserAdapter
    {
        /* Convert DataLayer.Models.RestrictedPublicUser to AppModel.Event.RestrictedPublicUser */
        public ReferencedItem<Guid, AppModel.User.RestrictedPublicUser> ToAppModel(DataLayer.Models.RestrictedPublicUser restrictedUser)
        {
            var user = new AppModel.User.RestrictedPublicUser(restrictedUser.FirstName, restrictedUser.LastName, restrictedUser.ProfilePictureUri);
            return new ReferencedItem<Guid, AppModel.User.RestrictedPublicUser>(new Guid(restrictedUser.Id), user);
        }
    }
}
