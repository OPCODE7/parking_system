using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking
{
    internal class Env
    {
        //Variables de configuración par ael servidor de base de datos.
        public static string SERVER;
        public static string DBNAME;
        public static string USERDB;
        public static string PWD;

        /// <summary>
        /// Verifica si todas las variables de configuración de la conexión (base de datos, servidor, usuario y contraseña)
        /// contienen datos no nulos.
        /// </summary>
        /// <returns>
        /// <c>true</c> si todas las variables contienen datos distintos de <c>null</c>; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool containsData()
        {
            string[] data = new string[4] { DBNAME, SERVER, USERDB, PWD };

            return data.All(element => element != null) ? true : false;
        }

    }
}
