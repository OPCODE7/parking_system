using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking
{
    internal class Env
    {
        public static string SERVER;
        public static string DBNAME;
        public static string USERDB;
        public static string PWD;


        public static bool containsData()
        {
            string[] data = new string[4] { DBNAME, SERVER, USERDB, PWD };

            return data.All(element => element != null) ? true : false;
        }

    }
}
