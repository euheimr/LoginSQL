using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Global
    {

        //TODO - info for the connection and connection types
        public static string DB = string.Empty;
        public static string serverIP = "betz.database.windows.net"; //test server TSQL
        public static string serverInstance = string.Empty;
        public static string DBName = string.Empty;


        //Connection string
        //TODO
        public static string cs = @"Data source=" + serverIP + @"\" + serverInstance + ";" + "Integrated Security=False;" + DBName + ";";


    }
}
