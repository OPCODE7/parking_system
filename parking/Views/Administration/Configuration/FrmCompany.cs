using parking.Controllers;
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
        string rtn, companyName, companyAddress, companyPhone, companyEmail,legaForm;
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
                        h.MsgSuccess("Datos de la empresa actualizados correctamente");
                    }
                    else
                    {
                        h.MsgError("Error al actualizar los datos de la empresa");
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
                        h.MsgSuccess("Datos de la empresa guardados correctamente");
                    }
                    else
                    {
                        h.MsgError("Error al guardar los datos de la empresa");
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
            string onlyNumbers = "^[0-9]+$";
            string onlyLetters = "^[a-zA-Z\\s]+$";
            string address = "^[a-zA-Z0-9,.\\s]+$";
            string emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$";

            if (!Regex.Match(TxtRTN.Text, onlyNumbers).Success)
            {
                h.MsgError("Ingresar RTN correctamente");
                error++;
                return error;
            }

            if (!Regex.Match(TxtCompanyName.Text, onlyLetters).Success)
            {
                h.MsgError("Ingresar nombre de la empresa correctamente");
                error++;
                return error;
            }

            if (!Regex.Match(TxtEmail.Text, emailPattern).Success)
            {
                h.MsgError("Ingresar email de la empresa correctamente");
                error++;
                return error;
            }

            if (!Regex.Match(TxtAddress.Text, address).Success)
            {
                h.MsgError("Ingresar dirección de la empresa correctamente");
                error++;
                return error;
            }

            if (MskPhone.Text=="")
            {
                h.MsgError("Ingresar número de teléfono de la empresa correctamente");
                error++;
                return error;
            }

          

            if (!Regex.Match(TxtLegalForm.Text, onlyLetters).Success)
            {
                h.MsgError("Ingresar forma legal de la empresa correctamente");
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
        }
    }
}
