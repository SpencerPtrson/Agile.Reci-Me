using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        //public string UserName { get; set; } Seem to have no username in our DB
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        // Will be the image path of the picture
        public string ProfilePicture { get; set; }
        public string ProfileDescription { get; set; }
        public AccessLevel AccessLevel { get; set; }

    }
}
