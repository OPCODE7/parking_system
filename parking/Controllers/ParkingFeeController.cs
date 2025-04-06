using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.DTO;
using parking.Models;

namespace parking.Controllers
{
    internal class ParkingFeeController: DataBaseController
    {
        private PARKINGEntities db;
        private Helpers.Helpers h;
        public ParkingFeeController() {
            h = new Helpers.Helpers();
        }

        public IEnumerable<ParkingFeeDTO> getParkingFees(string searchFilter, bool isDel = false)
        {
            IEnumerable<ParkingFeeDTO> parkingFees = new List<ParkingFeeDTO>();

            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from pf in db.PARKING_FEE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                join u in db.USERS on pf.USER_CODE equals u.USER_CODE
                                where (string.IsNullOrEmpty(searchFilter) ?
                                       pf.IS_DEL == isDel :
                                       (pt.DESCRIPTION_PARKING_TYPE.Contains(searchFilter) ||
                                       pf.PRICE_FOR_HOUR.ToString().Contains(searchFilter)) &&
                                       pf.IS_DEL == isDel)
                                select new ParkingFeeDTO
                                {
                                    PARKING_FEE_CODE = pf.PARKING_FEE_CODE,
                                    DESCRIPTION_PARKING_TYPE = pt.DESCRIPTION_PARKING_TYPE,
                                    PARKING_TYPE_CODE = pf.PARKING_TYPE_CODE,
                                    PRICE_FOR_HOUR = pf.PRICE_FOR_HOUR,
                                    INSERTED_AT = pf.INSERTED_AT,
                                    IS_DEL = pf.IS_DEL,
                                    USER_CODE = u.USER_CODE,
                                    USER_NAME = u.USER_NAME
                                };

                    parkingFees = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
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
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
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
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
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
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
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
                    if(HasReferences(db,db.PARKING_SPACE,e => e.PARKING_FEE_CODE == pf.PARKING_FEE_CODE))
                    {
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;
                    }
                    db.PARKING_FEE.Attach(pf);
                    db.PARKING_FEE.Remove(pf);
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
