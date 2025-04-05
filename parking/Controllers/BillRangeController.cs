using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using parking.DTO;
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

        public IEnumerable<BillRangeDTO> getBillRanges(string searchFilter = "", bool isDel = false)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = db.BILL_RANGE
                        .Where(br => br.DEL == isDel)
                        .Select(br => new BillRangeDTO
                        {
                            BILL_RANGE_ID = br.BILL_RANGE_ID,
                            ESTABLISHMENT = br.ESTABLISHMENT,
                            EMISSION_POINT = br.EMISSION_POINT,
                            DOC_TYPE = br.DOC_TYPE,
                            BILL_RANGE_STATE = br.BILL_RANGE_STATE ? "ACTIVO" : "INACTIVO",
                            INITIAL_RANGE = br.INITIAL_RANGE,
                            FINAL_RANGE = br.FINAL_RANGE,
                            LAST_USED = br.LAST_USED,
                            INSERTED_AT = br.INSERTED_AT,
                            USER_CODE = br.USER_CODE,
                            BILL_RANGE_START = br.ESTABLISHMENT + "-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.INITIAL_RANGE,
                            BILL_RANGE_END = br.ESTABLISHMENT + "-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.FINAL_RANGE,
                            DEL = br.DEL
                        });

                    // Aplicar filtro de búsqueda si se proporciona
                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query = query.Where(br =>
                            br.BILL_RANGE_ID.ToString().Contains(searchFilter) ||
                            br.BILL_RANGE_START.Contains(searchFilter) ||
                            br.BILL_RANGE_END.Contains(searchFilter) ||
                            br.BILL_RANGE_STATE.Contains(searchFilter) ||
                            br.INSERTED_AT.ToString().Contains(searchFilter)
                           );
                    }

                    return query.ToList();
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR AL RECUPERAR REGISTROS: " + ex.Message.ToUpper());
            }

            return Enumerable.Empty<BillRangeDTO>();
        }


        public BillRangeDTO getBillRangeInfo(int id)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = db.BILL_RANGE
                        .Where(br => br.BILL_RANGE_ID == id)
                        .Select(br => new BillRangeDTO
                        {
                            BILL_RANGE_ID = br.BILL_RANGE_ID,
                            ESTABLISHMENT = br.ESTABLISHMENT,
                            EMISSION_POINT = br.EMISSION_POINT,
                            DOC_TYPE = br.DOC_TYPE,
                            BILL_RANGE_STATE = br.BILL_RANGE_STATE ? "ACTIVO" : "INACTIVO",
                            INITIAL_RANGE = br.INITIAL_RANGE,
                            FINAL_RANGE = br.FINAL_RANGE,
                            LAST_USED = br.LAST_USED,
                            INSERTED_AT = br.INSERTED_AT,
                            USER_CODE = br.USER_CODE,
                            BILL_RANGE_START = br.ESTABLISHMENT + "-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.INITIAL_RANGE,
                            BILL_RANGE_END = br.ESTABLISHMENT + "-" + br.EMISSION_POINT + "-" + br.DOC_TYPE + "-" + br.FINAL_RANGE,
                            DEL = br.DEL
                        })
                        .FirstOrDefault();

                    return query ?? new BillRangeDTO(); // Si no encuentra, retorna un objeto vacío en lugar de null.
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR AL OBTENER INFORMACIÓN DEL RANGO DE FACTURAS: " + ex.Message);
            }

            return new BillRangeDTO(); // Retorna un objeto vacío en caso de error.
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
            int lasIdBillRange = 0;
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
                    exist = db.BILL_RANGE.Any(x => (x.ESTABLISHMENT + "-" + x.EMISSION_POINT + "-" + x.DOC_TYPE + "-" + x.INITIAL_RANGE) == rangeStart && (x.ESTABLISHMENT + "-" + x.EMISSION_POINT + "-" + x.DOC_TYPE + "-" + x.FINAL_RANGE) == rangeEnd);
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
