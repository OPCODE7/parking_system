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
        
        DISCOUNTS discountFF, discountFT;

        string checkOutCode,checkInCode, checkOutState, userCode,formatTime;
        DateTime checkOutTime;
        double fullCharge, finalDiscount, subtotal, isvPercent= 15, isvCharge,totalHours, priceParkingFee,_totalHours,subtotalWithDiscount,discountForTime= 0,discountForFrequency=0;

       

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                getCheckOuts(TxtSearch.Text.Trim());
            }
        }

        private void BtnSearchCheckIn_Click(object sender, EventArgs e)
        {
            FrmSearchCheckIn searchCheckIn = new FrmSearchCheckIn();
            this.AddOwnedForm(searchCheckIn);
            searchCheckIn.ShowDialog();
        }

        private void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            generateBill();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(h.MsgQuestion("¿Estás seguro de eliminar este registro?")=="S")
                {
                if(checkOutController.deleteCheckOut(checkOutCode) > 0)
                {
                    h.MsgInfo("Registro eliminado correctamente.");
                    startForm();
                }
            }

        }

        private void DgvCheckOuts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string _checkOutCode = DgvCheckOuts.CurrentRow.Cells[0].Value.ToString();
            CHECK_OUT checkOut = checkOutController.getCheckOut(_checkOutCode);
            if (checkOutController.thisIsBilled(_checkOutCode))
            {
                getInfoCheckOut(_checkOutCode);
                BtnGenerateBill.Visible = false;
            }
            else
            {
                getInfoCheckIn(checkOut.CHECK_IN_CODE);
                BtnGenerateBill.Visible = true;
            }
            checkOutCode = _checkOutCode;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = true;
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

        public void startForm()
        {
            getCheckOuts();
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnGenerateBill.Visible = false;
            DtpCheckInTime.Format = DateTimePickerFormat.Custom;
            DtpCheckInTime.CustomFormat = "dd/MM/yyyy HH:mm";

            DtpCheckOutTime.Format = DateTimePickerFormat.Custom;
            DtpCheckOutTime.CustomFormat = "dd/MM/yyyy HH:mm";
           


            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = false;
                txt.Clear();
            }
            TxtSearch.Enabled = true;
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
            discountFT= discountsController.getDiscountForTime(hours);

            

            if(discountFT!=null) discountForTime = subtotal * (Convert.ToDouble(discountFT.DISCOUNT_VALUE.Replace("%", "")) / 100);

            if (checkIn.CLIENT_DNI != "CLI000001")
            {
                discountFF = discountsController.getDiscountForFrequency(totalVisits);
              
                if(discountFF!=null)
                discountForFrequency = subtotal * (Convert.ToDouble(discountFF.DISCOUNT_VALUE.Replace("%", "")) / 100);
            }


            finalDiscount = discountForTime + discountForFrequency;
            subtotalWithDiscount = subtotal - finalDiscount;
            isvCharge = ((isvPercent / 100) * subtotalWithDiscount);
            fullCharge = subtotalWithDiscount + isvCharge;
            userCode = Config.User.userId;
        }
         
        public void getCheckOuts(string searchFilter="")
        {
            DgvCheckOuts.Rows.Clear();
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
                DgvCheckOuts.Rows.Add(checkOut.CHECK_OUT_CODE, checkOut.VEHICLE_PLATE, checkOut.PARKING_SPACE_NUMBER,checkOut.DESCRIPTION_PARKING_TYPE,Convert.ToDateTime(checkOut.CHECK_OUT_TIME),checkOut.CHECK_OUT_STATE);
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
                TxtISV.Text = isvCharge.ToString();
                TxtTotal.Text = "L. " + fullCharge;
              
            }
            else
            {
                h.MsgInfo("No se encontró el registro");
            }
        }

        public void getInfoCheckOut(string checkOutCode)
        {
            dynamic checkOut = checkOutController.getInfoCheckOut(checkOutCode);
            if (checkOut != null)
            {

                TxtCheckInCode.Text = checkOut.CHECK_IN_CODE;
                TxtClientName.Text = checkOut.CLIENT_NAME + " " + checkOut.CLIENT_LASTNAME;
                TxtParkingType.Text = checkOut.DESCRIPTION_PARKING_TYPE;
                TxtPriceParkingFee.Text = checkOut.PRICE_FOR_HOUR.ToString();
                TxtVehiclePlate.Text = checkOut.VEHICLE_PLATE;
                DtpCheckInTime.Value = checkOut.CHECK_IN_TIME;
                DtpCheckOutTime.Value = checkOut.CHECK_OUT_TIME;
                setValues();

                BtnSave.Enabled = true;

                TxtTotalTime.Text = formatTime;
                TxtDiscount.Text = "L. " + checkOut.DISCOUNT;
                TxtSubtotal.Text = "L. " + checkOut.SUBTOTAL;
                TxtISV.Text = checkOut.ISV.ToString();
                TxtTotal.Text = "L. " + checkOut.TOTAL;

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
            checkOutCode= "COUT" + correlativesController.getNextId("COUT");
            newCheckOut.CHECK_OUT_CODE = checkOutCode;
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
                    BtnSave.Enabled = false;
                    generateBill();
                }
            }
        }

        public void generateBill()
        {
            BillingModule.FrmGenerateBill frmGenerateBill = new BillingModule.FrmGenerateBill();
            this.AddOwnedForm(frmGenerateBill);
            frmGenerateBill.discountIdFF = discountFF != null ? discountFF.DISCOUNT_ID : 0;
            frmGenerateBill.discountIdFT = discountFT != null ? discountFT.DISCOUNT_ID : 0;
            frmGenerateBill.amountDiscountFF = discountForFrequency;
            frmGenerateBill.amountDiscountFT = discountForTime;


            dynamic checkIn = checkInController.getInfoCheckIn(checkInCode);
            frmGenerateBill.psCode = checkIn.PARKING_SPACE_CODE;
            frmGenerateBill.TxtClientCode.Text = checkInCode;
            frmGenerateBill.TxtClientName.Text = TxtClientName.Text;
            frmGenerateBill.TxtCheckOutCode.Text = checkOutCode;
            frmGenerateBill.TxtParkingNumber.Text = checkIn.PARKING_SPACE_NUMBER.ToString();
            frmGenerateBill.TxtVehiclePlate.Text = TxtVehiclePlate.Text;
            frmGenerateBill.TxtParkingType.Text = TxtParkingType.Text;
            frmGenerateBill.TxtCheckInDate.Text = DtpCheckInTime.Value.ToString();
            frmGenerateBill.TxtCheckOutDate.Text = DtpCheckOutTime.Value.ToString();
            frmGenerateBill.TxtParkingFee.Text = "L. " + priceParkingFee;
            frmGenerateBill.TxtSubtotal.Text = "L. " + subtotal;
            frmGenerateBill.TxtTotalHours.Text = hours.ToString();
            frmGenerateBill.TxtDiscount.Text = "L. " + finalDiscount;
            frmGenerateBill.TxtISV.Text = isvCharge.ToString();
            frmGenerateBill.LblFullCharge.Text += " L. " + fullCharge;


            frmGenerateBill.ShowDialog();
        }
    }
}
