using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobals
{
    public class Global
    {

        //TODO - info for the connection and connection types
        public static string DB = string.Empty;
        public static string serverName = "(local)"; //test server TSQL
        public static string serverInstance = "MSSQLSERVER";
        public static string tableName = "tbl_login";
        public static string dbName = "loginTest";


        //function variables
        public static bool LoggedIn = false;



        //SQL credentials
        public static string SqlUserId = "sa";
        public static string SqlPass = "JakErs4246";

        //Connection string
        //TODO
        //public static string conn = @"Data source=" + @serverName + @"\" + @serverInstance + ";" + "Integrated Security=False; Initial Catalog=" + @DBName + "; " + "user Id=" + @SqlUserID + "; " + "password=" + @SqlPass + ";";
        public static string conn = @"Server=" + serverName + "; Database=" + dbName + "; Integrated Security=False;" + "user Id=" + SqlUserId + "; " + "Password=" + @SqlPass + ";";


    }
}
