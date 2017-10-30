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



        public static void HashPassword(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMD5Hash(md5Hash, password);

            }
        }
        


        public static string GetMD5Hash(MD5 md5Hash, string password)
        {
            //create the hash
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new StringBuilder();

            //loop thru each byte of the hashed data and format 
            // with hex 
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x4"));
            }

            //return stringbuilder's hex string
            return sb.ToString();
            
        }

        
        
        



    }
}
