using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.Models;


namespace parking.Controllers
{
    internal class CorrelativesController
    {
        private CORRELATIVES correlativesModel;
        Helpers.Helpers h = new Helpers.Helpers();
        public CorrelativesController() { 
           
            correlativesModel= new CORRELATIVES();
        }

        public CORRELATIVES getCorrelative(int correlativeId)
        {
            CORRELATIVES correlative = new CORRELATIVES();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    correlative = db.CORRELATIVES.FirstOrDefault(c=> c.CORRELATIVE_CODE==correlativeId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return correlative;

        }

        public string getNextId(string idMod) {
            string nextId = "";

            try
            {
                Int64 x = 0;
                using (PARKINGEntities db = new PARKINGEntities())
                {

                    var correlatives = db.CORRELATIVES.Where(c => c.MODULE_ID == idMod).FirstOrDefault();
                    if (correlatives != null)
                    {
                       
                        x = Convert.ToInt64(correlatives.CORRELATIVE_COUNTER + 1);
                    }
                    else
                    {
                        h.MsgError("Error al generar el identificador.");
                    }

                }


                if (x >= 0 && x <= 9)
                {
                    nextId = "00000" + x.ToString();
                }
                else if (x >= 9 && x <= 99)
                {
                    nextId = "0000" + x.ToString();
                }
                else if (x >= 100 && x <= 999)
                {
                    nextId = "000" + x.ToString();

                }
                else if (x >= 1000 && x <= 9999)
                {
                    nextId = "00" + x.ToString();
                }
                else if (x >= 10000 && x <= 99999)
                {
                    nextId = "0" + x.ToString();
                }
                else if (x >= 100000 && x <= 999999)
                {
                    nextId = x.ToString();

                }
                else
                {
                    h.MsgWarning("Ha llegado al limite, contactar con el administrador.");
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return nextId;
        }
    }
}
