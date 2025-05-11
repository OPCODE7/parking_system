using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
namespace parking.Config
{
    internal class SystemLicense
    {
        private Helpers.Helpers h;
        public SystemLicense() {
            h = new Helpers.Helpers();

        }

        /// <summary>
        /// Obtiene el número de serie de la placa base (motherboard) del equipo utilizando WMI (Windows Management Instrumentation).
        /// </summary>
        /// <returns>
        /// El número de serie de la placa base como una cadena si se obtiene correctamente; de lo contrario, <c>null</c>.
        /// </returns>
        public string GetMotherboardSerial()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["SerialNumber"]?.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
                return null;
            }

            return null;
        }


    }
}
