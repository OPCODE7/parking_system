using parking.Config;
using parking.Controllers;
using parking.Helpers;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Configuration
{
    public partial class FrmCompany : Form
    {
        string rtn, companyName, companyAddress, companyPhone, companyEmail,legaForm, moduleId= "COMP";
        bool exist= false;

        Helpers.Helpers h = new Helpers.Helpers();
        CompanyDataController cdc= new CompanyDataController();

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                if (exist)
                {
                    COMPANY_DATA companyData= cdc.getCompanyData(rtn);
                    companyData.COMPANY_RTN = rtn;
                    companyData.COMPANY_NAME = companyName;
                    companyData.COMPANY_ADDRESS = companyAddress;
                    companyData.COMPANY_PHONE = companyPhone;
                    companyData.COMPANY_EMAIL = companyEmail;
                    companyData.LEGAL_FORM = legaForm;

                    if(cdc.updateCompanyData(companyData)>0)
                    {
                        h.MsgSuccess(App.Msg0003);
                    }
                    else
                    {
                        h.MsgError(App.Msg0017);
                    }

                }
                else
                {
                    COMPANY_DATA newCompanyData = new COMPANY_DATA();
                    newCompanyData.COMPANY_RTN = rtn;
                    newCompanyData.COMPANY_NAME = companyName;
                    newCompanyData.COMPANY_ADDRESS = companyAddress;
                    newCompanyData.COMPANY_PHONE = companyPhone;
                    newCompanyData.COMPANY_EMAIL = companyEmail;
                    newCompanyData.LEGAL_FORM = legaForm;
                    newCompanyData.INSERTED_AT = DateTime.Now;
                    newCompanyData.USER_ID = Config.User.userId;

                    if (cdc.saveCompanyData(newCompanyData) > 0)
                    {
                        h.MsgSuccess(App.Msg0001);
                    }
                    else
                    {
                        h.MsgError(App.Msg0015);
                    }
                }
            }
        }

        public FrmCompany()
        {
            InitializeComponent();
        }

        private void setValues()
        {
            rtn = h.SanitizeStr(TxtRTN.Text.Trim());
            companyName = h.SanitizeStr(TxtCompanyName.Text.Trim());
            companyAddress = h.SanitizeStr(TxtAddress.Text.Trim());
            companyPhone = h.SanitizeStr(MskPhone.Text.Trim());
            companyEmail = h.SanitizeStr(TxtEmail.Text.Trim());
            legaForm = h.SanitizeStr(TxtLegalForm.Text.Trim());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            startForm();
           
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int validateData()
        {
            int error = 0;
            if (!Regex.Match(TxtRTN.Text, RegexPatterns.NumberPattern).Success)
            {
                h.MsgError("INGRESAR RTN CORRECTAMENTE ¡SOLO NUMEROS!");
                error++;
                return error;
            }

            if (!Regex.Match(TxtCompanyName.Text, RegexPatterns.AlphabeticPattern).Success)
            {
                h.MsgError("INGRESAR NOMBRE DE LA EMPRESA CORRECTAMENTE ¡SOLO LETRAS!");
                error++;
                return error;
            }

            if (!Regex.Match(TxtEmail.Text, RegexPatterns.EmailPattern).Success)
            {
                h.MsgError("INGRESAR EMAIL CORRECTAMENTE");
                error++;
                return error;
            }

            if (!Regex.Match(TxtAddress.Text, RegexPatterns.AddressPattern).Success)
            {
                h.MsgError("INGRESAR DIRECCION CORRECTAMENTE");
                error++;
                return error;
            }

            if (MskPhone.Text=="")
            {
                h.MsgError("INGRESAR NUMERO TELEFONICO");
                error++;
                return error;
            }

          

            if (!Regex.Match(TxtLegalForm.Text, RegexPatterns.AlphabeticPattern).Success)
            {
                h.MsgError("INGRESAR FORMAL LEGAL CORRECTAMENTE ¡SOLO LETRAS!");
                error++;
                return error;
            }

            return error;
        }

        private void startForm()
        {
            TxtRTN.Focus();
            List<COMPANY_DATA> companies = cdc.getCompanies();
            if (companies.Count == 0)
            {
                foreach (TextBox Txt in groupBox1.Controls.OfType<TextBox>())
                {
                    Txt.Clear();
                }
                
                MskPhone.Clear();
                return;
            }

            getInfoCompany(companies[0].COMPANY_RTN);
            exist = true;
            BtnSave.Enabled = PermissionManager.HasPermission(moduleId,"Crear");

        }

        private void getInfoCompany(string rtn)
        {
            COMPANY_DATA companyData = cdc.getCompanyData(rtn);
            if (companyData != null)
            {
                TxtRTN.Text = companyData.COMPANY_RTN;
                TxtCompanyName.Text = companyData.COMPANY_NAME;
                TxtAddress.Text = companyData.COMPANY_ADDRESS;
                MskPhone.Text = companyData.COMPANY_PHONE;
                TxtEmail.Text = companyData.COMPANY_EMAIL;
                TxtLegalForm.Text = companyData.LEGAL_FORM;
            }
            else
            {
                h.MsgInfo(App.Msg0011);
            }
        }
    }
}
