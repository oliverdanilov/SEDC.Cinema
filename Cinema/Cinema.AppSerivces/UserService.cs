using Cinema.AppSerivces.DTOs;
using Cinema.Core.Entities;
using Cinema.Core.Interfaces;
using Cinema.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.AppSerivces
{
    public class UserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Authenticate(string username, string password)
        {
            password = Utils.GeneratePasswordHash(password);
            var foundUser = _userRepository.GetBy(x => x.Username == username && x.Password == password && !x.Deleted).FirstOrDefault();

            return foundUser != null ? true : false;
        }

        public void RegisterUser(UserDto dto)
        {
            User entity = new User();
            entity.Username = dto.Username;
            entity.Password = Utils.GeneratePasswordHash(dto.Password);
            _userRepository.Add(entity);
            _userRepository.Save();
        }

        public bool IsAdmin(string username)
        {
            var foundUser = _userRepository.GetBy(x => x.Username == username && x.IsAdmin && !x.Deleted).FirstOrDefault();
            return foundUser != null ? true : false;
        }
    }
}
