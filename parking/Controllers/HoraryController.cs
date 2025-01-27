using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class HoraryController
    {
        private HORARY horary;
        Helpers.Helpers h = new Helpers.Helpers();
        public HoraryController()
        {
            horary = new HORARY();
        }

        public List<HORARY> getHoraries(string searchFilter)
        {
            List<HORARY> horaries = new List<HORARY>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        horaries = db.HORARY.Where(hor => hor.HORARY_DESCRIPTION.Contains(searchFilter) && hor.IS_DEL == false).ToList();
                    }
                    else
                    {
                        horaries = db.HORARY.Where(hor => hor.IS_DEL == false).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }
            return horaries;


        }


    }
}
