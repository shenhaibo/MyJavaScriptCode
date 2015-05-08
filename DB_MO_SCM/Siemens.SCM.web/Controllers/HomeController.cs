using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Siemens.SCM.web.Filters;

namespace Siemens.SCM.web.Controllers
{
    //[Authorize]
    [CustomAuthorizeAttribute]
    //[InitializeSimpleMembershipAttribute]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            //WebSecurity.CreateUserAndAccount("Hayden", "123456", new { Status = 1 });
            return View();
            
        }

    }
}
