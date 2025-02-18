using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class ParkingFeeController
    {
        private PARKINGEntities db;
        private Helpers.Helpers h;
        public ParkingFeeController() {
            h = new Helpers.Helpers();
        }
        
        public IEnumerable<dynamic> getParkingFees(string searchFilter)
        {
            IEnumerable<dynamic> parkingFees= new List<PARKING_FEE>();

            try
            {
                using (db = new PARKINGEntities())
                {
                    var query= from pf in db.PARKING_FEE
                               join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                               join u in db.USERS on pf.USER_CODE equals u.USER_CODE
                               select new
                               {
                                   pf.PARKING_FEE_CODE,
                                   pt.DESCRIPTION_PARKING_TYPE,
                                   pf.PRICE_FOR_HOUR,
                                   pf.INSERTED_AT,
                                   pf.IS_DEL,
                                   u.USER_CODE,
                                   u.USER_NAME
                               };
                    parkingFees = string.IsNullOrEmpty(searchFilter) ?
                        query.ToList().Where(pf => pf.IS_DEL==false) :
                        query.ToList().Where(pf => pf.IS_DEL == false && (pf.DESCRIPTION_PARKING_TYPE.Contains(searchFilter) || pf.PRICE_FOR_HOUR.ToString().Contains(searchFilter)));
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return parkingFees;
        }

        public PARKING_FEE getParkingFee(string id)
        {
            PARKING_FEE parkingFee = new PARKING_FEE();
            try
            {
                using (db= new PARKINGEntities())
                {
                    parkingFee= db.PARKING_FEE.Find(id);
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return parkingFee;

        }

        public int saveParkingFee(PARKING_FEE pf)
        {
            int result= 0;
            try
            {
                using (db = new PARKINGEntities())
                {
                    db.PARKING_FEE.Add(pf);
                    result = db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int updateParkingFee(PARKING_FEE pf)
        {
            int result= 0;
            try
            {
                using (db = new PARKINGEntities())
                {
                    db.Entry(pf).State= System.Data.Entity.EntityState.Modified;
                    result= db.SaveChanges();

                }
            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }


        public int deleteParkingFee(PARKING_FEE pf)
        {
            int result= 0;
            try
            {
                using (db = new PARKINGEntities())
                {
                    db.PARKING_FEE.Attach(pf);
                    db.PARKING_FEE.Remove(pf);
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
