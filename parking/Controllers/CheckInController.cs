using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class CheckInController
    {
        private Helpers.Helpers h;

        public CheckInController()
        {
            h = new Helpers.Helpers();
        }

        public IEnumerable<dynamic> getCheckIns(string searchFilter)
        {
            IEnumerable<dynamic> checkIns = new List<CHECK_IN>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    
                    var query = from c in db.CHECK_IN
                                join ps in db.PARKING_SPACE on c.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE where String.IsNullOrEmpty(searchFilter) ? c.IS_DEL == false : c.CLIENT_DNI.Contains(searchFilter) || c.VEHICLE_PLATE.Contains(searchFilter) || c.OBSERVATIONS.Contains(searchFilter) || c.CHECK_IN_CODE.Contains(searchFilter) || c.CHECK_IN_STATE.Contains(searchFilter) || pt.DESCRIPTION_PARKING_TYPE.Contains(searchFilter) || ps.PARKING_SPACE_NUMBER.ToString().Contains(searchFilter) || c.CHECK_IN_TIME.ToString().Contains(searchFilter) 
                               select new
                               {
                                   c.CHECK_IN_CODE,
                                   c.CLIENT_DNI,
                                   c.OBSERVATIONS,
                                   c.VEHICLE_PLATE,
                                   c.CHECK_IN_TIME,
                                   c.PARKING_SPACE_CODE,
                                   ps.PARKING_SPACE_NUMBER,
                                   pt.DESCRIPTION_PARKING_TYPE,
                                   c.INSERTED_AT,
                                   c.CHECK_IN_STATE,
                                   c.IS_DEL,
                                   c.USER_CODE
                               };
                    checkIns = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return checkIns;
        }

        public dynamic getCheckIn(string checkInCode)
        {
            dynamic checkIn = new CHECK_IN();
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    var query = from c in db.CHECK_IN
                                join ps in db.PARKING_SPACE on c.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                where c.IS_DEL==false && c.CHECK_IN_CODE==checkInCode
                                select new
                                {
                                    c.CHECK_IN_CODE,
                                    c.CLIENT_DNI,
                                    c.OBSERVATIONS,
                                    c.VEHICLE_PLATE,
                                    c.CHECK_IN_TIME,
                                    c.PARKING_SPACE_CODE,
                                    ps.PARKING_SPACE_NUMBER,
                                    pt.DESCRIPTION_PARKING_TYPE,
                                    pf.PARKING_FEE_CODE,
                                    pf.PRICE_FOR_HOUR,
                                    c.INSERTED_AT,
                                    c.CHECK_IN_STATE,
                                    c.IS_DEL,
                                    c.USER_CODE
                                };

                    checkIn = query.FirstOrDefault();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return checkIn;

        }

        public int saveCheckIn(CHECK_IN checkIn)
        {
            int result = 0;

            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {

                   db.CHECK_IN.Add(checkIn);
                   result = db.SaveChanges();
                }
            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int updateCheckIn(CHECK_IN checkIn) { 
            int result = 0;
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    db.Entry(checkIn).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int deleteCheckIn(CHECK_IN checkIn)
        {
            int result = 0;
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    db.Entry(checkIn).State = System.Data.Entity.EntityState.Deleted;
                    result = db.SaveChanges();
                }
            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }
    }
}
