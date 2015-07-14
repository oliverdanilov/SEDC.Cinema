using Cinema.AppSerivces;
using Cinema.Infrastructure.Data;
using Cinema.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Admin
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var username = filterContext.HttpContext.User.Identity.Name;
            string cnnString = ConfigurationManager.ConnectionStrings["defaultCnn"].ToString();
            var dbContext = new CinemaDbContext(cnnString);
            var userRepo = new UserRepository(dbContext);
            UserService service = new UserService(userRepo);
            bool isAdmin = service.IsAdmin(username);
            if (!isAdmin)
                throw new UnauthorizedAccessException();
        }
    }
}