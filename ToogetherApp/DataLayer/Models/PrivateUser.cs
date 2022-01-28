using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class PrivateUser : AbstractModel<string>
    {
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime AccountCreationDate { get; set; } = new DateTime();
        public PublicUser PublicUser { get; set; } = new PublicUser();
        public PrivateUser(PrivateUser clone)
        {
            PublicUser = new PublicUser(clone.PublicUser);
            PhoneNumber = clone.PhoneNumber;
            Email = clone.Email;
            AccountCreationDate = clone.AccountCreationDate;
        }
        public PrivateUser()
        {}
    }
}
