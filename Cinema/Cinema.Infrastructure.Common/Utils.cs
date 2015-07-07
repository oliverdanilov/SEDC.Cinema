using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Common
{
    public static class Utils
    {
        public static string GeneratePasswordHash(string rawPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return Convert.ToBase64String(sha1.ComputeHash(UTF8Encoding.UTF8.GetBytes(rawPassword)));
        }
    }
}
