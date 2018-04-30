using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homecare.Models.DataModels;
using Homecare.Models.ViewModels;

namespace Homecare.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(PatientViewModel inputData)
        {
            if (ModelState.IsValid)
            {
                using (HomecareDBEntities db = new HomecareDBEntities())
                {
                    var c = new City
                    {
                        city_name = inputData.cityName,
                        zipcode = inputData.zipCode
                    };

                    db.Cities.Add(c);
                    db.SaveChanges();

                    var phone = new Phone
                    {
                        phone_number = inputData.phonenumber,
                    };
                    db.Phones.Add(phone);

                    var cityId = db.Cities.FirstOrDefault(ci => ci.city_name == inputData.cityName).id_city;

                    var address = new Address
                    {
                        road_name = inputData.roadname,
                        number = inputData.number,
                        fk_city_address = cityId
                    };
                    db.Addresses.Add(address);
                    db.SaveChanges();

                    var addressId = db.Addresses
                        .FirstOrDefault(ai =>
                        ai.road_name == inputData.roadname &&
                        ai.number == inputData.number)
                        .id_address;

                    var phoneId = db.Phones.FirstOrDefault(pi => pi.phone_number == inputData.phonenumber).id_phone;
                    var p = new Patient
                    {
                        patient_name = inputData.name,
                        cpr = inputData.cpr,
                        relative_phonenumber = inputData.relativePhonenumber,
                        fk_address_patient = addressId,
                        fk_phone_patient = phoneId
                    };

                    db.Patients.Add(p);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = inputData.name + " was created";
            }
            return View();
        }

        public ActionResult PatientList ()
        {
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                return View(db.Patients.ToList());
            }
        }

        public ActionResult PatientDetails (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            Address address = db.Addresses.Find(patient.fk_address_patient);
            Phone phone = db.Phones.Find(patient.fk_phone_patient);
            City city = db.Cities.Find(address.fk_city_address);

            PatientViewModel pvm = new PatientViewModel
            {
                name = patient.patient_name,
                cpr = patient.cpr,
                relativePhonenumber = patient.relative_phonenumber,
                roadname = address.road_name,
                number = address.number,
                cityName = city.city_name,
                zipCode = city.zipcode,
                phonenumber = phone.phone_number,
            };
            return View(pvm);
        }

        public ActionResult EditPatient (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();
            Patient patient = db.Patients.Find(id);

            if (patient == null)
            {
                return HttpNotFound();
            }

            Address address = db.Addresses.Find(patient.fk_address_patient);
            Phone phone = db.Phones.Find(patient.fk_phone_patient);
            City city = db.Cities.Find(address.fk_city_address);

            PatientViewModel pvm = new PatientViewModel
            {
                name = patient.patient_name,
                cpr = patient.cpr,
                relativePhonenumber = patient.relative_phonenumber,
                roadname = address.road_name,
                number = address.number,
                cityName = city.city_name,
                zipCode = city.zipcode,
                phonenumber = phone.phone_number,
            };

            return View(pvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatient (PatientViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                HomecareDBEntities db = new HomecareDBEntities();
                db.SaveChanges();

                return RedirectToAction("PatientList");
            }
            return View();
        }

        public ActionResult DeletePatient (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();
            Patient patient = db.Patients.Find(id);

            if (patient == null)
            {
                return HttpNotFound();
            }

            Address address = db.Addresses.Find(patient.fk_address_patient);
            Phone phone = db.Phones.Find(patient.fk_phone_patient);
            City city = db.Cities.Find(address.fk_city_address);

            PatientViewModel pvm = new PatientViewModel
            {
                name = patient.patient_name,
                cpr = patient.cpr,
                relativePhonenumber = patient.relative_phonenumber,
                roadname = address.road_name,
                number = address.number,
                cityName = city.city_name,
                zipCode = city.zipcode,
                phonenumber = phone.phone_number,
            };

            return View(pvm);
        }

        [HttpPost, ActionName("DeletePatient")]
        public ActionResult DeletePatient (int id)
        {
            HomecareDBEntities db = new HomecareDBEntities();

            Patient patient = db.Patients.Find(id);
            Address address = db.Addresses.Find(patient.fk_address_patient);
            City city = db.Cities.Find(address.fk_city_address);
            Phone phone = db.Phones.Find(patient.fk_phone_patient);

            db.Patients.Remove(patient);
            db.Addresses.Remove(address);
            //db.Cities.Remove(city);
            db.Phones.Remove(phone);
            db.SaveChanges();

            return RedirectToAction("PatientList");
        }
    }
}