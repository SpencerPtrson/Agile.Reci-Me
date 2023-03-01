using Reci_me.BL;
using Microsoft.AspNetCore.Mvc;

namespace Reci_Me.UI.ViewComponents
{
    public class Sidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(CategoryManager.Load().OrderBy(c => c.Name));
        }
    }
}
