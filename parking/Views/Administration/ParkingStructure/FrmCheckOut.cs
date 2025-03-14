using parking.Controllers;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmCheckOut : Form
    {
        CheckInController checkInController = new CheckInController();
        CheckOutController checkOutController = new CheckOutController();
        Helpers.Helpers h = new Helpers.Helpers();
        CorrelativesController correlativesController = new CorrelativesController();
        DiscountsBillController discountsBillController = new DiscountsBillController();
        DiscountsController discountsController = new DiscountsController();

        string checkInCode, checkOutState, userCode,formatTime;
        DateTime checkOutTime;
        double fullCharge, finalDiscount, subtotal, isv= 15, totalHours, priceParkingFee,_totalHours,subtotalWithDiscount,discountForTime= 0,discountForFrequency=0;

        private void DgvCheckIns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CHECK_OUT checkOut= checkOutController.getCheckOut(DgvCheckIns.CurrentRow.Cells[0].Value.ToString());
            getInfoCheckIn(checkOut.CHECK_IN_CODE);
            BtnSave.Enabled = false;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                getCheckOuts(TxtSearch.Text.Trim());
            }
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getCheckOuts();
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getCheckOuts(TxtSearch.Text.Trim());
        }

        TimeSpan difference;
        int hours;
                
        public FrmCheckOut()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearchCheckIn_Click(object sender, EventArgs e)
        {
            FrmSearchCheckIn searchCheckIn= new FrmSearchCheckIn();
            this.AddOwnedForm(searchCheckIn);
            searchCheckIn.ShowDialog();
        }

        public void startForm()
        {
            getCheckOuts();
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            DtpCheckInTime.Format = DateTimePickerFormat.Custom;
            DtpCheckInTime.CustomFormat = "dd/MM/yyyy HH:mm";

            DtpCheckOutTime.Format = DateTimePickerFormat.Custom;
            DtpCheckOutTime.CustomFormat = "dd/MM/yyyy HH:mm";


            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = false;
                txt.Clear();
            }

            TxtSearch.Focus();

        }

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void setValues()
        {
            checkOutTime= DtpCheckOutTime.Value;
            checkInCode = TxtCheckInCode.Text;
            difference = DtpCheckOutTime.Value - DtpCheckInTime.Value;
            totalHours = difference.TotalHours;
            formatTime = $"{(int)Math.Ceiling(totalHours)} horas y {difference.Minutes} minutos";
            hours = (int)Math.Ceiling(difference.TotalHours);
            _totalHours = difference.Minutes == 0 ? hours : hours + 1;
            priceParkingFee = Convert.ToDouble(TxtPriceParkingFee.Text);
            subtotal = _totalHours * priceParkingFee;

            CHECK_IN checkIn = checkInController.getCheckIn(checkInCode);
            int totalVisits = checkOutController.getTotalVisitsClient(checkIn.CLIENT_DNI);
            DISCOUNTS discountFT= discountsController.getDiscountForTime(hours);

            

            if(discountFT!=null) discountForTime = subtotal * (Convert.ToDouble(discountFT.DISCOUNT_VALUE.Replace("%", "")) / 100);

            if (checkIn.CLIENT_DNI != "CLI000001")
            {
                DISCOUNTS discountFF = discountsController.getDiscountForFrequency(totalVisits);
              
                if(discountFF!=null)
                discountForFrequency = subtotal * (Convert.ToDouble(discountFF.DISCOUNT_VALUE.Replace("%", "")) / 100);
            }


            finalDiscount = discountForTime + discountForFrequency;
            subtotalWithDiscount = subtotal - finalDiscount;
            fullCharge = subtotalWithDiscount + ((isv / 100) * subtotalWithDiscount);
            userCode = Config.User.userId;
        }
         
        public void getCheckOuts(string searchFilter="")
        {
            DgvCheckIns.Rows.Clear();
            var checkOuts= checkOutController.getCheckOuts(searchFilter);

            if(checkOuts.Count()==0)
            {
                h.MsgInfo("No se encontraron registros");
                if (searchFilter != "")
                {
                    getCheckOuts();
                }
                return;
                
            }

            foreach (var checkOut in checkOuts)
            {
                DgvCheckIns.Rows.Add(checkOut.CHECK_OUT_CODE, checkOut.VEHICLE_PLATE, checkOut.PARKING_SPACE_NUMBER,checkOut.DESCRIPTION_PARKING_TYPE,Convert.ToDateTime(checkOut.CHECK_OUT_TIME),checkOut.CHECK_OUT_STATE);
            }
        }
        public void getInfoCheckIn(string checkInCode)
        { 
            dynamic checkIn = checkInController.getInfoCheckIn(checkInCode);
            if (checkIn != null)
            {
                TxtCheckInCode.Text = checkIn.CHECK_IN_CODE;
                TxtClientName.Text = checkIn.CLIENT_NAME + " " + checkIn.CLIENT_LASTNAME;
                TxtParkingType.Text = checkIn.DESCRIPTION_PARKING_TYPE;
                TxtPriceParkingFee.Text = checkIn.PRICE_FOR_HOUR.ToString();
                TxtVehiclePlate.Text = checkIn.VEHICLE_PLATE;
                DtpCheckInTime.Value = checkIn.CHECK_IN_TIME;
                DtpCheckOutTime.Value = DateTime.Now;

                setValues();
                BtnSave.Enabled = true;

                TxtDiscount.Text = "L. "+finalDiscount.ToString();
                TxtTotalTime.Text = formatTime;
                TxtSubtotal.Text = "L. " + subtotal;
                TxtISV.Text = "15%";
                TxtTotal.Text = "L. " + fullCharge;
              
            }
            else
            {
                h.MsgInfo("No se encontró el registro");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CHECK_OUT newCheckOut = new CHECK_OUT();
            newCheckOut.CHECK_OUT_CODE = "COUT" + correlativesController.getNextId("COUT");
            newCheckOut.CHECK_IN_CODE = checkInCode;
            newCheckOut.CHECK_OUT_TIME = checkOutTime;
            newCheckOut.FULL_CHARGE = Convert.ToDecimal(fullCharge);
            newCheckOut.USER_CODE = userCode;
            newCheckOut.CHECK_OUT_STATE = "PENDIENTE";
            newCheckOut.TOTAL_TIME = hours;
            newCheckOut.USER_CODE = userCode;
            

            if(checkOutController.saveCheckOut(newCheckOut) > 0)
            {
                CHECK_IN checkInUpdate= checkInController.getCheckIn(checkInCode);
                checkInUpdate.CHECK_IN_STATE = "FINALIZADO";

                if(checkInController.updateCheckIn(checkInUpdate) > 0)
                {
                    BillingModule.FrmGenerateBill frmGenerateBill = new BillingModule.FrmGenerateBill();
                    this.AddOwnedForm(frmGenerateBill);
                    dynamic checkIn = checkInController.getInfoCheckIn(checkInCode);
                    frmGenerateBill.TxtClientCode.Text = checkInCode;
                    frmGenerateBill.TxtClientName.Text = TxtClientName.Text;
                    frmGenerateBill.TxtCheckOutCode.Text = newCheckOut.CHECK_OUT_CODE;
                    frmGenerateBill.TxtParkingNumber.Text = checkIn.PARKING_SPACE_NUMBER.ToString();
                    frmGenerateBill.TxtVehiclePlate.Text = TxtVehiclePlate.Text;
                    frmGenerateBill.TxtParkingType.Text = TxtParkingType.Text;
                    frmGenerateBill.TxtCheckInDate.Text = DtpCheckInTime.Value.ToString();
                    frmGenerateBill.TxtCheckOutDate.Text = DtpCheckOutTime.Value.ToString();
                    frmGenerateBill.TxtParkingFee.Text = "L. " + priceParkingFee;
                    frmGenerateBill.TxtSubtotal.Text = "L. " + subtotal;
                    frmGenerateBill.TxtTotalHours.Text = hours.ToString();
                    frmGenerateBill.TxtDiscount.Text = "L. " + finalDiscount;
                    frmGenerateBill.TxtISV.Text = "15%";
                    frmGenerateBill.LblFullCharge.Text += " L. " + fullCharge;


                    frmGenerateBill.ShowDialog();
                }
            }
        }
    }
}
