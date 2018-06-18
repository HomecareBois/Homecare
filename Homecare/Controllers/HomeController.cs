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
            var username = Session["username"] as string;
            if(username == null)
            {
                return RedirectToAction("Login", "Account");
            }

            HomecareDBEntities db = new HomecareDBEntities();
            return View(db.Routes.ToList());
        }

        public ActionResult About()
        {
            var username = Session["username"] as string;
            if (username == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var username = Session["username"] as string;
            if (username == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}