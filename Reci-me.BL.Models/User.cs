using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Will be the image path of the picture
        public string ProfilePicture { get; set; }
        public string ProfileDescription { get; set; }
        public Guid AccessLevelId { get; set; }
    }
}
