using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using Siemens.SCM.BLL;

namespace Siemens.SCM.web.Filters
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private string CurrentPrivilege { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool canAccess = base.AuthorizeCore(httpContext);
            if (canAccess)
            {
                //判断角色权限
                List<string> privileges = GetUserPrivileges(httpContext.User.Identity.Name);
                if (!privileges.Contains(CurrentPrivilege))
                {
                    httpContext.Response.Redirect("~/Error/UnAuthorized");
                }
            }
            return canAccess;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //获取Controller Name
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //获取Action Name
            string actionName = filterContext.ActionDescriptor.ActionName;
            //获取权限
            CurrentPrivilege = GetCurrentPrivilege(actionName, controllerName);
            base.OnAuthorization(filterContext);
        }

        private List<string> GetUserPrivileges(string name)
        {
            List<string> privileges = null;
            string mapUser = HttpContext.Current.Session["UserName"] == null ? "" : HttpContext.Current.Session["UserName"].ToString();
            if (HttpContext.Current.Session["UserPrivileges"] == null || mapUser != HttpContext.Current.User.Identity.Name)
            {
                UserManager manager = new UserManager(name);
                privileges = manager.GetPrivileges();
                HttpContext.Current.Session["UserPrivileges"] = privileges;
                HttpContext.Current.Session["UserName"] = HttpContext.Current.User.Identity.Name;
            }
            else
            {
                privileges = (List<string>)HttpContext.Current.Session["UserPrivileges"];
            }
            return privileges;
        }

        private string GetCurrentPrivilege(string actionName, string controllName)
        {
            string privilege = string.Empty;
            PrivilegeManager manager = new PrivilegeManager();
            privilege = manager.GetCurrentPrivilegeName(actionName, controllName);
            return privilege;
        }
    }
}