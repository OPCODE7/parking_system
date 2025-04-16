using parking.Views.Administration;
using parking.Views.Administration.ParkingStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace parking
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config.Boot boot= new Config.Boot();
            Helpers.Helpers h = new Helpers.Helpers();
            if (boot.ReadFileData())
            {
                string connectionString = $"Server={Env.SERVER};Database={Env.DBNAME};User Id={Env.USERDB};Password={Env.PWD};";

                if (!boot.TestConnection(connectionString))
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
