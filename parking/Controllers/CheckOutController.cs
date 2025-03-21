using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public IEnumerable<dynamic> getCheckOuts(string searchFilter)
        {
            IEnumerable<dynamic> checkOuts = new List<CHECK_OUT>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from cout in db.CHECK_OUT 
                                join cin in db.CHECK_IN on cout.CHECK_IN_CODE equals cin.CHECK_IN_CODE
                                join ps in db.PARKING_SPACE on cin.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                              
                                where String.IsNullOrEmpty(searchFilter) ?
                                cout.DEL == false : cout.CHECK_OUT_CODE.Contains(searchFilter) || cout.CHECK_IN_CODE.Contains(searchFilter) || cout.CHECK_OUT_TIME.ToString().Contains(searchFilter) || cout.CHECK_OUT_STATE.Contains(searchFilter) || cout.FULL_CHARGE.ToString().Contains(searchFilter)
                                select new
                                {
                                    cout.CHECK_OUT_CODE,
                                    cout.CHECK_IN_CODE,
                                    cout.CHECK_OUT_TIME,
                                    cout.CHECK_OUT_STATE,
                                    cout.FULL_CHARGE,
                                    cout.USER_CODE,
                                    cout.TOTAL_TIME,
                                    cin.VEHICLE_PLATE,
                                    ps.PARKING_SPACE_NUMBER,
                                    pt.DESCRIPTION_PARKING_TYPE
                                };
                    checkOuts = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return checkOuts;
        }

        public dynamic getInfoCheckOut(string checkOutCode)
        {
            dynamic checkOut = new CHECK_OUT();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from cout in db.CHECK_OUT 
                                join cin in db.CHECK_IN on cout.CHECK_IN_CODE equals cin.CHECK_IN_CODE
                                join ps in db.PARKING_SPACE on cin.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                join cli in db.CLIENTS on cin.CLIENT_DNI equals cli.CLIENT_CODE
                                join b in db.BILL on cout.CHECK_OUT_CODE equals b.CHECK_OUT_CODE 

                                where cout.DEL == false && cout.CHECK_OUT_CODE == checkOutCode
                                select new
                                {
                                    cout.CHECK_IN_CODE,
                                    cin.CLIENT_DNI,
                                    cin.OBSERVATIONS,
                                    cin.VEHICLE_PLATE,
                                    cin.CHECK_IN_TIME,
                                    cin.PARKING_SPACE_CODE,
                                    ps.PARKING_SPACE_NUMBER,
                                    pt.DESCRIPTION_PARKING_TYPE,
                                    pf.PARKING_FEE_CODE,
                                    pf.PRICE_FOR_HOUR,
                                    cout.CHECK_OUT_TIME,
                                    cout.CHECK_OUT_STATE,
                                    cout.DEL,
                                    cout.USER_CODE,
                                    cli.CLIENT_NAME,
                                    cli.CLIENT_LASTNAME,
                                    b.ISV,
                                    b.DATE_OF_ISSUE,
                                    b.DISCOUNT,
                                    b.SUBTOTAL,
                                    b.TOTAL
                                };

                    checkOut = query.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
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
                h.MsgError(ex.ToString());
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
                h.MsgError(ex.ToString());
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
                h.MsgError(ex.ToString());
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
                h.MsgError(ex.ToString());
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
                    checkOut.DEL = true;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int destroyCheckOut(string id)
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
                h.MsgError(ex.ToString());
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
                h.MsgError(ex.ToString());
            }
            return result;
        }
    }
}
