using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.UI.ViewModels
{
    public class RecipeVM
    {
        public Recipe Recipe { get; set; }
        public List<Category> Categories { get; set; }

        // Constructor used with the word Create
        public RecipeVM() {
            Categories = CategoryManager.Load();
        }

        // Constructor used with the word Edit
        public RecipeVM(int id)
        {
            Categories = CategoryManager.Load();
        }
    }
}
