using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yatProject.Models;
using Microsoft.AspNet.Identity;

namespace yatProject.supliers.controller
{
    public class suplierController : Controller
    {
        // GET: suplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addYatch()
        {
            var yatch= new tblProduct();
            return View(yatch);
        }
        [HttpPost]
        public ActionResult addYatch( tblProduct yatch)
        {
            bool loginmi= User.Identity.IsAuthenticated;
            string userty = User.Identity.AuthenticationType;
          var re= HttpContext.User.Identity.GetUserId();
            
            return View();
        }
        public ActionResult addYatchImage()
        {
            

            return View();
        }
        
        public void fotoEkle (HttpPostedFileBase fileUpload, string yazi)
        {

            var riiz = Request.Files;

            if (HttpContext.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Request.Files[0];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                   // var fileSavePath = (HttpContext.Server.MapPath("~/images") + httpPostedFile.FileName.Substring(httpPostedFile.FileName.LastIndexOf(@"\")));
                    httpPostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/images/") + System.IO.Path.GetFileName(httpPostedFile.FileName.ToString())));

                    // Save the uploaded file to "UploadedFiles" folder
                   // httpPostedFile.SaveAs(fileSavePath);

                }
            }
            
        }


    }
}