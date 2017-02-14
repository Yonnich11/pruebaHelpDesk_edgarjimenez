using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HelpDeskBackend.Backend.Logic.Utilities
{
  public static  class Encript
    {
        public static string EncriptValue(string value)
        {
            MD5CryptoServiceProvider service = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = service.ComputeHash(data);
            string result = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                result += data[i].ToString("x2").ToLower();
            }
            return result;
        }
    }
}
