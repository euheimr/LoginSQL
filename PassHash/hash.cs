using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHash
{
    public class Hash
    {

        public static string GetMD5Hash(string password)
        {

            MD5 md5 = MD5.Create();
            //create the hash
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new StringBuilder();

            //loop thru each byte of the hashed data and format 
            // with hex 
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            
            //return stringbuilder's hex string
            return sb.ToString().Trim();
            
        }

        //TODO VERIFYHASH

        



    }
}
