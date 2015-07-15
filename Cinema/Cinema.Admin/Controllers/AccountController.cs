using Cinema.AppSerivces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cinema.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDto model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            bool canAuthenticate = _userService.Authenticate(model.Username, model.Password);
            if (canAuthenticate)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home");
                
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _userService.RegisterUser(model);

            FormsAuthentication.SetAuthCookie(model.Username, false);
            return RedirectToAction("Index", "Home");
        }
    }
}