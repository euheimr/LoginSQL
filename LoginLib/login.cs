using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using AppGlobals;
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
                                //fill the datatable with the data that was returned from SELECT
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                //This is to test if there are rows in dt, changes the variable declared at the top of this library
                                rowCount = dt.Rows.Count.ToString();

                            }
                            
                            
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        //if we run into an issue, we don't want the program to think we are logged in
                        Global.LoggedIn = false;
                        //toss this to the calling method to handle the exceptions
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
                                    CommandText = @"UPDATE " + tableName + " SET isLoggedIn=0 WHERE username = '" + username + "';",
                                    CommandTimeout = timeout
                                };
                                //fill the datatable with the data that was returned from the Data adapter
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                Global.LoggedIn = false;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        catch (SqlException SqlEx)
                        {
                            //send to frmMain
                            throw SqlEx;
                        }

                        catch (Exception ex)
                        {
                            //propagate to the method that calls this method
                            return Global.LoggedIn;
                            throw ex;
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
                if (username.Trim() == Global.usrAcc && password == Global.usrPass)
                {
                    return true;
                }
                else
                {
                    //if both or either do not match, return false (login is invalid)
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }







    }
}





        
 
