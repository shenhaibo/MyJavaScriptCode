using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Siemens.SCM.web.Filters;
using System.IO;

namespace Siemens.SCM.web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
            
        }

        [AllowAnonymous]
        public JsonResult ReturnJson()
        {
            List<object> list = new List<object>(){
            new { ID = 1, Name = "Hayden" },
            new { ID = 2, Name = "Jack" }
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null && FileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(FileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/Temp/"), fileName);
                FileUpload.SaveAs(path);
            }

            return View("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ContentResult UploadFile(HttpPostedFileBase fileData)
        {
            if (fileData != null && fileData.ContentLength > 0)
            {
                string fileSavedFolder = Server.MapPath("~/Temp/");
                string extName = Path.GetExtension(fileData.FileName);
                string newName = Guid.NewGuid().ToString() + extName;
                fileData.SaveAs(Path.Combine(fileSavedFolder, newName));
            }
            return Content("");
        }
    }
}
