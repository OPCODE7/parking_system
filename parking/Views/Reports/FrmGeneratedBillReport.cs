using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Reports
{
    public partial class FrmGeneratedBillReport : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        public string billCode;
        public FrmGeneratedBillReport()
        {
            InitializeComponent();
        }

        private void FrmGeneratedBillReport_Load(object sender, EventArgs e)
        {

            this.RptBill.RefreshReport();
            try
            {
                DataTable billDt = new DataTable();
                DataTable companyDt = new DataTable();


                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var connection = db.Database.Connection;
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SP_REPORT_GENERATED_INVOICE"; 

                        cmd.CommandType = CommandType.StoredProcedure;

                        var param = cmd.CreateParameter();
                        param.ParameterName = "@B_CODE";
                        param.Value = billCode;
                        param.DbType = DbType.String;
                        cmd.Parameters.Add(param);
                        

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            billDt.Load(reader); 
                        }
                    }

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SP_GET_COMPANY_DATA";

                        cmd.CommandType = CommandType.StoredProcedure;

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            companyDt.Load(reader);
                        }
                    }


                }
                ReportDataSource rds = new ReportDataSource("DtsGenerateBill", billDt);
                ReportDataSource rds2 = new ReportDataSource("DtsGetCompanyData", companyDt);

                RptBill.LocalReport.DataSources.Clear();
                RptBill.LocalReport.DataSources.Add(rds);
                RptBill.LocalReport.DataSources.Add(rds2);
                RptBill.SetDisplayMode(DisplayMode.PrintLayout);
                RptBill.ZoomMode= ZoomMode.Percent;
                RptBill.ZoomPercent = 100;
                RptBill.LocalReport.Refresh();

            }
            catch(Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
      
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RptBill_Load(object sender, EventArgs e)
        {

        }
    }
}
