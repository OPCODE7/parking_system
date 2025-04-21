using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using parking.DTO;
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
                return null;
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
                return null;
            }
        }

        public List<int> getBillingYears()
        {
            List<int> years = new List<int>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var yearList = db.BILL.Select(b => b.DATE_OF_ISSUE.Year).Distinct().ToList();
                    years.AddRange(yearList);
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return years;

        }

        public List<BillDTO> GetBillsRpt(DateTime? dateFrom, DateTime? dateTo, int? month, int? year, string userCode)
        {
            List<BillDTO> bills = new List<BillDTO>();

            try
            {
                using (var db = new PARKINGEntities())
                {
                    var result = db.Database.SqlQuery<BillDTO>(
                        "EXEC sp_GetFilterInvoices @DateFrom, @DateTo, @Month, @Year, @UserCode",
                        new SqlParameter("@DateFrom", (object)dateFrom ?? DBNull.Value),
                        new SqlParameter("@DateTo", (object)dateTo ?? DBNull.Value),
                        new SqlParameter("@Month", (object)month ?? DBNull.Value),
                        new SqlParameter("@Year", (object)year ?? DBNull.Value),
                         new SqlParameter("@UserCode", (object)userCode ?? DBNull.Value)
                    );

                    bills = result.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return bills;
        }


    }
}
