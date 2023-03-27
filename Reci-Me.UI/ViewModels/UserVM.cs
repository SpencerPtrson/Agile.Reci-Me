using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.UI.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        public List<AccessLevel> AccessLevels { get; set; }

        // Constructor used with the word Create
        public UserVM()
        {
            AccessLevels = AccessManager.Load();
        }

        // Constructor used with the word Edit
        public UserVM(int id)
        {
            AccessLevels = AccessManager.Load();
        }
    }
}
