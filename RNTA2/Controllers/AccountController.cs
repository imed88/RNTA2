using RNTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RNTA2.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Users model)
        {
            using (var context = new RNTAEntities())
            {
                bool isValid = context.Users.Any(x=>x.AppUserName == model.AppUserName && x.Password==model.Password);
                if (true)
                {
                    FormsAuthentication.SetAuthCookie(model.AppUserName, false);
                    return RedirectToAction("Index", "Employees");
                }
            }
            
        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Users model)
        {
            using (var context = new RNTAEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }




    }
}