using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Siemens.SCM.web.Filters;
using Siemens.SCM.Model.DataModel;
using Siemens.SCM.Model;

namespace Siemens.SCM.web.Controllers
{
    [Authorize]
    [InitializeSimpleMembershipAttribute]
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewData["abc"] = "Init";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string loginname, string loginpassword, string returnUrl)
        {
            //WebSecurity.Login("Hayden", "123456", false);
            //FormsAuthentication.SetAuthCookie(
            ViewData["abc"] = "Login In";
            if (ModelState.IsValid && WebSecurity.Login(loginname, loginpassword, false))
            {
                using (UsersContext db = new UsersContext())
                {
                    var q = from item in db.DefaultDatas
                            select item;
                }
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [AllowAnonymous]
        public ActionResult LogOut(Object o)
        {
            WebSecurity.Logout();
            HttpContext.Session.Clear();
            ViewData["abc"] = "LogOut";
            return View("Index");
        }

        [AllowAnonymous]
        public ActionResult Register(string name, string password)
        {
            ViewData["abc"] = "Register";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return View("Index");
            }

            if (!WebSecurity.UserExists(name))
            {
                int status=(new Random()).Next(10);
                WebSecurity.CreateUserAndAccount(name, password, new { Status = status });
            }
            return View("Index");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
