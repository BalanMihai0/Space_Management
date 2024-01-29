using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public static class Database
    {
        
        private static string Server = "mssqlstud.fhict.local";
        private static string Db = "dbi501909";
        private static string UserId = "dbi501909";
        private static string Password = "paine234mamaliga";

        public static string Connection = $"Server={Server};Database={Db};User Id={UserId};Password={Password};";
    }
}
