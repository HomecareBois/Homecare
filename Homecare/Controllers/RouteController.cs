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
            if(ModelState.IsValid)
            {
                using (HomecareDBEntities db = new HomecareDBEntities())
                {
                    var tidspunkt = inputData.time;
                    var dato = inputData.date;
                    var adresse = db.Patients.FirstOrDefault(pa => pa.patient_name == inputData.patientCpr).fk_address_patient;
                    var caretaker = db.Caretakers.FirstOrDefault(ca => ca.caretaker_name == inputData.caretaker).id_caretaker;

                    var route = new Route
                    {
                        arrival = tidspunkt,
                        date = dato,
                        fk_address_route = adresse,
                        fk_caretaker_route = caretaker
                    };
                    db.Routes.Add(route);
                    db.SaveChanges();
                }
            
            }
            return View();
        }

        public ActionResult RoutesList()
        {

            /*
             * Lav en overordnet liste der viser ét navn pr dato den person har flere ruter.
             * Sørg for den kun viser et navn pr dato og en dato pr navn
             * Lav et link videre til en liste der viser samtlige ruter for den pågældende person på den dag.
             * Formater tid så det kun er dato/måned/år eller time:minut. 
             */

            HomecareDBEntities db = new HomecareDBEntities();

            List<RoutesListView> routes = new List<RoutesListView>();

            foreach(var item in db.Routes)
            {
                var navn = db.Caretakers.FirstOrDefault(ca => ca.id_caretaker == item.fk_caretaker_route).caretaker_name;
                routes.Add(new RoutesListView { name = navn, date = item.date });
            }


            return View(routes);
        }
    }
}