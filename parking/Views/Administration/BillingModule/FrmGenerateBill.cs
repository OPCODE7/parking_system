using parking.Config;
using parking.Controllers;
using parking.Models;
using parking.Views.Administration.Employees;
using parking.Views.Administration.ParkingStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.BillingModule
{
    public partial class FrmGenerateBill : Form
    {
        BillController billController = new BillController();
        CorrelativesController correlativesController = new CorrelativesController();
        Helpers.Helpers h = new Helpers.Helpers();
        CheckOutController checkOutController = new CheckOutController();
        DiscountsBillController discountsBillController= new DiscountsBillController();
        DiscountsController dc = new DiscountsController();
        ParkingSpaceController pspController = new ParkingSpaceController();
        LogBookAppController lac = new LogBookAppController();

        public int discountIdFT,discountIdFF;
        public double amountDiscountFT,amountDiscountFF;
        public string psCode, moduleId= "FAC";
        private double amountClaimDiscount = 0;
        public FrmGenerateBill()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmCheckOut frmCheckOut = (FrmCheckOut)this.Owner;
            frmCheckOut.BtnGenerateBill.Visible = true;
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmCheckOut frmCheckOut = (FrmCheckOut)this.Owner;
            frmCheckOut.BtnGenerateBill.Visible = true;
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if(Regex.Match(TxtDiscount.Text.Trim(), Helpers.RegexPatterns.DecimalPattern).Success){
                e.Handled = false;
                if (TxtDiscount.Text.Trim() == "")
                {
                    LblFullCharge.Text = "Total a pagar: ";
                }
                else
                {
                    double subtotal = Convert.ToDouble(TxtSubtotal.Text.Trim());
                    double discount = Convert.ToDouble(TxtDiscount.Text.Trim());
                    LblFullCharge.Text = "Total a pagar: " + ((subtotal - discount) + Convert.ToDouble(TxtISV.Text.Trim()));
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ChkClaim_CheckedChanged(object sender, EventArgs e)
        {
            double subtotal = Convert.ToDouble(TxtSubtotal.Text.Trim());
            if (ChkClaim.Checked)
            {
                DISCOUNTS claim = dc.getDiscount(3);
                ChkClaim.Text += " " + claim.DISCOUNT_VALUE;

                amountClaimDiscount = subtotal * (Convert.ToDouble(claim.DISCOUNT_VALUE.Replace("%",""))/100);

                double discount = Convert.ToDouble(TxtDiscount.Text.Trim()) + amountClaimDiscount;
                TxtDiscount.Text = discount.ToString();
                LblFullCharge.Text = "Total a pagar: " + ((subtotal - discount) + Convert.ToDouble(TxtISV.Text.Trim()));
            }
            else
            {
                
                DISCOUNTS claim = dc.getDiscount(10);
                ChkClaim.Text = "Reclamo";
                amountClaimDiscount = 0; 

                TxtDiscount.Text = (amountDiscountFF + amountDiscountFT).ToString();
                double discount = Convert.ToDouble(TxtDiscount.Text.Trim()) - amountClaimDiscount;
                LblFullCharge.Text = "Total a pagar: " + ((subtotal - discount) + Convert.ToDouble(TxtISV.Text.Trim()));
               
            }
        }

        private async void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                BILL newBill = new BILL();
                string nextBillCode= moduleId + correlativesController.getNextId(moduleId);
                string nextBillNumber= billController.GenerateNextBillNumber();
                newBill.BILL_CODE = nextBillCode;
                newBill.DATE_OF_ISSUE = DateTime.Now;
                newBill.BILL_NUMBER = nextBillNumber; 
                newBill.SUBTOTAL = Convert.ToDecimal(Regex.Replace(LblFullCharge.Text, @"^[^0-9]*|\s|[^0-9.]|(?<=\.\d)\./", ""));
                newBill.DISCOUNT = Convert.ToDecimal(Regex.Replace(TxtDiscount.Text, @"^[^0-9]*|\s|[^0-9.]|(?<=\.\d)\./", ""));
                newBill.ISV = Convert.ToDecimal(Regex.Replace(TxtISV.Text, "%", ""));
                newBill.CHECK_OUT_CODE = TxtCheckOutCode.Text;
                newBill.USER_CODE = Config.User.userId;
                newBill.RTN = String.IsNullOrEmpty(TxtRTN.Text) ? null : TxtRTN.Text.Trim();
                newBill.TOTAL = Convert.ToDecimal(Regex.Replace(LblFullCharge.Text, @"^[^0-9]*|\s|[^0-9.]|(?<=\.\d)\./", ""));
                newBill.LETTERS = h.ConvertAmountToWords(Convert.ToDecimal(Regex.Replace(LblFullCharge.Text, @"^[^0-9]*|\s|[^0-9.]|(?<=\.\d)\./", "")));
                

                if (billController.saveBill(newBill) > 0)
                {
                    DISCOUNTS_BILL discountBillFT = new DISCOUNTS_BILL(), discountBillFF= new DISCOUNTS_BILL();
                    PARKING_SPACE ps = pspController.getParkingSpace(psCode);
                    ps.STATE = false;

                    if (pspController.updateParkingSpace(ps) <= 0)
                    {
                        h.MsgError("HA OCURRIDO UN ERROR AL ACTUALIZAR EL ESTADO DEL PARQUEO");
                        return;
                    }

                    if(discountIdFF!=0)
                    {
                        discountBillFF.BILL_CODE = nextBillCode;
                        discountBillFF.DISCOUNT_ID = discountIdFF;
                        discountBillFF.DISCOUNT_AMOUNT = Convert.ToDecimal(amountDiscountFF);
                        discountBillFF.INSERTED_AT = DateTime.Now;
                        discountBillFF.USER_CODE= Config.User.userId;

                        if(discountsBillController.saveDiscountsBill(discountBillFF) <= 0)
                        {
                            h.MsgError("HA OCURRIDO UN ERROR AL GUARDAR EL DESCUENTO POR FRECUENCIA");
                            return;
                        }
                    }

                    if (discountIdFT != 0)
                    {
                        discountBillFT.BILL_CODE = nextBillCode;
                        discountBillFT.DISCOUNT_ID = discountIdFT;
                        discountBillFT.DISCOUNT_AMOUNT = Convert.ToDecimal(amountDiscountFT);
                        discountBillFT.INSERTED_AT = DateTime.Now;
                        discountBillFT.USER_CODE = Config.User.userId;

                        if (discountsBillController.saveDiscountsBill(discountBillFT) <= 0)
                        {
                            h.MsgError("HA OCURRIDO UN ERROR AL GUARDAR EL DESCUENTO POR TIEMPO");
                            return;
                        }
                    }

                    if (ChkClaim.Checked)
                    {
                        DISCOUNTS_BILL claimDiscount= new DISCOUNTS_BILL();

                        claimDiscount.BILL_CODE = nextBillCode;
                        claimDiscount.DISCOUNT_ID = 3;
                        claimDiscount.DISCOUNT_AMOUNT = Convert.ToDecimal(amountClaimDiscount);
                        claimDiscount.INSERTED_AT = DateTime.Now;
                        claimDiscount.USER_CODE = Config.User.userId;

                        if (discountsBillController.saveDiscountsBill(claimDiscount) <= 0)
                        {
                            h.MsgError("HA OCURRIDO UN ERROR AL GUARDAR EL DESCUENTO POR TIEMPO");
                            return;
                        }

                    }


                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {User.userName} generó la factura No. {nextBillNumber} con código {nextBillCode}.", moduleId, DateTime.Now);
                    h.MsgSuccess("LA FACTURA SE HA GENERADO CORRECTAMENTE");

                    CHECK_OUT checkOut = checkOutController.getCheckOut(TxtCheckOutCode.Text);
                    checkOut.CHECK_OUT_STATE = "FACTURADO";
                    checkOutController.updateCheckOut(checkOut);
                    FrmCheckOut frmCheckOut = (FrmCheckOut)this.Owner;
                    frmCheckOut.startForm();
                    this.Hide();
                    Reports.FrmGeneratedBillReport frmGeneratedBillReport = new Reports.FrmGeneratedBillReport();
                    frmGeneratedBillReport.billCode = nextBillCode;
                    frmGeneratedBillReport.ShowDialog();
                }
                else
                {
                    h.MsgError("HA OCURRIDO UN ERROR AL GENERAR LA FACTURA");
                }
            }

        }

        public int validateData()
        {
            int error = 0;

            if (!String.IsNullOrEmpty(TxtRTN.Text))
            {
                if (!Regex.IsMatch(TxtRTN.Text, Helpers.RegexPatterns.RTNPattern))
                {
                    h.MsgError("EL RTN DEBE CONTENER 14 DIGITOS");
                    error++;
                    return error;
                }
            }

            if(!Regex.Match(TxtDiscount.Text.Trim(), Helpers.RegexPatterns.DecimalPattern).Success)
            {
                h.MsgError("INGRESAR EL DESCUENTO CORRECTAMENTE. ¡SOLO NUMEROS ENTEROS O DECIMALES CON DOS CIFRAS DESPUES DEL PUNTO!");
                error++;
                return error;
            }


            return error;
        }

        private void FrmGenerateBill_Load(object sender, EventArgs e)
        {
            BtnGenerateBill.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            TxtDiscount.Enabled = true;
            
            if (discountIdFF != 0) {
                ChkClientFrequently.Checked = true;
                DISCOUNTS discountFF = dc.getDiscount(discountIdFF);
                if (discountFF != null)
                {
                    ChkClientFrequently.Text += " " + discountFF.DISCOUNT_VALUE;
                }
                
            }
            if (discountIdFT != 0){
                ChkLengthOfStay.Checked = true;
                DISCOUNTS discountFT = dc.getDiscount(discountIdFT);
                if (discountFT != null)
                {
                    ChkLengthOfStay.Text += " " + discountFT.DISCOUNT_VALUE;
                }
            }
            
        }

    }
}
