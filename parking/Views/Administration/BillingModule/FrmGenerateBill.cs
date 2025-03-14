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
        public FrmGenerateBill()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmCheckOut frmCheckOut = (FrmCheckOut)this.Owner;
            frmCheckOut.startForm();
        }

        private void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                BILL newBill = new BILL();
                newBill.BILL_CODE = "FAC" + correlativesController.getNextId("FAC");
                newBill.DATE_OF_ISSUE = DateTime.Now;
                newBill.BILL_NUMBER = billController.GenerateNextBillNumber();
                newBill.SUBTOTAL = Convert.ToDecimal(Regex.Replace(TxtSubtotal.Text, @"[^\d]", ""));
                newBill.DISCOUNT = Convert.ToDecimal(Regex.Replace(TxtDiscount.Text, @"[^\d]", ""));
                newBill.ISV = Convert.ToDecimal(Regex.Replace(TxtISV.Text, "%", ""));
                newBill.CHECK_OUT_CODE = TxtCheckOutCode.Text;
                newBill.USER_CODE = Config.User.userId;
                newBill.RTN = String.IsNullOrEmpty(TxtRTN.Text) ? null : TxtRTN.Text.Trim();
                newBill.TOTAL = Convert.ToDecimal(Regex.Replace(LblFullCharge.Text, @"[^\d]", ""));
                newBill.LETTERS = h.ConvertAmountToWords(Convert.ToDecimal(Regex.Replace(LblFullCharge.Text, @"[^\d]", "")));
                

                if (billController.saveBill(newBill) > 0)
                {
                    h.MsgSuccess("La factura se ha generado correctamente");
                    CHECK_OUT checkOut= checkOutController.getCheckOut(TxtCheckOutCode.Text);
                    checkOut.CHECK_OUT_STATE = "FACTURADO";
                    checkOutController.updateCheckOut(checkOut);
                    this.Close();
                    Reports.FrmGeneratedBillReport frmGeneratedBillReport = new Reports.FrmGeneratedBillReport();
                    frmGeneratedBillReport.ShowDialog();
                }
                else
                {
                    h.MsgError("Ha ocurrido un error al generar la factura");
                }
            }

        }

        public int validateData()
        {
            int error = 0;
            string rtnRegex = @"^\d{14}$";

            if (!String.IsNullOrEmpty(TxtRTN.Text))
            {
                if (!Regex.IsMatch(TxtRTN.Text, rtnRegex))
                {
                    h.MsgError("El RTN debe contener 14 dígitos");
                    error++;
                    return error;
                }
            }
            return error;
        } 
    }
}
