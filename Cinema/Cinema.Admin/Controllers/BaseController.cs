using Cinema.AppSerivces;
using Cinema.Infrastructure.Data;
using Cinema.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected UserService _userService;
        public BaseController()
        {
            string cnnString = ConfigurationManager.ConnectionStrings["defaultCnn"].ToString();
            var dbContext = new CinemaDbContext(cnnString);
            var userRepo = new UserRepository(dbContext);

            _userService = new UserService(userRepo);
                
        }
    }
}