using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace LoginLib
{
    public class Login
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

        //This is for using a username and password on frmLogin.
        public static bool SelectLogin(string cnnString, string username, string password, string tableName, int timeout = 15)
        {
            using (SqlConnection conn = new SqlConnection(cnnString))
            {
                bool isLoggedIn = false;
                using (SqlDataAdapter da = new SqlDataAdapter())
                {

                    try
                    {
                        conn.Open();
                        da.SelectCommand = new SqlCommand()
                        {
                            Connection = conn,
                            CommandText = "SELECT username, password FROM " + @tableName + "WHERE username =" + @username + " AND password =" + @password + ";",
                            CommandTimeout = timeout

                        };
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows[0]["username"].ToString().Trim() == username && dt.Rows[0]["password"].ToString().Trim() == password)
                        {
                            Login.SetLogin(cnnString, username, password, tableName);
                            //after this completes, this method will finish then btnLogin_Click method continues to run
                        }
                    }
                    catch (Exception ex)
                    {
                        isLoggedIn = false;
                        //lblStatus.Text = "Cannot connect.\n" + ex.Message;
                    }

                    return isLoggedIn;
                }

            }
        }

        //only use SetIsLoggedIn with SelectLogin
        public static bool SetLogin(string cnnString, string username, string password, string tableName, int timeout = 15)
        {
            
            using (SqlConnection conn = new SqlConnection(cnnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    try
                    {
                        conn.Open();
                        da.SelectCommand = new SqlCommand()
                        {
                            Connection = conn,
                            CommandText = "UPDATE " + tableName + " SET [isLoggedIn] = 1;",
                            CommandTimeout = timeout
                             
                        };

                    }
                    

                    catch (Exception ex)
                    {
                        //we want the method to return false if it fails
                        return false;
                        //propagate the Exception to the method that calls this method
                        throw;
                    }

                    return true;
                }
            }

           
        }
        


        public static bool SetLogout(string cnnString, string tableName, int timeout = 15)
        {
            using (SqlConnection conn = new SqlConnection(cnnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    try
                    {
                        conn.Open();
                        da.SelectCommand = new SqlCommand()
                        {
                            Connection = conn,
                            CommandText = "UPDATE " + tableName + " SET [isLoggedIn] = 0;",
                            CommandTimeout = timeout
                        };
                    }

                    catch (Exception ex)
                    {
                        //propagate to the method that calls this method
                        return false;
                        throw;
                    }


                    return true;
                }
            }
        }










    }
}





        
 
