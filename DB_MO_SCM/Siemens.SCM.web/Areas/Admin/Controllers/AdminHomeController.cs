using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Siemens.SCM.web.Filters;

namespace Siemens.SCM.web.Areas.Admin.Controllers
{
    //[CustomAuthorize]
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/

        public ActionResult Index()
        {
            return View();
        }

    }
}
