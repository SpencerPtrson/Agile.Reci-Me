using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;
using Reci_me.BL.Models;
using Reci_Me.UI.ViewModels;

namespace Reci_Me.UI.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IWebHostEnvironment _host;

        public RecipeController(IWebHostEnvironment host)
        {
            // Store the parameter from the constructor into a private, readonly field
            _host = host;
        }

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
                if(recipeVM.File != null)
                {
                    recipeVM.Recipe.MainImagePath = recipeVM.File.FileName;
                    // Upload the File
                    string path = _host.WebRootPath + "\\images\\Recipe\\";
                    if (!System.IO.File.Exists(path + recipeVM.File.FileName))
                    {
                        using (var stream = System.IO.File.Create(path + recipeVM.File.FileName))
                        {
                            recipeVM.File.CopyTo(stream); // upload the code to the server
                            ViewBag.Message = "File uploaded successfully";
                        }
                    }
                }

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
