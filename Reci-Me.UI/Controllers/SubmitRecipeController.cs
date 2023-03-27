using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;
using Reci_Me.UI.ViewModels;

namespace Reci_Me.UI.Controllers
{
    public class SubmitRecipeController : Controller
    {
        // GET: SubmitRecipeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubmitRecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubmitRecipeController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create a Recipe";
            RecipeVM recipeVM = new RecipeVM();
            return View(recipeVM);
        }

        // POST: SubmitRecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeVM recipeVM)
        {
            try
            {
                RecipeManager.Insert(recipeVM.Recipe);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Create a Recipe";
                return View(recipeVM);
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
