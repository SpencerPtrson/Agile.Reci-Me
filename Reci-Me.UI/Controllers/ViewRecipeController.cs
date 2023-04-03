using Microsoft.AspNetCore.Mvc;

namespace Reci_Me.UI.Controllers
{
    public class ViewRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
