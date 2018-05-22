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
    public class RouteDetailsController : Controller
    {
     
        public ActionResult RouteDetails(int? id)
        {
            List<Route_Details> routes = new List<Route_Details>();
            HomecareDBEntities db = new HomecareDBEntities();
            
                foreach (var item in db.Route_Details)
                {
                    if(item.fk_route_route_details == id)
                    {
                        routes.Add(item);
                    }
                }
            
            return View(routes);
        }

        public ActionResult CreateRouteDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRouteDetails(int? id, RouteDetailsViewModel inputData)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                
                if(ModelState.IsValid)
                {
                    var patientId = db.Patients.FirstOrDefault(p => p.patient_name == inputData.patientName).id_patient;
                    Route_Details route = new Route_Details
                    {
                        fk_patient_route_details = patientId,
                        fk_route_route_details = (int)id,
                        arrival = inputData.arrival
                    };

                    db.Route_Details.Add(route);
                    db.SaveChanges();
                }
                ModelState.Clear();
                //ViewBag.created = "Besøg for " + inputData.Patient.patient_name.ToString() + " er oprettet";
            }

            return View();
        }

        
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();
            Route_Details routeDetails = new Route_Details();

            routeDetails = db.Route_Details.Find(id);

            if (routeDetails == null)
            {
                return HttpNotFound();
            }

            return View(routeDetails);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Route_Details routeDetails)
        {
            HomecareDBEntities db = new HomecareDBEntities();

            
            Route_Details rd = db.Route_Details.Find(id);

            rd.arrival = routeDetails.arrival;
            db.SaveChanges();

            return RedirectToAction("RouteDetails", new {id = rd.fk_route_route_details });
        }

        public ActionResult Delete(int? id, Route_Details reouteDetails)
        {
            return View();
        }
    }
}