using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homecare.Models.DataModels;
using Homecare.Models.ViewModels;

namespace Homecare.Controllers
{
    public class CaretakerController : Controller
    {
        // GET: Caretaker
        public ActionResult Index()
        {
            using (HomecareDBEntities db = new HomecareDBEntities())
            {
                return View(db.CaretakerViews.ToList());
            }
        }
           
        public ActionResult CreateCaretaker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCaretaker(CaretakerViewModel inputData)
        {
            if (ModelState.IsValid)
            {
                using (HomecareDBEntities db = new HomecareDBEntities())
                {
                    Phone phonenumberMatch = db.Phones
                        .Where(p => p.phone_number == inputData.phonenumber)
                        .FirstOrDefault();

                    var userRights = new User_Rights
                    {
                        user_rights_type = inputData.user_rights
                    };

                    db.User_Rights.Add(userRights);
                    db.SaveChanges();

                    var userRightsID = db.User_Rights.FirstOrDefault(ur => ur.user_rights_type == inputData.user_rights).id_user_rights;

                    var userLogin = new Login
                    {
                        username = inputData.username,
                        password = inputData.password,
                        fk_user_rights_login = userRightsID
                    };

                    db.Logins.Add(userLogin);
                    db.SaveChanges();

                    var phonenumber = new Phone
                    {
                        phone_number = inputData.phonenumber
                    };

                    db.Phones.Add(phonenumber);
                    db.SaveChanges();

                    var loginID = db.Logins.FirstOrDefault(login => login.username == inputData.username).id_login;
                    var phoneID = db.Phones.FirstOrDefault(phone => phone.phone_number == inputData.phonenumber).id_phone;


                    var caretaker = new Caretaker
                    {
                        caretaker_name = inputData.name,
                        fk_login_caretaker = loginID,
                        fk_phone_caretaker = phoneID
                    };

                    if (phonenumberMatch != null)
                    {
                        ViewBag.PhoneMessage = "Telefonnummer eksisterer allerede";
                    } else
                    {
                        db.Caretakers.Add(caretaker);
                        db.SaveChanges();
                        ViewBag.LoginMessage = inputData.name + " blev oprettet";
                        ModelState.Clear();
                    }
                }
            }
            return View();
        }

        public ActionResult EditCaretaker (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();
            Caretaker caretaker = db.Caretakers.Find(id);

            if (caretaker == null)
            {
                return HttpNotFound();
            }

            Login login = db.Logins.Find(caretaker.fk_login_caretaker);
            Phone phone = db.Phones.Find(caretaker.fk_phone_caretaker);
            User_Rights user_rights = db.User_Rights.Find(login.fk_user_rights_login);

            CaretakerViewModel cvm = new CaretakerViewModel
            {
                name = caretaker.caretaker_name,
                username = login.username,
                password = login.password,
                confirmPassword = login.password,
                phonenumber = phone.phone_number,
                user_rights = user_rights.user_rights_type
            };

            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCaretaker (CaretakerViewModel cvm, int? id)
        {
            if (ModelState.IsValid)
            {
                HomecareDBEntities db = new HomecareDBEntities();

                Caretaker caretaker = db.Caretakers.Find(id);

                Login login = db.Logins.Find(caretaker.fk_login_caretaker);
                Phone phone = db.Phones.Find(caretaker.fk_phone_caretaker);
                User_Rights user_rights = db.User_Rights.Find(login.fk_user_rights_login);

                login.username = cvm.username;
                login.password = cvm.password;
                phone.phone_number = cvm.phonenumber;
                user_rights.user_rights_type = cvm.user_rights;

                caretaker.caretaker_name = cvm.name;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteCaretaker(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HomecareDBEntities db = new HomecareDBEntities();
            Caretaker caretaker = db.Caretakers.Find(id);

            if (caretaker == null)
            {
                return HttpNotFound();
            }

            Login login = db.Logins.Find(caretaker.fk_login_caretaker);
            Phone phone = db.Phones.Find(caretaker.fk_phone_caretaker);
            User_Rights user_rights = db.User_Rights.Find(login.fk_user_rights_login);

            CaretakerViewModel cvm = new CaretakerViewModel
            {
                name = caretaker.caretaker_name,
                username = login.username,
                password = login.password,
                confirmPassword = login.password,
                phonenumber = phone.phone_number,
                user_rights = user_rights.user_rights_type
            };
            return View(cvm);
        }

        [HttpPost, ActionName("DeleteCaretaker")]
        public ActionResult DeleteCaretaker(int id)
        {
            HomecareDBEntities db = new HomecareDBEntities();

            Caretaker caretaker = db.Caretakers.Find(id);
            Phone phone = db.Phones.Find(caretaker.fk_phone_caretaker);
            Login login = db.Logins.Find(caretaker.fk_login_caretaker);
            //User_Rights user_rights = db.User_Rights.Find(login.fk_user_rights_login);


            db.Routes.RemoveRange(db.Routes.Where(x => x.fk_caretaker_route == caretaker.id_caretaker));
            db.Caretakers.Remove(caretaker);
            db.Phones.Remove(phone);
            //db.User_Rights.Remove(user_rights);
            db.Logins.Remove(login);    
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
