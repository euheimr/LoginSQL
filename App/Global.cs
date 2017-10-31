using System;
using System.Collections.Generic;

namespace AppGlobals
{
    public class Global
    {

        //TODO - info for the connection and connection types
        public static string DB = string.Empty;
        public static string serverName = liveServerName; //test server MSSQL
        public static string serverInstance = "MSSQLSERVER";
        public static string tableName = "tbl_login";
        public static string dbName = "loginTest";




        //function variables
        public static bool LoggedIn = false;

        //user, and frequently changing strings
        public static string usrAcc;
        public static string usrPass;
        


        //SQL credentials
        public static string SqlUserId = "public";
        public static string SqlPass = "public";

        //Connection string
        //local string - test server
        //public static string conn = @"Server=" + serverName + "; Database=" + dbName + "; Integrated Security=False;" + "user Id=" + SqlUserId + "; " + "Password=" + @SqlPass + ";";

        //live TSQL DB
        public static string liveServerName = @"tcp:euheimr.database.windows.net:1433";
        public static string liveDBName = @"betz";
        public static string liveUsrID = @"pubLoginSqlApp";
        public static string liveUsrPwd = @"4c9184f37cff01bcdc32dc486ec36961!QAZ" + "";

        //live string
        public static string conn = liveServerName + ";" + " Initial Catalog = " + liveDBName + ";" + " Persist Security Info=False;" + " User ID = " + liveUsrID + "; Password= " + liveUsrPwd + ";" +
            " MultipleActiveResultSets = False; Encrypt=True; TrustServerCertificate=False;";
    }; 

}

