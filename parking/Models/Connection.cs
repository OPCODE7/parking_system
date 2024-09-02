using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Forms;

namespace parking.Models
{
    internal class Connection
    {
        static string ConnectionString = "Server= " + Env.SERVER + ";Database=" + Env.DBNAME + ";Uid= " + Env.USERDB + ";Pwd=" + Env.PWD + ";";

        //Variable de conexion a la base de datos
        public static SqlConnection ConSql = new SqlConnection(ConnectionString);

        //Metodo OpenConnection
        //Abrir la conexion a la base de datos

        public static void OpenConnection()
        {
            try
            {
                ConSql.Open();
            }
            catch (SqlException error)// una excepcion nos muestra los detalles del error surgido 
            {
                MessageBox.Show(error.Message);
            }
        }
        //Fin OpenConnection

        //Metodo CloseConnection
        //Cerrar la conexion a la base de datos
        public static void CloseConnection()
        {
            try
            {
                ConSql.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //Fin CloseConnection

        //Metodo EndsConnection
        //Forzar el cierre de la conexion a la base de datos
        public static void EndsConnection()
        {
            if (ConSql.State == ConnectionState.Open)
            {
                ConSql.Close();
            }

        }
        //Fin Metodo CloseConnection

    }

}
