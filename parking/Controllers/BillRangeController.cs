using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using parking.Models;

namespace parking.Controllers
{
    internal class BillRangeController
    {
       private Helpers.Helpers h;

        public BillRangeController()
        {
            h = new Helpers.Helpers();
        }

        public IEnumerable<dynamic> getBillRanges(string searchFilter)
        {
            IEnumerable<dynamic> billRanges = new List<BILL_RANGE>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {

                    var query = from br in db.BILL_RANGE
                                where br.DEL == false
                                select new
                                {
                                    br.BILL_RANGE_ID,
                                    br.ESTABLISHMENT,
                                    br.EMISSION_POINT,
                                    br.DOC_TYPE,
                                    BILL_RANGE_STATE = br.BILL_RANGE_STATE ? "ACTIVO" : "INACTIVO",
                                    br.INITIAL_RANGE,
                                    br.FINAL_RANGE,
                                    br.LAST_USED,
                                    br.INSERTED_AT,
                                    br.USER_CODE,
                                    BILL_RANGE_START = br.ESTABLISHMENT  + "-" +br.EMISSION_POINT +"-" + br.DOC_TYPE + "-" + br.INITIAL_RANGE,
                                   BILL_RANGE_END= br.ESTABLISHMENT 
                +"-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.FINAL_RANGE,
                                   br.DEL
                               };
                    billRanges = searchFilter != "" ? 
                        query.Where(x => (x.BILL_RANGE_ID.ToString().Contains(searchFilter) || x.BILL_RANGE_START.Contains(searchFilter) || x.BILL_RANGE_END.Contains(searchFilter) || x.BILL_RANGE_STATE.Contains(searchFilter) || x.INSERTED_AT.ToString().Contains(searchFilter) || x.LAST_USED.ToString().Contains(searchFilter))).ToList() : 
                        query.ToList();

                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return billRanges;
        }

        public dynamic getBillRangeInfo(int id)
        {
            dynamic billRange = new BILL_RANGE();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from br in db.BILL_RANGE
                                where br.BILL_RANGE_ID == id 
                                select new
                                {
                                    br.BILL_RANGE_ID,
                                    br.ESTABLISHMENT,
                                    br.EMISSION_POINT,
                                    br.DOC_TYPE,
                                    BILL_RANGE_STATE = br.BILL_RANGE_STATE ? "ACTIVO" : "INACTIVO",
                                    br.INITIAL_RANGE,
                                    br.FINAL_RANGE,
                                    br.LAST_USED,
                                    br.INSERTED_AT,
                                    br.USER_CODE,
                                    BILL_RANGE_START = br.ESTABLISHMENT + "-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.INITIAL_RANGE,
                                    BILL_RANGE_END = br.ESTABLISHMENT
                + "-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.FINAL_RANGE,
                                    br.DEL
                                };
                    billRange = query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return billRange;

        }

        public BILL_RANGE getBillRange(int id)
        {
            BILL_RANGE billRange = new BILL_RANGE();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    billRange = db.BILL_RANGE.Find(id);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return billRange;
        }
        public int getNextIdBillRange()
        {
            int lasIdBillRange = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    lasIdBillRange = (int)db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('BILL_RANGE') + 1").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return lasIdBillRange;
        }

        public int getLastIdBillRange()
        {
            int lasIdBillRange= 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    lasIdBillRange = db.BILL_RANGE.Max(x => x.BILL_RANGE_ID);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return lasIdBillRange;
        }
        public bool existBillRange(string rangeStart, string rangeEnd)
        {
            bool exist = false;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    exist = db.BILL_RANGE.Any(x => (x.ESTABLISHMENT + "-" + x.EMISSION_POINT + "-" + x.DOC_TYPE + "-"+ x.INITIAL_RANGE) == rangeStart && (x.ESTABLISHMENT + "-" + x.EMISSION_POINT + "-" + x.DOC_TYPE + "-" + x.FINAL_RANGE) ==rangeEnd);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return exist;
        }


        public int saveBillRange(BILL_RANGE billRange)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.BILL_RANGE.Add(billRange);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int updateBillRange(BILL_RANGE billRange)
        {

           int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                   db.Entry(billRange).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int deleteBillRange(int id)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    BILL_RANGE billRange = db.BILL_RANGE.Find(id);
                    db.Entry(billRange).State = System.Data.Entity.EntityState.Deleted;
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
