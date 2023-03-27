using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;
using Reci_me.BL.Models;
using Reci_me.UI.Models;

namespace Reci_Me.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            ViewBag.Title = "Users";

            string fullname = HttpContext.Session.GetString("fullname");
            if (fullname == "null")
            {
                return RedirectToAction("Login", "User");
            }    
                else
                    return View(UserManager.Load());

        }

        public ActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }

        public ActionResult Logout()
        {
            SetUser(null);
            HttpContext.Session.SetObject("fullname", null);
            return RedirectToAction("Index", "Home");
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
        public ActionResult Create(User user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        public ActionResult Login(string returnUri)
        {
            TempData["returnuri"] = returnUri;
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
                SetUser(user);

                // Tempdata is currently null
                if (TempData["returnuri"] != null)
                    return Redirect(TempData["returnuri"]?.ToString());
                else
                    return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        private void SetUser(User user)
        {
            HttpContext.Session.SetObject("user", user);

            if (user != null)
            {
                HttpContext.Session.SetObject("description", "Welcome " + user.FirstName);
                HttpContext.Session.SetObject("fullname", user.FullName);
                HttpContext.Session.SetObject("firstname", user.FirstName);
                HttpContext.Session.SetObject("lastname", user.LastName);
                HttpContext.Session.SetObject("email", user.Email);
                HttpContext.Session.SetObject("accesslevel", user.AccessLevelId);
            }
            else
            {
                HttpContext.Session.SetObject("description", "Please Login");
                HttpContext.Session.SetObject("user", null);
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
    }
}
