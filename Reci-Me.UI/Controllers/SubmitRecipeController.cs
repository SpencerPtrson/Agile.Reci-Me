using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reci_Me.UI.ViewModels;

namespace Reci_Me.UI.Controllers
{
    public class SubmitRecipeController : Controller
    {
        // GET: SubmitRecipeController
        public ActionResult Index()
        {
            RecipeVM recipeVM = new RecipeVM();
            return View(recipeVM);
        }

        // GET: SubmitRecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubmitRecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubmitRecipeController/Create
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

        // GET: SubmitRecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubmitRecipeController/Edit/5
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

        // GET: SubmitRecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubmitRecipeController/Delete/5
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
