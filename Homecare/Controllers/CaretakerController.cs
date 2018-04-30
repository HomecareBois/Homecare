using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
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

                    db.Caretakers.Add(caretaker);
                    db.SaveChanges();
                }
                

                ModelState.Clear();
                ViewBag.Message = inputData.name + " was created";
            }

            return View();
        }
    }
}