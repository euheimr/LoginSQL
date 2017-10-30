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
                                string pwd = Hash.GetMD5Hash(password);
                                Global.usrPass = pwd;

                                conn.Open();
                                da.SelectCommand = new SqlCommand()
                                {
                                    //send all that info to see if the server finds it
                                    Connection = conn,
                                    CommandText = @"SELECT username, password FROM " + tableName + " WHERE username = '" + username.Trim() + "' AND password = '" + pwd + "'; " +
                                    //update the isLoggedIn field on this selected username
                                    "UPDATE " + tableName + " SET [isLoggedIn] = 1;",
                                    CommandTimeout = timeout

                                };
                                //set the global
                                
                                
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
                    if (Global.LoggedIn)
                    {
                        try
                        {
                            //makes sure that the username and password matches the data pulled from the DB
                            if (ValidLogin(username, password))
                            {
                                conn.Open();
                                da.SelectCommand = new SqlCommand()
                                {
                                    //send all that info to see if the server finds it
                                    Connection = conn,
                                    //update the isLoggedIn field on this selected username
                                    CommandText = @"UPDATE " + tableName + " SET isLoggedIn = 0 WHERE username = " + "'" + username + "'" + " AND password = " + "'" + Global.usrPass + "'" + "; ",
                                    CommandTimeout = timeout
                                };
                                Global.LoggedIn = false;
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            //propagate to the method that calls this method
                            return Global.LoggedIn;
                            throw;
                        }
                        
                    }
                    
                }
                
            }
            
            return Global.LoggedIn;
        }
        

        public static bool ValidLogin(string username, string password)
        {

            try
            {
                if (username.Trim() == Global.usrAcc)
                {
                    return false;
                }
                else if (password == Global.usrPass)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }







    }
}





        
 
