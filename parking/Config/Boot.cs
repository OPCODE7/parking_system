using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Configuration;
using System.Security.AccessControl;
using parking.Controllers;
using parking.Models;
using parking.Helpers;


namespace parking.Config
{
    internal class Boot
    {
        Helpers.Helpers h = new Helpers.Helpers();
        SystemLicense sl = new SystemLicense();
        SystemLicenseController slc = new SystemLicenseController();
        PasswordHasher hasher= new PasswordHasher();


        string query;
        public static string path = @"C:\Program Files\SystemHidden\parking.accdb";

        OleDbConnection connectionAccessDB = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Jet OLEDB:Database Password=opcode_7;");
        OleDbDataReader reader;
        OleDbCommand command;

        /// <summary>
        /// Verifica si el archivo especificado existe en la ruta proporcionada.
        /// </summary>
        /// <param name="path">Ruta completa del archivo a verificar.</param>
        /// <returns>
        /// Devuelve <c>true</c> si el archivo existe; de lo contrario, muestra un mensaje de error, 
        /// cierra la aplicación y devuelve <c>false</c>.
        /// </returns>
        private bool CheckFileExist(string path)
        {
            bool flag = true;
            if (!File.Exists(path))
            {
                h.MsgError(Helpers.App.Msg0021);
                Application.Exit();
                flag = false;
            }

            return flag;
        }


        /// <summary>
        /// Lee los datos de configuración del archivo Access especificado y asigna los valores al entorno de conexión.
        /// </summary>
        public bool ReadFileData()
        {
            bool exist = CheckFileExist(path);
            bool containsData = false;
            if (exist)
            {
                try
                {
                    command = new OleDbCommand("SELECT * FROM SERVER_PARKING", connectionAccessDB);

                    connectionAccessDB.Open();

                    reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        h.MsgWarning(Helpers.App.Msg0020);
                        containsData = false;
                    }
                    else
                    {
                        containsData = true;
                        Env.SERVER = reader["SERVER"].ToString();
                        Env.DBNAME = reader["DBNAME"].ToString();
                        Env.USERDB = reader["USERNAME"].ToString();
                        Env.PWD = reader["PWD"].ToString();
                        setEfConnection();

                    }


                    reader.Close();
                    command.Dispose();
                    connectionAccessDB.Close();

                }
                catch (OleDbException error)
                {
                    h.MsgError("ERROR INESPERADO: " + error.ToString().ToUpper());
                }
            }
            return containsData;
        }


        /// <summary>
        /// Configura dinámicamente las cadenas de conexión para Entity Framework y ADO.NET 
        /// en el archivo de configuración de la aplicación, utilizando los valores actuales del entorno (<see cref="Env"/>).
        /// </summary>
        public void setEfConnection()
        {
            string efConnectionString = $@"metadata=res://*/Models.DataBase.csdl|res://*/Models.DataBase.ssdl|res://*/Models.DataBase.msl;
provider=System.Data.SqlClient;
provider connection string='data source={Env.SERVER};initial catalog={Env.DBNAME};user id={Env.USERDB};password={Env.PWD};
trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework'";

            string sqlConnectionString = $@"Data Source={Env.SERVER};Initial Catalog={Env.DBNAME};
Persist Security Info=True;User ID={Env.USERDB};Password={Env.PWD};Encrypt=True;TrustServerCertificate=True";

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connStrings = config.ConnectionStrings.ConnectionStrings;

            // PARKINGEntities (Entity Framework)
            if (connStrings["PARKINGEntities"] != null)
            {
                connStrings["PARKINGEntities"].ConnectionString = efConnectionString;
            }
            else
            {
                connStrings.Add(new ConnectionStringSettings("PARKINGEntities", efConnectionString, "System.Data.EntityClient"));
            }

            // PARKINGConnectionString (por si se necesita)
            if (connStrings["parking.Properties.Settings.PARKINGConnectionString"] != null)
            {
                connStrings["parking.Properties.Settings.PARKINGConnectionString"].ConnectionString = sqlConnectionString;
            }
            else
            {
                connStrings.Add(new ConnectionStringSettings("parking.Properties.Settings.PARKINGConnectionString", sqlConnectionString, "System.Data.SqlClient"));
            }

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Inserta un nuevo registro en la tabla especificada de la base de datos Access usando los campos y valores proporcionados.
        /// </summary>
        /// <param name="table">Nombre de la tabla en la que se insertarán los datos.</param>
        /// <param name="fields">Cadena con los nombres de los campos separados por comas.</param>
        /// <param name="values">Cadena con los valores correspondientes a insertar, en el mismo orden que los campos.</param>
        /// <returns>
        /// Devuelve el número de filas afectadas por la operación <c>INSERT</c>. 
        /// Si ocurre un error, se muestra un mensaje y se devuelve <c>0</c>.
        /// </returns>
        public int saveConfigurationData(string table, string fields, string values)
        {

            int ra = 0;
            try
            {

                query = "INSERT INTO " + table + "(" + fields + ") VALUES(" + values + ")";
                command = new OleDbCommand(query, connectionAccessDB);
                connectionAccessDB.Open();
                ra = command.ExecuteNonQuery();

                command.Dispose();
                connectionAccessDB.Close();

            }
            catch (OleDbException error)
            {
                h.MsgError("ERROR INESPERADO: " + error.Message.ToUpper());
            }

            return ra;
        }

        /// <summary>
        /// Actualiza los datos de conexión en la tabla especificada de la base de datos Access.
        /// </summary>
        /// <param name="table">Nombre de la tabla a actualizar.</param>
        /// <param name="server">Nombre del servidor de base de datos.</param>
        /// <param name="dbname">Nombre de la base de datos.</param>
        /// <param name="user">Nombre de usuario para la conexión.</param>
        /// <param name="pwd">Contraseña del usuario para la conexión.</param>
        /// <returns>
        /// Número de filas afectadas por la operación <c>UPDATE</c>. Si ocurre un error, devuelve <c>0</c>.
        /// </returns>
        public int updateConfigurationData(string table, string server, string dbname, string user, string pwd)
        {

            int ra = 0;
            try
            {

                query = $"UPDATE {table} SET SERVER='{server}',DBNAME= '{dbname}',USERNAME='{user}',PWD='{pwd}'";
                command = new OleDbCommand(query, connectionAccessDB);
                connectionAccessDB.Open();
                ra = command.ExecuteNonQuery();

                command.Dispose();
                connectionAccessDB.Close();

            }
            catch (OleDbException error)
            {
                h.MsgError("ERROR INESPERADO: " + error.Message.ToUpper());
            }

            return ra;
        }


        /// <summary>
        /// Verifica si se puede establecer una conexión exitosa con la base de datos SQL Server utilizando la cadena de conexión proporcionada.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a evaluar.</param>
        /// <returns>
        /// <c>true</c> si la conexión es exitosa; de lo contrario, <c>false</c>.
        /// </returns>
        public bool TestConnection(string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Inicializa la aplicación validando la licencia del sistema, leyendo la configuración del archivo de base de datos 
        /// y verificando la conexión al servidor SQL. En función del resultado, abre la pantalla de inicio de sesión o la configuración del servidor.
        /// </summary>
        public void initApp()
        {
            SYSTEM_LICENSE systemL= slc.getSystemLicense();
            string serialNumber= sl.GetMotherboardSerial();

            h.MsgInfo("Obteniendo serie de placa...");
            
            if (serialNumber == null)
            {
                h.MsgError("ERROR INESPERADO NO SE PUDO INICIAR LA APLICACIÓN");
                Application.Exit();
                return;
            }

            h.MsgInfo("Serie de placa obtenida: " + serialNumber);

            h.MsgInfo("Verificando licencia del sistema...");

            if (systemL != null && !hasher.VerifyPassword(serialNumber,systemL.MACHINE_SIGNATURE))
            {
                h.MsgError("ERROR INESPERADO NO SE PUDO INICIAR LA APLICACIÓN");
                Application.Exit();
                return;
            }

            h.MsgInfo("Licencia del sistema verificada correctamente.");

            

            if (systemL == null) {
                SYSTEM_LICENSE newSL = new SYSTEM_LICENSE
                {
                    MACHINE_SIGNATURE = hasher.MakeHash(serialNumber),
                    INSERTED_AT = DateTime.Now
                };

                if (slc.saveSystemLicense(newSL) == 0) {
                    Application.Exit();
                    return;
                }
                
            }

            h.MsgInfo("Leyendo archivo de configuración...");

            if (ReadFileData())
            {
                string connectionString = $"Server={Env.SERVER};Database={Env.DBNAME};User Id={Env.USERDB};Password={Env.PWD};";

                if (!TestConnection(connectionString))
                {
                    h.MsgError(Helpers.App.Msg0022);
                    Application.Run(new Views.Administration.Configuration.FrmServerConfig());
                }
                else
                {
                    Application.Run(new Views.Auth.Login());
                }
            }
            else
            {
                Application.Run(new Views.Administration.Configuration.FrmServerConfig());
            }
        }
    }
}
