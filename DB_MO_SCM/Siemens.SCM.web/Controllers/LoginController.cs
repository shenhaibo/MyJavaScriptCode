using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Siemens.SCM.web.Filters;
using Siemens.SCM.Model.DataModel;

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
        public ActionResult Login(string returnUrl)
        {
            //WebSecurity.Login("Hayden", "123456", false);
            //FormsAuthentication.SetAuthCookie(
            ViewData["abc"] = "Login In";
            if (ModelState.IsValid && WebSecurity.Login("Hayden", "123456", false))
            {
                using (DataContext db = new DataContext())
                {
                    var q = from item in db.DefaultDatas
                            select item;
                }

                return RedirectToLocal(returnUrl);
            }
            return View("Index");
        }

        [AllowAnonymous]
        public ActionResult LogOut(Object o)
        {
            WebSecurity.Logout();
            ViewData["abc"] = "LogOut";
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
