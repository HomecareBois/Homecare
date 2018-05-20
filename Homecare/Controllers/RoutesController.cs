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
            HomecareTestDB db = new HomecareTestDB();
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

        public ActionResult CreateRouteTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRouteTest(Route inputData)
        {
            if(ModelState.IsValid)
            {
                using (HomecareTestDB db = new HomecareTestDB())
                {

                    var caretaker = db.Caretakers.First(ca => ca.caretaker_name == inputData.Caretaker.caretaker_name);
                    var route = new Route
                    {
                        Caretaker = caretaker,
                        date = inputData.date
                    };
                    db.Routes.Add(route);
                    db.SaveChanges();

                }
            }
            return View();
        }
        //[HttpPost]
        //public ActionResult CreateRoute(RouteViewModel inputData)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        using (HomecareTestDB db = new HomecareTestDB())
        //        {
        //            var tidspunkt = inputData.time;
        //            var dato = inputData.date;
        //            var adresse = db.Patients.FirstOrDefault(pa => pa.patient_name == inputData.patientCpr).fk_address_patient;
        //            var caretaker = db.Caretakers.FirstOrDefault(ca => ca.caretaker_name == inputData.caretaker).id_caretaker;

        //            var route = new Route
        //            {
        //                fk_caretaker_route = caretaker,
        //                date = dato
        //            };
        //            db.Routes.Add(route);
        //            db.SaveChanges();
        //            var routeDetails = new RouteDetail
        //            {
        //                arrival = tidspunkt,
        //                fk_address_route = adresse,
        //                fk_route_routedetails = db.Routes.FirstOrDefault(r => r.fk_caretaker_route == caretaker && r.date == dato).id_route
        //            };
        //            db.RouteDetails.Add(routeDetails);
        //            db.SaveChanges();
        //        }
        //        ModelState.Clear();

        //    }
        //    return View();
    }
}