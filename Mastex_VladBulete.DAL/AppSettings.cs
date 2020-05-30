using System;
using System.Collections.Generic;
using System.Text;

namespace Mastex_VladBulete.DAL
{
    public static class AppSettings
    {
        private static string DatabaseConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Mastex_App;Trusted_Connection=True;";
        public static string GetConnectionString() 
        {
            return DatabaseConnectionString;
        }
    }
}
