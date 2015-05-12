using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Siemens.SCM.web.Filters;
using Siemens.SCM.BLL;
using Siemens.SCM.Model;

namespace Siemens.SCM.web.Controllers
{
    [CustomAuthorize]
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                Role role = new Role() { RoleName = roleName, TreeLevel = 1, Status = 1 };
                UserRoleManager manager = new UserRoleManager();
                var result = manager.AddRole(role);
            } 
            return View("Index");
        }

        public ActionResult UpdateRole(string roleName)
        {
            UserRoleManager manager = new UserRoleManager();
            Role role = manager.GetRoleFromName(roleName);
            role.Status = 10;
            manager.UpdateRole(role);
            return View("Index");
        }
    }
}
