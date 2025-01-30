using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public HORARY getHorary(string id)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    horary = db.HORARY.Find(id);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }
            return horary;
            
        }


        public int saveHorary(HORARY horary)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.HORARY.Add(horary);
                    result= db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int updateHorary(HORARY horary)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(horary).State = EntityState.Modified;
                    result = db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int deleteHorary(HORARY horary)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.HORARY.Attach(horary);
                    db.HORARY.Remove(horary);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }
    }
}
