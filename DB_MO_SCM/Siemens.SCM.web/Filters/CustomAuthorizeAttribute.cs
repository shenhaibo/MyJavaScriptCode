using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace Siemens.SCM.web.Filters
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        //public new string[] Roles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool canAccess = base.AuthorizeCore(httpContext);
            if (canAccess)
            {
                //判断角色权限
                //string name = WebSecurity.CurrentUserName;

            }
            return canAccess;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            //获取Controller Name
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //获取Action Name
            string actionName = filterContext.ActionDescriptor.ActionName;
            //获取角色权限
            //string roles = GetRoles.GetActionRoles(actionName, controllerName);
            //if (!string.IsNullOrWhiteSpace(roles))
            //{
            //    this.Roles = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //}
            base.OnAuthorization(filterContext);
        }
    }
}