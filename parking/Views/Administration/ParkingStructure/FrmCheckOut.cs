using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using parking.Config;
using parking.Controllers;
using parking.DTO;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
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
        LogBookAppController lac = new LogBookAppController();

        DISCOUNTS discountFF, discountFT;

        string checkOutCode, checkInCode, checkOutState, userCode, formatTime, moduleId = "COUT";
        DateTime checkOutTime;
        double fullCharge, finalDiscount, subtotal, isvPercent = 15, isvCharge, totalHours, priceParkingFee, _totalHours, subtotalWithDiscount, discountForTime = 0, discountForFrequency = 0;
        TimeSpan difference;
        int hours;
        bool flagIsPaperbin = false;



        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getCheckOuts(TxtSearch.Text.Trim(),flagIsPaperbin);
            }
        }

        private void BtnSearchCheckIn_Click(object sender, EventArgs e)
        {
            FrmSearchCheckIn searchCheckIn = new FrmSearchCheckIn();
            this.AddOwnedForm(searchCheckIn);
            searchCheckIn.ShowDialog();
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = true;
            PbxDestroy.Visible = true;
            PbxRecovery.Visible = true;
            BtnSearchCheckIn.Enabled = false;
            flagIsPaperbin = true;
            getCheckOuts("",flagIsPaperbin);

        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                CHECK_OUT checkOut = checkOutController.getCheckOut(checkOutCode);
                checkOut.DEL = false;
                if (checkOutController.updateCheckOut(checkOut) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró la salida con código  {checkOut.CHECK_OUT_CODE} de la papelera.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0018);
                }
            }


        }

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                
                if (checkOutController.deleteCheckOut(checkOutCode) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente la salida con código {checkOutCode}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }
        }
        private void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            generateBill();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                CHECK_OUT checkOut = checkOutController.getCheckOut(checkOutCode);
                checkOut.DEL = true;
                if (checkOutController.updateCheckOut(checkOut) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió la salida con código  {checkOut.CHECK_OUT_CODE} a la papelera de reciclaje.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0005);
                    h.MsgInfo(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }

        }

        private void DgvCheckOuts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string _checkOutCode = DgvCheckOuts.CurrentRow.Cells[0].Value.ToString();
            CHECK_OUT checkOut = checkOutController.getCheckOut(_checkOutCode);

            checkOutCode = _checkOutCode;
            
            BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
            BtnDelete.Enabled = flagIsPaperbin ? false : true;
            PbxDestroy.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
            PbxRecovery.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");

            if (checkOutController.thisIsBilled(_checkOutCode))
            {
                getInfoCheckOut(_checkOutCode);
                BtnGenerateBill.Visible = false;
                BtnDelete.Enabled= false;
            }
            else
            {
                getInfoCheckIn(checkOut.CHECK_IN_CODE);
                BtnGenerateBill.Visible= PermissionManager.HasPermission("FAC", "Crear");   
                TspBill.Visible= PermissionManager.HasPermission("FAC", "Crear"); 
                BtnGenerateBill.Visible = flagIsPaperbin ? false : true;
                TspBill.Visible = flagIsPaperbin ? false : true;
            }

            BtnSave.Enabled = false;


        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getCheckOuts("",flagIsPaperbin);
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getCheckOuts(TxtSearch.Text.Trim(),flagIsPaperbin);
        }



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
            getCheckOuts("",false);
            flagIsPaperbin = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnGenerateBill.Visible = false;
            TspBill.Visible = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Enabled = false;
            BtnPaperbin.Enabled = PermissionManager.HasPermission(moduleId, "Acceso");
            BtnSearchCheckIn.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            ; DtpCheckInTime.Format = DateTimePickerFormat.Custom;
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
            checkOutTime = DtpCheckOutTime.Value;
            checkInCode = TxtCheckInCode.Text;
            difference = DtpCheckOutTime.Value - DtpCheckInTime.Value;
            totalHours = difference.TotalHours;
            formatTime = $"{(int)Math.Ceiling(totalHours)} horas y {difference.Minutes} minutos";
            hours = (int)Math.Ceiling(difference.TotalHours);
            _totalHours = difference.Minutes == 0 ? hours : hours + 1;
            priceParkingFee = Convert.ToDouble(TxtPriceParkingFee.Text);
            subtotal = _totalHours * priceParkingFee;

            CHECK_IN checkIn = checkInController.getCheckIn(checkInCode);
            int totalVisits = checkOutController.getTotalVisitsClient(checkIn.CLIENT_CODE);
            discountFT = discountsController.getDiscountForTime(hours);

            if (discountFT != null && discountFT.DISCOUNT_STATE) discountForTime = subtotal * (Convert.ToDouble(discountFT.DISCOUNT_VALUE.Replace("%", "")) / 100);

            if (checkIn.CLIENT_CODE != "CLI000001")
            {
                discountFF = discountsController.getDiscountForFrequency(totalVisits);

                if (discountFF != null && discountFF.DISCOUNT_STATE)
                    discountForFrequency = subtotal * (Convert.ToDouble(discountFF.DISCOUNT_VALUE.Replace("%", "")) / 100);
            }

            finalDiscount = discountForTime + discountForFrequency;
            subtotalWithDiscount = subtotal - finalDiscount;
            isvCharge = ((isvPercent / 100) * subtotalWithDiscount);
            fullCharge = subtotalWithDiscount + isvCharge;
            userCode = Config.User.userId;
        }

        public void getCheckOuts(string searchFilter = "",bool isDel= false)
        {
            DgvCheckOuts.Rows.Clear();
            IEnumerable<CheckOutDTO> checkOuts = checkOutController.getCheckOuts(searchFilter,isDel);

            if (checkOuts.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getCheckOuts("",isDel);
                }
                return;

            }

            foreach (var checkOut in checkOuts)
            {
                DgvCheckOuts.Rows.Add(checkOut.CHECK_OUT_CODE, checkOut.VEHICLE_PLATE, checkOut.PARKING_SPACE_NUMBER, checkOut.DESCRIPTION_PARKING_TYPE, Convert.ToDateTime(checkOut.CHECK_OUT_TIME), checkOut.CHECK_OUT_STATE);
            }
        }
        public void getInfoCheckIn(string checkInCode)
        {
            CheckInDTO checkIn = checkInController.getInfoCheckIn(checkInCode);
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

                TxtDiscount.Text = finalDiscount.ToString();
                TxtTotalTime.Text = formatTime;
                TxtSubtotal.Text = subtotal.ToString();
                TxtISV.Text = isvCharge.ToString();
                TxtTotal.Text = fullCharge.ToString();
            }
            else
            {
                h.MsgInfo(Helpers.App.Msg0011);
            }
        }

        public void getInfoCheckOut(string checkOutCode)
        {
            CheckOutDTO checkOut = checkOutController.getInfoCheckOut(checkOutCode);
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
                TxtDiscount.Text = checkOut.DISCOUNT.ToString();
                TxtSubtotal.Text = checkOut.SUBTOTAL.ToString();
                TxtISV.Text = checkOut.ISV.ToString();
                TxtTotal.Text = checkOut.TOTAL.ToString();

            }
            else
            {
                h.MsgInfo(Helpers.App.Msg0011);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            CHECK_OUT newCheckOut = new CHECK_OUT();
            checkOutCode = moduleId + correlativesController.getNextId(moduleId);
            newCheckOut.CHECK_OUT_CODE = checkOutCode;
            newCheckOut.CHECK_IN_CODE = checkInCode;
            newCheckOut.CHECK_OUT_TIME = checkOutTime;
            newCheckOut.FULL_CHARGE = Convert.ToDecimal(fullCharge);
            newCheckOut.USER_CODE = userCode;
            newCheckOut.CHECK_OUT_STATE = "Pendiente";
            newCheckOut.TOTAL_TIME = hours;
            newCheckOut.USER_CODE = userCode;


            if (checkOutController.saveCheckOut(newCheckOut) > 0)
            {
                await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó la salida con código {checkOutCode}.", moduleId, DateTime.Now);

                CHECK_IN checkInUpdate = checkInController.getCheckIn(checkInCode);
                checkInUpdate.CHECK_IN_STATE = "Finalizado";

                if (checkInController.updateCheckIn(checkInUpdate) > 0)
                {
                    string logDesc = $"El usuario {Config.User.userName} modificó la entrada con código {checkInUpdate.CHECK_IN_CODE}. Cambios: CHECK_IN_STATE: 'Pendiente' → 'Finalizado'.";
                    await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);
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
            frmGenerateBill.TxtParkingFee.Text = priceParkingFee.ToString();
            frmGenerateBill.TxtSubtotal.Text = subtotal.ToString();
            frmGenerateBill.TxtTotalHours.Text = hours.ToString();
            frmGenerateBill.TxtDiscount.Text = finalDiscount.ToString();
            frmGenerateBill.TxtISV.Text = isvCharge.ToString();
            frmGenerateBill.LblFullCharge.Text += fullCharge.ToString();


            frmGenerateBill.ShowDialog();
        }
    }
}
