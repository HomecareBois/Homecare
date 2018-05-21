using Homecare.Models.DataModels;
using Homecare.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Homecare.Controllers
{
    public class RoutesController : Controller
    {
        public ActionResult Index()
        {
            HomecareDBEntities db = new HomecareDBEntities();
            List<RoutesListView> routes = new List<RoutesListView>();
            foreach (var item in db.Routes)
            {
                RoutesListView route = new RoutesListView
                {
                    Caretaker = item.Caretaker,
                    date = item.date.ToString("dd-MM-yyyy")
                };
                routes.Add(route);
            }
            return View(routes);
        }



        public ActionResult CreateRoute()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoute(Route inputData)
        {
            if(ModelState.IsValid)
            {
                using (HomecareDBEntities db = new HomecareDBEntities())
                { 
                    var caretaker = db.Caretakers.First(ca => ca.caretaker_name == inputData.Caretaker.caretaker_name);
                    var route = new Route
                    {
                        Caretaker = caretaker,
                        date = inputData.date
                    };
                    foreach(var item in db.Routes)
                    {
                        if(item.date == inputData.date && item.Caretaker.caretaker_name == inputData.Caretaker.caretaker_name)
                        {
                            ViewBag.error = "Fejl! Du kan ikke oprette en rute for en hjemmehjælper på en dag de allerede har en rute";
                            return View();
                        }
                    }
                    db.Routes.Add(route);
                    db.SaveChanges();
                }
            }
            return Redirect("Index");
        }
    }
}