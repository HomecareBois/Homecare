using Homecare.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homecare.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomecareDBEntities db = new HomecareDBEntities();
            return View(db.Routes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}