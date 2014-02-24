using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace KreateIT.Business
{
    class Security
    {
        public static string GetHash(string Password, Guid Salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes("{" + Salt.ToString().ToUpper() + "}" + Password);
            byte[] hash = new SHA256Managed().ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
         
    }
}
