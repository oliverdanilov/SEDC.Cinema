using Cinema.Core.Entities;
using Cinema.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Data
{
    public class DataEntitiesInitializer : DropCreateDatabaseIfModelChanges<CinemaDbContext>
    {
        protected override void Seed(CinemaDbContext context)
        {
            User user = new User();
            user.Username = "admin";
            user.Password = Utils.GeneratePasswordHash("admin123");
            user.IsAdmin = true;
            context.Users.Add(user);

            User user2 = new User();
            user2.Username = "oliver";
            user2.Password = Utils.GeneratePasswordHash("oliver123");
            user2.IsAdmin = false;
            context.Users.Add(user2);

            base.Seed(context);
        }
    }
}
