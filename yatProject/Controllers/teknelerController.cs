using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yatProject.classes;
using yatProject.Models;

namespace yatProject.Controllers
{
    public class teknelerController : Controller
    {
        // GET: tekneler
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tekneleriListele()
        {
            
            return View(availableTekneler.tekneIdleri);
        }

        
    }

}