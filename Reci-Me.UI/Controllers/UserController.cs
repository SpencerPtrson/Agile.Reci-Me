using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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

        public ActionResult Login(string returnUrl)
        {
            TempData["returnurl"] = returnUrl;
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                UserManager.Login(user);
                //SetUser(user);

                return RedirectToAction("Index", "Home");

                //if (TempData["returnurl"] != null)
                //    return Redirect(TempData["returnurl"]?.ToString());
                //else
                //    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        private void SetUser(User user)
        {
            //HttpContext.Session.SetObject("user", user);

            //if (user != null)
            //{
            //    HttpContext.Session.SetObject("fullname", "Welcome " + user.Email);
            //}
            //else
            //{
            //    HttpContext.Session.SetObject("fullname", "Welcome " + String.Empty);
            //}
        }
    }
}
