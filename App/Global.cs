using System;
using System.Collections.Generic;

namespace AppGlobals
{
    public class Global
    {
        /// <summary>
        /// local MSSQL globals
        /// </summary>
        //local SQL test server
        public static string DB = string.Empty;
        public static string serverName = "(local)"; //test server MSSQL
        public static string serverInstance = "MSSQLSERVER";
        public static string tableName = "tbl_login";
        public static string dbName = "loginTest";
        //local SQL credentials
        public static string SqlUserId = "test";
        public static string SqlPass = "public";

        /// <summary>
        /// frequently changing globals
        /// </summary>
        public static bool LoggedIn = false;
        public static string usrAcc;
        public static string usrPass;
        
        /// <summary>
        /// Live server globals
        /// </summary>
        //live TSQL DB
        public static string liveServerName = @"tcp:euheimr.database.windows.net:1433";
        public static string liveDBName = @"betz";
        public static string liveUsrID = @"pubLoginSqlApp";
        public static string liveUsrPwd = @"4c9184f37cff01bcdc32dc486ec36961!QAZ" + "";

        //local server connection string
        public static string conn = @"Server=" + serverName + "; Database=" + dbName + "; Integrated Security=False;" + "user Id=" + SqlUserId + "; " + "Password=" + @SqlPass + ";";
        
        //live string, change connLive -> conn to go live
        public static string connLive = liveServerName + ";" + " Initial Catalog = " + liveDBName + ";" + " Persist Security Info=False;" + " User ID = " + liveUsrID + "; Password= " + liveUsrPwd + ";" +
            " MultipleActiveResultSets = False; Encrypt=True; TrustServerCertificate=False;";
    }; 

}

