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

            try
            {
                Config.Boot boot = new Config.Boot();
                boot.initApp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fatal: " + ex.Message + "\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.WriteAllText("error_log.txt", ex.ToString());
            }
        }
    }
}
