using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.Models;

namespace parking.Controllers
{
    internal class ParkingSpaceController
    {
        private PARKING_SPACE parkingSpace;
        private Helpers.Helpers h;
        public ParkingSpaceController()
        {
            parkingSpace = new PARKING_SPACE();
            h = new Helpers.Helpers();
        }

        public IEnumerable<dynamic> getParkingSpaces(string searchFilter = "")
        {
            IEnumerable<dynamic> parkingSpaces = new List<PARKING_SPACE>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from ps in db.PARKING_SPACE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE 
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                select new
                                {
                                    ps.PARKING_SPACE_CODE,
                                    ps.PARKING_SPACE_NUMBER,
                                    PARKING_STATE = ps.STATE,
                                    ps.INSERTED_AT,
                                    PARKING_TYPE_DESCRIPTION = pt.DESCRIPTION_PARKING_TYPE,
                                    IS_DEL = ps.DEL
                                };
                    parkingSpaces = string.IsNullOrEmpty(searchFilter) ?
                        query.ToList().Where(ps => ps.IS_DEL == false) :
                        query.ToList().Where(ps => (ps.PARKING_SPACE_NUMBER.ToString().Contains(searchFilter) || ps.PARKING_TYPE_DESCRIPTION.Contains(searchFilter)) && ps.IS_DEL == false);
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return parkingSpaces;
        }
        public IEnumerable<dynamic> getParkingSpacesByParkingType(string parkingType)
        {
            IEnumerable<dynamic> parkingSpaces = new List<PARKING_SPACE>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from ps in db.PARKING_SPACE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE where pt.PARKING_TYPE_CODE == parkingType where ps.DEL == false
                                select new
                                {
                                    ps.PARKING_SPACE_CODE,
                                    ps.PARKING_SPACE_NUMBER,
                                    IS_DEL = ps.DEL
                                };
                    parkingSpaces = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return parkingSpaces;
        }


        public dynamic getParkingSpace(string id)
        {
            dynamic psp = new PARKING_SPACE();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query= from ps in db.PARKING_SPACE join
                               pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                 join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                 where ps.PARKING_SPACE_CODE == id
                                 select new
                                 {
                                      ps.PARKING_SPACE_CODE,
                                      ps.PARKING_SPACE_NUMBER,
                                      ps.PARKING_FEE_CODE,
                                      pf.PRICE_FOR_HOUR,
                                      ps.STATE,
                                      ps.INSERTED_AT,
                                      pt.DESCRIPTION_PARKING_TYPE,
                                      pt.PARKING_TYPE_CODE,
                                 };

                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return psp;
        }

        public int saveParkingSpace(PARKING_SPACE ps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.PARKING_SPACE.Add(ps);
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;

        }

        public int updateParkingSpace(PARKING_SPACE ps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(ps).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int deleteParkingSpace(string id)
        {
            int result = 0;
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    PARKING_SPACE ps = db.PARKING_SPACE.Find(id);
                    db.PARKING_SPACE.Attach(ps);
                    db.PARKING_SPACE.Remove(ps);
                    result= db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }
    }
}
