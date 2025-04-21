using Microsoft.Reporting.WinForms;
using parking.Controllers;
using parking.DTO;
using parking.Models;
using parking.Views.Reports.DataSets;
using parking.Views.Reports.DataSets.DtsGetCompanyDataTableAdapters;
using parking.Views.Reports.DataSets.DtsGetInvoicesTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace parking.Views.Reports
{
    public partial class FrmBillsReport : Form
    {
        UserController uc = new UserController();
        BillController bc = new BillController();

        bool isFromSelected = false;
        bool isToSelected = false;
        public FrmBillsReport()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBillsReport_Load(object sender, EventArgs e)
        {

            this.RptInvoices.RefreshReport();
            fillCmbUsers();
            fillCmbYears();
            fillCmbMonths();
            startForm();
        }

        private void startForm()
        {
            DtpFrom.Value = DateTime.Now;
            DtpTo.Value = DateTime.Now;
            resetDtps();
            foreach (System.Windows.Forms.ComboBox cmb in GbxFilters.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
            fillRptInvoices();
            
        }


        private void fillCmbUsers()
        {
            List<UserDTO> users = uc.getUsers().ToList();
            users.Insert(0, new UserDTO { USER_NAME = "Todos" });

            CmbUsers.DataSource = users;

            CmbUsers.DisplayMember = "USER_NAME";
            CmbUsers.ValueMember = "USER_CODE";
            CmbUsers.SelectedIndex = -1;
        }

        private void fillCmbYears()
        {
            var years = bc.getBillingYears();
            var strYears = new List<string> { "Todos" };
            strYears.AddRange(years.Select(y => y.ToString()));

            CmbYear.DataSource = strYears;
            CmbYear.SelectedIndex = -1;
        }

        private void fillCmbMonths()
        {
            List<string> months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Take(12)
                .ToList();

            months = (new[] { "Todos" }).Concat(months).ToList();

            CmbMonth.DataSource = months;
            CmbMonth.SelectedIndex = -1;
        }



        private void PbxClearFilter_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            DateTime? from = isFromSelected ? DtpFrom.Value.Date : (DateTime?)null;
            DateTime? to = isToSelected ? DtpTo.Value.Date : (DateTime?)null;


            int? month = (CmbMonth.SelectedIndex > -1 && CmbMonth.Text != "Todos")
    ? CmbMonth.SelectedIndex
    : (int?)null;

            int? year = (CmbYear.SelectedIndex > -1 && CmbYear.Text != "Todos")
                ? Convert.ToInt32(CmbYear.SelectedItem)
                : (int?)null;

            string user = (CmbUsers.SelectedIndex > -1 && CmbUsers.Text != "Todos")
                ? CmbUsers.SelectedValue.ToString()
                : null;


            fillRptInvoices(from, to, month, year, user);
            
        }


        private void fillRptInvoices(DateTime? from=null, DateTime? to= null, int? month= null,int? year= null, string user=null)
        {
            DtsGetInvoices dtsInvoices = new DtsGetInvoices();
            DtsGetCompanyData dsCompany = new DtsGetCompanyData();

            var adapterCompany = new SP_GET_COMPANY_DATATableAdapter();
            var adapterInvoices = new SP_GET_FILTER_INVOICESTableAdapter();

            adapterInvoices.Fill(dtsInvoices.SP_GET_FILTER_INVOICES, from, to, month, year, user);
            adapterCompany.Fill(dsCompany.SP_GET_COMPANY_DATA);


            RptInvoices.LocalReport.DataSources.Clear();

            RptInvoices.LocalReport.ReportPath = Path.GetFullPath(@"..\..\Views\Reports\RDLC\ReportInvoices.rdlc");
            
            ReportDataSource rdsInvoices = new ReportDataSource("DtsGetInvoices", (DataTable)dtsInvoices.SP_GET_FILTER_INVOICES);

            ReportDataSource rdsCompany = new ReportDataSource("DtsGetCompanyData", (DataTable)dsCompany.SP_GET_COMPANY_DATA);

            RptInvoices.LocalReport.DataSources.Add(rdsInvoices);
            RptInvoices.LocalReport.DataSources.Add(rdsCompany);
           
            RptInvoices.RefreshReport();
        }
        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            CmbMonth.SelectedIndex = -1;
            CmbYear.SelectedIndex = -1;

            DtpFrom.Format = DateTimePickerFormat.Short;
            isFromSelected = true;
            
        }

        private void DtpTo_ValueChanged(object sender, EventArgs e)
        {
            CmbMonth.SelectedIndex = -1;
            CmbYear.SelectedIndex = -1;

            DtpTo.Format = DateTimePickerFormat.Short;
            isToSelected = true;
        }

        private void CmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {

            resetDtps();

        }

        private void CmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            resetDtps();
        }

        private void resetDtps()
        {
            

            DtpFrom.Format = DateTimePickerFormat.Custom;
            DtpFrom.CustomFormat = " ";
            isFromSelected = false;
            DtpTo.Format = DateTimePickerFormat.Custom;
            DtpTo.CustomFormat = " ";
            isToSelected = false;
            
        }
    }
}
