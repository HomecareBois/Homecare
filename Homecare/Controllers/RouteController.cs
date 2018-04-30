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

        public ActionResult ViewRoute()
        {
            return View();
        }

    }
}