using Homecare.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homecare.Controllers
{
    public class RouteDetailsController : Controller
    {
     
        public ActionResult RouteDetails(int? id)
        {
            List<Route_Details> routes = new List<Route_Details>();
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                foreach (var item in db.Route_Details)
                {
                    if(item.fk_route_route_details == id)
                    {
                        routes.Add(item);
                    }
                }
            }
            return View(routes);
        }

        public ActionResult CreateRouteDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRouteDetails(int? id, Route_Details inputData)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                if(ModelState.IsValid)
                {
                    Route_Details route = new Route_Details
                    {
                        fk_patient_route_details = inputData.Patient.id_patient,
                        fk_route_route_details = (int)id,
                        arrival = inputData.arrival
                    };
                    db.Route_Details.Add(route);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.created = "Besøg for " + inputData.Patient.patient_name.ToString() + " er oprettet";
            }

            return View();
        }

    }
}