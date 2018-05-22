using Homecare.Models.DataModels;
using Homecare.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Homecare.Controllers
{
    public class RoutesController : Controller
    {
        public ActionResult Index()
        {
            HomecareDBEntities db = new HomecareDBEntities();
           
            return View(db.Routes.ToList());
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

        public ActionResult Delete(int? id)
        {

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();

            Route rou = new Route();
            rou = db.Routes.Find(id);

            if(rou == null)
            {
                return HttpNotFound();
            }

            return View(rou);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            HomecareDBEntities db = new HomecareDBEntities();
            Route rou = new Route();

            rou = db.Routes.Find(id);

            db.Routes.Remove(rou);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}