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
        [HttpPost]
        public void fotoEkle (HttpPostedFileBase fileUpload, string yazi)
        {
            if (HttpContext.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i < HttpContext.Request.Files.Count; i++)
                {
                    var httpPostedFile = HttpContext.Request.Files[i];
                    if (httpPostedFile != null)
                    {
                        httpPostedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/images/") + System.IO.Path.GetFileName(httpPostedFile.FileName.ToString())));
                    }
                }
                
            }
            
        }


    }
}