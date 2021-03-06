﻿using System;
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

        [AllowAnonymous]
        [HttpPost]
        public ActionResult DownloadFile()
        {
            GC.Collect();
            string path = Server.MapPath("/Temp/Test.xlsx");//这两句是楼主的代码，下面是我的代码
            //FileStream fs = new FileStream(path, FileMode.Open);
            //byte[] buffer = new byte[fs.Length];
            //fs.Read(buffer, 0, buffer.Length);
            //fs.Close();
            //System.IO.File.Delete(path);

            //return File(buffer, "application/octet-stream", "Test.xlsx");
            //System.IO.File.Delete(Server.MapPath("/Temp/Test.xlsx"));
            //return File("/Temp/Test.xlsx", "application/x-excel");//, "Test.xlsx");
            //return File("/Temp/Test.xlsx", "application/vnd.ms-excel"); //文件后缀名格式为Excel 2003
            byte[] buffer = Siemens.SCM.BLL.ExcelGenerate.GenerateExcel(path);
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");//, "Test.xlsx");  //文件后缀名格式为Excel 2007
            //Stream s = Siemens.SCM.BLL.ExcelGenerate.GenerateExcel1();
            //return File(s, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");//, "Test.xlsx");  //文件后缀名格式为Excel 2007


        }
    }
}
