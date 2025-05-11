using Microsoft.Reporting.WinForms;
using parking.Views.Reports.DataSets.DtsFinancialIncomesTableAdapters;
using parking.Views.Reports.DataSets.DtsGetCompanyDataTableAdapters;
using parking.Views.Reports.DataSets.DtsGetInvoicesTableAdapters;
using parking.Views.Reports.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Reports
{
    public partial class FrmDefaultRpt : Form
    {
        public FrmDefaultRpt()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void fillRpt(DataTable dt, string rdlcPath,string dtsName)
        {
            ReportDataSource rds = new ReportDataSource(dtsName, dt);
            DtsGetCompanyData dsCompany = new DtsGetCompanyData();
            var adapterCompany = new SP_GET_COMPANY_DATATableAdapter();
            adapterCompany.Fill(dsCompany.SP_GET_COMPANY_DATA);

            ReportDataSource rdsCompany = new ReportDataSource("DtsGetCompanyData", (DataTable)dsCompany.SP_GET_COMPANY_DATA);

            RptGeneric.LocalReport.ReportPath = Path.GetFullPath(rdlcPath);
            RptGeneric.LocalReport.DataSources.Clear();
            RptGeneric.LocalReport.DataSources.Add(rdsCompany);
            RptGeneric.LocalReport.DataSources.Add(rds);
            RptGeneric.SetDisplayMode(DisplayMode.PrintLayout);
            RptGeneric.ZoomMode = ZoomMode.Percent;
            RptGeneric.ZoomPercent = 100;

            RptGeneric.RefreshReport(); 


        }

        private void FrmDefaultRpt_Load(object sender, EventArgs e)
        {
            
        }
    }
}
