﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Admin.Controllers
{
    [Authorize]
    public class HomeController :BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize]
        public ActionResult OnlyAdmin()
        {
            return View();
        }
    }
}