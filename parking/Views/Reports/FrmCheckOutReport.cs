using Microsoft.Reporting.WinForms;
using parking.DTO;
using parking.Models;
using parking.Views.Reports.DataSets.DtsCheckInTableAdapters;
using parking.Views.Reports.DataSets.DtsGetCompanyDataTableAdapters;
using parking.Views.Reports.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.Controllers;
using parking.Views.Reports.DataSets.DtsCheckOutTableAdapters;

namespace parking.Views.Reports
{
    public partial class FrmCheckOutReport : Form
    {
        bool isFromSelected = false, isToSelected = false;
        BillController bc = new BillController();
        UserController uc = new UserController();
        ParkingTypeController ptc = new ParkingTypeController();
        public FrmCheckOutReport()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCheckOutReport_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void startForm()
        {
            fillCmbMonths();
            fillCmbUsers();
            fillCmbYears();
            fillCmbParkingTypes();

            DtpFrom.Value = DateTime.Now;
            DtpTo.Value = DateTime.Now;
            resetDtps();
            foreach (System.Windows.Forms.ComboBox cmb in GbxFilters.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
            fillRptCheckOut();

        }


        private void fillCmbUsers()
        {
            List<UserDTO> users = uc.getUsers().ToList();
            users.Insert(0, new UserDTO { USER_NAME = "Todos" });

            CmbUsers.DataSource = users;

            CmbUsers.DisplayMember = "USER_NAME";
            CmbUsers.ValueMember = "USER_CODE";
        }

        private void fillCmbParkingTypes()
        {
            List<PARKING_TYPES> pt = ptc.getParkingTypes("", false).ToList();
            pt.Insert(0, new PARKING_TYPES { DESCRIPTION_PARKING_TYPE = "Todos" });

            CmbParkingTypes.DataSource = pt;

            CmbParkingTypes.DisplayMember = "DESCRIPTION_PARKING_TYPE";
            CmbParkingTypes.ValueMember = "PARKING_TYPE_CODE";
        }

        private void fillCmbYears()
        {
            var years = bc.getBillingYears();
            var strYears = new List<string> { "Todos" };
            strYears.AddRange(years.Select(y => y.ToString()));

            CmbYear.DataSource = strYears;
        }

        private void fillCmbMonths()
        {
            List<string> months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Take(12)
                .ToList();

            months = (new[] { "Todos" }).Concat(months).ToList();

            CmbMonth.DataSource = months;
        }


        private void fillRptCheckOut(DateTime? from = null, DateTime? to = null, int? month = null, int? year = null, string user = null, string parkingType = null)
        {
            DtsGetCompanyData dsCompany = new DtsGetCompanyData();
            DtsCheckOut dsCheckIn = new DtsCheckOut();

            var adapterCompany = new SP_GET_COMPANY_DATATableAdapter();
            var adapterCheckOut = new SP_CHECK_OUT_REPORTTableAdapter();

            adapterCompany.Fill(dsCompany.SP_GET_COMPANY_DATA);
            adapterCheckOut.Fill(dsCheckIn.SP_CHECK_OUT_REPORT, from, to, month, year, user, parkingType);


            RptCheckIn.LocalReport.DataSources.Clear();

            RptCheckIn.LocalReport.ReportPath = Path.GetFullPath(@"..\..\Views\Reports\RDLC\ReportCheckOut.rdlc");

            ReportDataSource rdsCompany = new ReportDataSource("DtsGetCompanyData", (DataTable)dsCompany.SP_GET_COMPANY_DATA);
            ReportDataSource rdsCheckOut = new ReportDataSource("DtsCheckOut", (DataTable)dsCheckIn.SP_CHECK_OUT_REPORT);



            RptCheckIn.LocalReport.DataSources.Add(rdsCompany);
            RptCheckIn.LocalReport.DataSources.Add(rdsCheckOut);

            RptCheckIn.RefreshReport();
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
            string parkingType = (CmbParkingTypes.SelectedIndex > -1 && CmbParkingTypes.Text != "Todos")
                ? CmbParkingTypes.SelectedValue.ToString()
                : null;


            fillRptCheckOut(from, to, month, year, user, parkingType);
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
