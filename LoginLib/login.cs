using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using AppGlobals;
using PasswordHash;

///                 TODO:
///                 
/// -Create method to check for existing login
/// -Add a DateTime parameter for all SQL logins
/// -Optionally add a message
/// -Hit [random] button for a random message
/// -create a filter
///


namespace LoginLib
{
    public class Login
    {
        

        //method for logging into the SQL DB
        public static DataTable GetLogin(string cnnString, string loginSelect, int timeout = 10)
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
            try
            {
                using (SqlConnection conn = new SqlConnection(cnnString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        if (!Global.LoggedIn)
                        {
                            //TODO
                            // get password from this method's "password" parameter, then hash it
                            using (MD5 md5Hash = MD5.Create())
                            {
                                string pwd = Hash.GetMD5Hash(password);
                                Global.usrPass = pwd;

                                try
                                {
                                    conn.Open();
                                    da.SelectCommand = new SqlCommand()
                                    {
                                        //send all that info to see if the server finds it
                                        Connection = conn,
                                        CommandText = @"SELECT username, password FROM " + tableName + " WHERE username = '" + username.Trim() + "' AND password = '" + pwd + "'; ",
                                        CommandTimeout = timeout
                                    };
                                    conn.Close();
                                    //fill the datatable with the data that was returned from SELECT
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);
                                    //This is to test if there are rows in dt, changes the variable declared at the top of this library
                                    //this is then used below for the if statement
                                    Global.rowCount = dt.Rows.Count.ToString();

                                    //get current date & time, this is then put into the database as the last time logged in
                                    string dateTimeLog = DateTime.Now.ToString();

                                    if (Global.rowCount == "1")
                                    {
                                        conn.Open();
                                        da.SelectCommand = new SqlCommand()
                                        {
                                            Connection = conn,
                                            //update the isLoggedIn field on this selected username
                                            CommandText = @"UPDATE " + tableName + " SET isLoggedIn=1, [lastLogout]='"+ dateTimeLog.ToString() +"' WHERE username = '" + username + "';",
                                            CommandTimeout = timeout
                                        };
                                        conn.Close();
                                        DataTable dt2 = new DataTable();
                                        da.Fill(dt2);

                                    }
                                    else if (Global.rowCount == "0")
                                    {
                                        // :thinking:
                                    }
                                    else
                                    {
                                        //
                                    }


                                    
                                }
                                catch (SqlException SqlEx)
                                {
                                    //if we run into an issue, we don't want the program to think we are logged in
                                    Global.LoggedIn = false;
                                    throw SqlEx;
                                }
                                catch (Exception ex)
                                {
                                    Global.LoggedIn = false;
                                    throw ex;
                                }

                            }
                        }
                    }
                }
            }

            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }


            catch (Exception ex)
            {
                //toss this to the calling method to handle the exceptions
                throw ex;
            }

            return Global.LoggedIn;
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
                    else
                    {
                        return false;
                    }
                    
                }
                
            }
            
            Global.rowCount = "0";

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
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idKey"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isLoggedIn"></param>
        /// <param name="timeout"></param>
        public static void CreateLogin(string tableName, string username, string password, byte isLoggedIn = 0, int timeout = 15)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Global.conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        
                        conn.Open();
                        //RUN IT
                        da.SelectCommand = new SqlCommand()
                        {
                            Connection = conn,
                            CommandText = @"INSERT INTO " + tableName + " (username, password, isLoggedIn) VALUES " + "('" + username.Trim() + "'," +
                            "'" + password.Trim() + "'," + isLoggedIn + ");",
                            CommandTimeout = timeout
                        };
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        

                    }
                }
            }
            catch (SqlException SqlEx)
            {
                //cash me outside, how bout dat?
                throw SqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        

        public static bool CheckAuthPass(string authPass, int timeout = 15)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Global.conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        conn.Open();
                        da.SelectCommand = new SqlCommand()
                        {
                            Connection = conn,
                            CommandText = @"SELECT authPass FROM " + Global.tblAuth + " WHERE authPass='" + authPass + "';",
                            CommandTimeout = timeout
                        };
                        conn.Close();
                        DataTable dt = new DataTable();
                        da.Fill(dt);


                        if (dt.Rows.Count == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckUsername(string username, int timeout = 15)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Global.conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        conn.Open();
                        da.SelectCommand = new SqlCommand()
                        {
                            Connection = conn,
                            CommandText = "SELECT username FROM " + Global.tblLogins + " WHERE username='" + username + "';",
                            CommandTimeout = timeout
                        };
                        conn.Close();
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            return true;
                        }
                        else
                        {
                            //don't make a duplicate login
                            return false;
                        }

                    }
                }
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}





        
 
