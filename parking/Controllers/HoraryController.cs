using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class HoraryController: DataBaseController
    {
        private HORARY horary;
        Helpers.Helpers h = new Helpers.Helpers();
        public HoraryController()
        {
            horary = new HORARY();
        }

        public List<HORARY> getHoraries(string searchFilter,bool isDel= false)
        {
            searchFilter = searchFilter.ToLower();
            List<HORARY> horaries = new List<HORARY>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = db.HORARY.Where(h => h.IS_DEL==isDel).ToList();

                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query = query.Where(hor => hor.HORARY_CODE.ToLower().Contains(searchFilter) || hor.HORARY_DESCRIPTION.ToLower().Contains(searchFilter) || hor.INITIAL_HOUR.ToString().ToLower().Contains(searchFilter) || hor.FINAL_HOUR.ToString().ToLower().Contains(searchFilter) || h.DoesDateMatch(hor.INSERTED_AT,searchFilter)).ToList();
                    }

                    horaries = query.ToList();
                }
            }
            catch (SqlException ex )
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: "  + ex.Message.ToUpper());
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
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

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

            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
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

            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
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
                    if(HasReferences(db,db.EMPLOYEES,e=> e.HORARY_CODE == horary.HORARY_CODE))
                    {
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;
                    }

                    db.HORARY.Attach(horary);
                    db.HORARY.Remove(horary);
                    result = db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }
    }
}
