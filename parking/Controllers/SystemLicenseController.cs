using parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Controllers
{
    internal class SystemLicenseController
    {
        private Helpers.Helpers h;

        public SystemLicenseController()
        {
            h = new Helpers.Helpers();
        }

        public SYSTEM_LICENSE getSystemLicense()
        {
            SYSTEM_LICENSE sl = new SYSTEM_LICENSE();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    sl = db.SYSTEM_LICENSE.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return sl;
        }

        public int saveSystemLicense(SYSTEM_LICENSE sl)
        {
            int result = 0;

            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    db.SYSTEM_LICENSE.Add(sl);
                    result = db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());

            }
            return result;

        }

    }
}
