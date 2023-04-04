using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;

namespace Reci_Me.UI.Controllers
{
    public class AllRecipeController : Controller
    {
        // GET: AllRecipeController
        public ActionResult Index()
        {
            ViewBag.Title = "Recipes";
            return View(RecipeManager.Load());
        }

        // GET: AllRecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // Shows the filtered list
        public ActionResult Browse(Guid id)
        {
            ViewBag.Title = "Recipes";
            return View(nameof(Index), RecipeManager.Load(id));
        }



        // GET: AllRecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllRecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: AllRecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AllRecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: AllRecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllRecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
