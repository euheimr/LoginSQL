using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AppGlobals;
using System.Security.Cryptography;
using PasswordHash;

namespace LoginLib
{
    public class Login
    {
        //Testing for SelectLogin's datatable row count
        public static string rowCount;


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
                
                using (SqlDataAdapter da = new SqlDataAdapter())
                {

                    try
                    {
                        if (!Global.LoggedIn)
                        {
                            //TODO
                            // get password from this method's "password" parameter, then hash it
                            using (MD5 md5Hash = MD5.Create())
                            {
                                Global.usrPass = Hash.GetMD5Hash(password);

                                conn.Open();
                                da.SelectCommand = new SqlCommand()
                                {
                                    //send all that info to see if the server finds it
                                    Connection = conn,
                                    CommandText = @"SELECT username, password FROM " + tableName + " WHERE username = '" + username.Trim() + "' AND password = '" + Global.usrPass.Trim() + "'; " +
                                    @"SELECT username, password FROM " + tableName + " WHERE username = '" + username.Trim() + "' AND password = '" + password.Trim() + "'; " +
                                    //update the isLoggedIn field on this selected username
                                    "UPDATE " + tableName + " SET [isLoggedIn] = 1;",
                                    CommandTimeout = timeout

                                };

                                
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                //This is to test if there are rows in dt, changes the variable declared at the top of this library
                                rowCount = dt.Rows.Count.ToString();

                            }
                            
                            

                            
                            
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        //TODO create an invalid record Exception


                        Global.LoggedIn = false;
                        //lblStatus.Text = "Cannot connect.\n" + ex.Message;
                        throw;
                    }

                    return Global.LoggedIn;
                }

            }
        }
      


        public static bool SetLogout(string cnnString, string username, string password, string tableName, int timeout = 15)
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
                            CommandText = @"SELECT username, password FROM " + tableName + " WHERE username = '" + username.Trim() + "' AND password = '" + password.Trim() + "'; " +
                                @"SELECT username, password FROM " + tableName + " WHERE username = '" + username.Trim() + "' AND password = '" + password.Trim() + "'; " +
                            "UPDATE " + tableName + " SET [isLoggedIn] = 0;",
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

        //this is used for the btntCreateHash, returns a password in a desired textbox
        public static string CreateHash(string password)
        {
            using (MD5 md5Hash = MD5.Create(password))
            {
                //Encode
                Global.usrPass = Hash.GetMD5Hash(password);
            }

                return Global.usrPass;
        }







    }
}





        
 
