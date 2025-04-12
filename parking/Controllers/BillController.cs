using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using parking.Models;

namespace parking.Controllers
{
    internal class BillController
    {
        private Helpers.Helpers h;

        public BillController()
        {
            h = new Helpers.Helpers();
        }


        public int saveBill(BILL bill)
        {

            int result = 0;
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    db.BILL.Add(bill);
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);

            }
            return result;
        }

        public string GenerateNextBillNumber()
        {
            try
            {
                using (PARKINGEntities db=  new PARKINGEntities())
                {
                    var billNumberParam = new SqlParameter("@BILL_NUMBER", System.Data.SqlDbType.VarChar, 20)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    db.Database.ExecuteSqlCommand("EXEC GENERATE_BILL_NUMBER @BILL_NUMBER OUTPUT", billNumberParam);

                    return billNumberParam.Value.ToString();

                }
            }
            catch(SqlException ex)
            {
                h.MsgError(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
                throw;
            }
        }

    }
}
