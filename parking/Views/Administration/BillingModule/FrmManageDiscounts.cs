using parking.Controllers;
using parking.DTO;
using parking.Helpers;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.BillingModule
{
    public partial class FrmManageDiscounts : Form
    {
        DiscountsController dc = new DiscountsController();
        Helpers.Helpers h= new Helpers.Helpers();
        string discountTypeDescription, discountDescription, discountValue;
        int hours, days, discountId, discountTypeId;
        bool state;


        private void DgvDiscounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DiscountDTO dt= dc.getInfoDiscount(Convert.ToInt32(DgvDiscounts.CurrentRow.Cells[1].Value.ToString()));

            if(DgvDiscounts.Rows.Count > 0 || dt!=null)
            {
                BtnEdit.Enabled = true;
                ChkState.Enabled = true;
                foreach (TextBox txt in this.Controls.OfType<TextBox>())
                {
                    txt.Enabled = true;
                }
                TxtDescriptionDiscountType.Enabled = false;

                if(TxtDescriptionDiscountType.Text.ToLower()=="tiempo de estadía")
                {
                    TxtHours.Enabled = true;
                    TxtDays.Enabled = false;
                    
                }else if(TxtDescriptionDiscountType.Text.ToLower() == "cliente frecuente")
                {
                    TxtDays.Enabled = true;
                    TxtHours.Enabled = false;
                }

                discountId= dt.DISCOUNT_ID;
                discountTypeId = dt.DISCOUNT_TYPE_ID;
                TxtDescriptionDiscountType.Text= dt.DISCOUNT_TYPE_DESCRIPTION;
                TxtDiscountDescription.Text = dt.DISCOUNT_DESCRIPTION;
                TxtDiscountValue.Text = dt.DISCOUNT_PERCENTAGE.ToString();
                TxtHours.Text = dt.HOURS.ToString();
                TxtDays.Text = dt.FREQUENCY_DAYS.ToString();
                ChkState.Checked = dt.IS_ACTIVE;

            }
            else
            {
                h.MsgInfo(App.Msg0011);
            }

        }


        public FrmManageDiscounts()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(App.Msg0002) == "S")
            {
                if (validateData() ==0)
                {
                    setValues();
                    DISCOUNTS discount = dc.getDiscount(discountId);
                    discount.DISCOUNT_DESCRIPTION = discountDescription;
                    discount.DISCOUNT_VALUE = discountValue;
                    discount.HOURS = hours;
                    discount.FREQUENCY_DAYS = days;
                    discount.DISCOUNT_STATE = state;
                
                    if (dc.updateDiscount(discount) > 0)
                    {
                        h.MsgSuccess(Helpers.App.Msg0003);
                        startForm();
                    }
                    else
                    {
                        h.MsgError(Helpers.App.Msg0017);
                    }
                }
            }

        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void FrmManageDiscounts_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void setValues()
        {
            discountDescription = h.SanitizeStr(TxtDiscountDescription.Text.Trim());
            discountValue= h.SanitizeStr(TxtDiscountValue.Text.Trim());
            hours = Convert.ToInt32(h.SanitizeStr(TxtHours.Text.Trim()));
            days = Convert.ToInt32(h.SanitizeStr(TxtDays.Text.Trim()));
            state= ChkState.Checked;
        }

        private void startForm()
        {
            discountId = 0;
            discountTypeId = 0;
            BtnEdit.Enabled = false;
            foreach(TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Text = string.Empty;
                txt.Enabled = false;
            }
            ChkState.Enabled = false;
            getDiscounts();
        }

        public void getDiscounts()
        {
            DgvDiscounts.Rows.Clear();
            List<DiscountDTO> discountDTOs = dc.getAllDiscounts().ToList();

            if(discountDTOs.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                return;
            } 

            foreach (DiscountDTO discount in discountDTOs)
            {
                DgvDiscounts.Rows.Add(discount.DISCOUNT_TYPE_ID, discount.DISCOUNT_ID, discount.DISCOUNT_DESCRIPTION, discount.DISCOUNT_PERCENTAGE, discount.IS_ACTIVE, discount.HOURS, discount.FREQUENCY_DAYS);
            }
        }

        public int validateData()
        {
            int errors = 0;
            if (!Regex.Match(TxtDiscountDescription.Text,RegexPatterns.AlphabeticPatternWithAccentAndSpecialChars).Success)
            {
                h.MsgWarning("INGRESAR LA DESCRIPCION DEL DESCUENTO CORRECTAMENTE. !SOLO LETRAS, PUNTOS Y COMAS¡");
                errors++;
                return errors;
            }

            if (!Regex.Match(TxtDiscountValue.Text, RegexPatterns.Percentage).Success)
            {
                h.MsgWarning("INGRESAR EL VALOR DEL DESCUENTO CORRECTAMENTE!");
                errors++;
                return errors;
            }

            if (TxtDescriptionDiscountType.Text.ToLower() == "tiempo de estadía")
            {
                if (!Regex.Match(TxtHours.Text, RegexPatterns.NumberPattern).Success)
                {
                    h.MsgWarning("INGRESAR EL TIEMPO DE ESTADIA CORRECTAMENTE. ¡SOLO NUMEROS ENTEROS!");
                    errors++;
                    return errors;
                }
            }
            else if (TxtDescriptionDiscountType.Text.ToLower() == "cliente frecuente")
            {
                if (!Regex.Match(TxtDays.Text, RegexPatterns.NumberPattern).Success)
                {
                    h.MsgWarning("INGRESAR LOS DIAS DE FRECUENCIA CORRECTAMENTE. ¡SOLO NUMEROS ENTEROS!");
                    errors++;
                    return errors;
                }
            }
            return errors;
        }
    }
}
