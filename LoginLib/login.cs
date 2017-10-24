using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LoginLib
{
    public class login
    {

        public static DataTable GetLogin(string cnnString, string loginSelect, int timeout = 20)
        {
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                cnn.ConnectionString = cnnString;

                da.SelectCommand = new SqlCommand()
                {
                    Connection = cnn,
                    CommandText = loginSelect,
                    CommandTimeout = timeout
                };

                da.Fill(ds, "GetLogin");

                return ds.Tables["GetLogin"];
            }
        }

        public static bool SelectLogin(string cnnString, string username, string password, string loginSelect, int timeout = 20)
        {
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cnn.ConnectionString = cnnString;
                bool isLoggedIn = false;

                try
                {
                    da.SelectCommand = new SqlCommand()
                    {
                        Connection = cnn,
                        CommandText = "SELECT username, password FROM loginTest WHERE username=" + username + ", password=" + password + ";",
                        CommandTimeout = timeout
                    };
                }
                catch (Exception ex)
                {
                    isLoggedIn = false;
                    //TODO
                }

                return isLoggedIn;
            }
        }

        


    }
}
