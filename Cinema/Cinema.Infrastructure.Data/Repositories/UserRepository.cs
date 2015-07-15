using Cinema.Core.Entities;
using Cinema.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CinemaDbContext context)
            :base(context)
        {

        }

        public List<User> Search(string username, string name = "", string surname = "")
        {
            var _list = _context.Users.Where(x=>x.Username.Contains(username)).AsEnumerable();

            if (name != "")
                _list = _list.Where(x => x.Name.Contains(name));

            if (surname != "")
                _list = _list.Where(x => x.Surname.Contains(surname));

            return _list.ToList();
        }
    }
}
