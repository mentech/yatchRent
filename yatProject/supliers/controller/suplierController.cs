using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yatProject.supliers.controller
{
    public class suplierController : Controller
    {
        // GET: suplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tekneEkle()
        {
            return View();
        }
       


        public ActionResult fotoEkle (HttpPostedFileBase fileUpload)
        {
            if (HttpContext.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Request.Files[0];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = (HttpContext.Server.MapPath("~/UploadedFiles") + httpPostedFile.FileName.Substring(httpPostedFile.FileName.LastIndexOf(@"\")));

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
            return View();
        }


    }
}