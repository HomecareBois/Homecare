using Homecare.Models.DataModels;
using Homecare.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homecare.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        
        public ActionResult CreateRoute()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoute(RouteViewModel inputData)
        {
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                var caretakerIdToDb = db.Caretakers
                    .FirstOrDefault(ci => ci.caretaker_name == inputData.caretaker)
                    .id_caretaker;

                var addressIdToDb = db.Patients
                    .FirstOrDefault(ai => ai.cpr == inputData.patientCpr).fk_address_patient;

                var arrivalToDb = inputData.date.TimeOfDay;

                var dateToDb = inputData.date.Date;

                var route = new Route
                {
                    arrival = arrivalToDb,
                    date = dateToDb,
                    fk_caretaker_route = caretakerIdToDb,
                    fk_address_route = addressIdToDb

                };
                db.Routes.Add(route);
                db.SaveChanges();
            };

            return View();
        }

        public ActionResult TestRoute(int? id)
        {
            HomecareDBEntities db = new HomecareDBEntities();

            var list = from c in db.Caretakers
                       where c.caretaker_name.Equals("1")
                       select c;

            return View(list.ToList());
        }

        public ActionResult AllRoutes()
        {
            HomecareDBEntities db = new HomecareDBEntities();

            //var routeList = from r in db.Routes
            //                join c in db.Caretakers on r.fk_caretaker_route equals c.id_caretaker
            //                where c.id_caretaker == 1
            //                select r;

            //var routeList = db.Database.SqlQuery<RouteCaretakerView>
            //    ("SELECT dbo.Route.id_route, dbo.Caretaker.caretaker_name " +
            //    "FROM Route  " +
            //    "INNER JOIN Caretaker ON Route.fk_caretaker_route = dbo.Caretaker.id_caretaker").AsEnumerable();

            //var routeList = db.Routes.ToList();
            //foreach(Route r in routeList)
            //{
            //    db.Entry(r).Collection(
            //}
            //return View(routeList);
        }

        public ActionResult ViewRoute(int? id)
        {
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                return View(db.Routes.ToList());
            }
        }

    }
}