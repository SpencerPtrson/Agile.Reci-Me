using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;
using Reci_me.BL.Models;
using Reci_Me.UI.ViewModels;

namespace Reci_Me.UI.Controllers
{
    public class RecipeController : Controller
    {

        // LOADS
        // GET: RecipeController
        public ActionResult Index()
        {
            ViewBag.Title = "Recipes";
            return View(RecipeManager.Load());
        }

        // GET: RecipeController/Details/5
        /*public ActionResult Details()
        {
            //Recipe recipe = RecipeManager.LoadById(id);
            return View();
        }*/
        public ActionResult Details(Guid id)
        {
            Recipe recipe = RecipeManager.LoadById(id);
            return View(recipe);
        }

        public ActionResult Browse(Guid id)
        {
            ViewBag.Title = "Recipes";
            return View(nameof(Index), RecipeManager.Load(id));
        }


        // CREATES
        // GET: RecipeController/Create
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
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Error";
                return View(recipeVM);
            }
        }


        // EDITS
        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipeController/Edit/5
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


        // DELETES
        // GET: RecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeController/Delete/5
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
