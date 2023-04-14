using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Reci_me.BL;
using Reci_me.BL.Models;
using Reci_me.UI.Models;
using Reci_Me.UI.ViewModels;

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
                return RedirectToAction("Login", "User");
            else
            {
                UserVM userVM = new UserVM();
                userVM.User = UserManager.Load().First();
                return View(userVM);
            }
        }

        public ActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            User user = UserManager.LoadById(id);
            return View(user);
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

        public ActionResult Logout()
        {
            SetUser(null);
            HttpContext.Session.SetObject("fullname", null);
            return RedirectToAction("Index", "Home");
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
                HttpContext.Session.SetObject("id", user.Id);
                HttpContext.Session.SetObject("description", "Welcome " + user.FirstName);
                HttpContext.Session.SetObject("fullname", user.FullName);
                HttpContext.Session.SetObject("firstname", user.FirstName);
                HttpContext.Session.SetObject("lastname", user.LastName);
                HttpContext.Session.SetObject("email", user.Email);
                HttpContext.Session.SetObject("accesslevel", user.AccessLevel.Label);
            }
            else
            {
                HttpContext.Session.SetObject("description", "Please Login");
                HttpContext.Session.SetObject("user", null);
            }
        }



        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Title = "Edit Profile";
            UserVM userVM = new UserVM();
            userVM.User = UserManager.LoadById(id);
            return View(userVM);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserVM userVM)
        {
            try
            {
                ViewBag.Title = "Edit Profile";
                userVM.User.AccessLevel = AccessManager.Load(userVM.User.AccessLevel.Id);

                UserManager.Update(userVM.User);

                HttpContext.Session.SetObject("email", userVM.User.Email);
                HttpContext.Session.SetObject("firstname", userVM.User.FirstName);
                HttpContext.Session.SetObject("lastname", userVM.User.LastName);
                HttpContext.Session.SetObject("description", "Welcome " + userVM.User.FirstName);
                HttpContext.Session.SetObject("fullname", userVM.User.FirstName + " " + userVM.User.LastName);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Error";
                return View(userVM);
            }
        }



        public ActionResult Reset(Guid id)
        {
            ViewBag.Title = "Reset Password";
            UserVM userVM = new UserVM();
            userVM.User = UserManager.LoadById(id);
            return View(userVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reset(int id, UserVM userVM)
        {
            try
            {
                User user = userVM.User;


                ViewBag.Title = "Reset Password";
                userVM.User.AccessLevel = AccessManager.Load(userVM.User.AccessLevel.Id);

                UserManager.Update(userVM.User);         
                HttpContext.Session.SetObject("password", userVM.User.Password);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Error";
                return View(userVM);
            }
        }



        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            UserManager.Delete(id);
            return RedirectToAction(nameof(Logout));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserVM userVM)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
