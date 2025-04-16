using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.DTO;
using parking.Models;

namespace parking.Controllers
{
    internal class CheckOutController
    {
        Helpers.Helpers h;

        public CheckOutController()
        {
            h = new Helpers.Helpers();
        }

        public IEnumerable<CheckOutDTO> getCheckOuts(string searchFilter, bool isDel = false)
        {
            IEnumerable<CheckOutDTO> checkOuts = new List<CheckOutDTO>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from cout in db.CHECK_OUT
                                join cin in db.CHECK_IN on cout.CHECK_IN_CODE equals cin.CHECK_IN_CODE
                                join ps in db.PARKING_SPACE on cin.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                where (string.IsNullOrEmpty(searchFilter) ?
                                      cout.DEL == isDel :
                                      (cout.CHECK_OUT_CODE.Contains(searchFilter) ||
                                       cout.CHECK_IN_CODE.Contains(searchFilter) ||
                                       cout.CHECK_OUT_TIME.ToString().Contains(searchFilter) ||
                                       cout.CHECK_OUT_STATE.Contains(searchFilter) ||
                                       cout.FULL_CHARGE.ToString().Contains(searchFilter)) &&
                                      cout.DEL == isDel)
                                select new CheckOutDTO
                                {
                                    CHECK_OUT_CODE = cout.CHECK_OUT_CODE,
                                    CHECK_IN_CODE = cout.CHECK_IN_CODE,
                                    CHECK_OUT_TIME = cout.CHECK_OUT_TIME,
                                    CHECK_OUT_STATE = cout.CHECK_OUT_STATE,
                                    FULL_CHARGE = cout.FULL_CHARGE,
                                    USER_CODE = cout.USER_CODE,
                                    TOTAL_TIME = cout.TOTAL_TIME,
                                    VEHICLE_PLATE = cin.VEHICLE_PLATE,
                                    PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                    DESCRIPTION_PARKING_TYPE = pt.DESCRIPTION_PARKING_TYPE
                                };

                    checkOuts = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return checkOuts;
        }


        public CheckOutDTO getInfoCheckOut(string checkOutCode)
        {
            CheckOutDTO checkOut = new CheckOutDTO();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from cout in db.CHECK_OUT
                                join cin in db.CHECK_IN on cout.CHECK_IN_CODE equals cin.CHECK_IN_CODE
                                join ps in db.PARKING_SPACE on cin.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                join cli in db.CLIENTS on cin.CLIENT_CODE equals cli.CLIENT_CODE
                                join b in db.BILL on cout.CHECK_OUT_CODE equals b.CHECK_OUT_CODE
                                where cout.CHECK_OUT_CODE == checkOutCode
                                select new CheckOutDTO
                                {
                                    CHECK_IN_CODE = cout.CHECK_IN_CODE,
                                    CLIENT_CODE = cin.CLIENT_CODE,
                                    OBSERVATIONS = cin.OBSERVATIONS,
                                    VEHICLE_PLATE = cin.VEHICLE_PLATE,
                                    CHECK_IN_TIME = cin.CHECK_IN_TIME,
                                    PARKING_SPACE_CODE = cin.PARKING_SPACE_CODE,
                                    PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                    DESCRIPTION_PARKING_TYPE = pt.DESCRIPTION_PARKING_TYPE,
                                    PARKING_FEE_CODE = pf.PARKING_FEE_CODE,
                                    PRICE_FOR_HOUR = pf.PRICE_FOR_HOUR,
                                    CHECK_OUT_TIME = cout.CHECK_OUT_TIME,
                                    CHECK_OUT_STATE = cout.CHECK_OUT_STATE,
                                    DEL = cout.DEL,
                                    USER_CODE = cout.USER_CODE,
                                    CLIENT_NAME = cli.CLIENT_NAME,
                                    CLIENT_LASTNAME = cli.CLIENT_LASTNAME,
                                    ISV = b.ISV,
                                    DATE_OF_ISSUE = b.DATE_OF_ISSUE,
                                    DISCOUNT = b.DISCOUNT,
                                    SUBTOTAL = b.SUBTOTAL,
                                    TOTAL = b.TOTAL
                                };

                    checkOut = query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return checkOut;
        }

        public CHECK_OUT getCheckOut(string id)
        {
            CHECK_OUT checkOut = new CHECK_OUT();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    checkOut = db.CHECK_OUT.Find(id);
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return checkOut;
        }
        public int saveCheckOut(CHECK_OUT checkOut)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.CHECK_OUT.Add(checkOut);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }

        public bool thisIsBilled(string checkOutCode)
        {
            bool result = false;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from b in db.BILL
                                where b.CHECK_OUT_CODE == checkOutCode
                                select b;
                    result = query.Count() > 0;
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;

        }

        public int updateCheckOut(CHECK_OUT checkOut)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(checkOut).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }

        public int deleteCheckOut(string id)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    CHECK_OUT checkOut = db.CHECK_OUT.Find(id);
                    db.CHECK_OUT.Attach(checkOut);
                    db.CHECK_OUT.Remove(checkOut);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }

        public int getTotalVisitsClient(string clientCode) 
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var totalVisitsParam
                        = new SqlParameter("@TOTAL_VISITS", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var cliCode = new SqlParameter("@CLIENT_CODE", clientCode);

                    db.Database.ExecuteSqlCommand("EXEC SP_GET_TOTAL_VISITS_CLIENT @CLIENT_CODE = @CLIENT_CODE, @TOTAL_VISITS = @TOTAL_VISITS OUTPUT", cliCode, totalVisitsParam);

                    result = (int)totalVisitsParam.Value;
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }
    }
}
