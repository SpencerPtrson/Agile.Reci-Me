using Reci_me.BL;
using Microsoft.AspNetCore.Mvc;

namespace Reci_Me.UI.ViewComponents
{
    public class RecipeCard : ViewComponent
    {
        public IViewComponentResult Invoke(string name)
        {
            return View(RecipeManager.LoadByName(name));
        }
    }
}
