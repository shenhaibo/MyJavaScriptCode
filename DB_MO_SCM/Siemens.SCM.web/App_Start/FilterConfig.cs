using System.Web;
using System.Web.Mvc;
using Siemens.SCM.web.Filters;

namespace Siemens.SCM.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CustomAuthorizeAttribute());
        }
    }
}