using parking.Controllers;
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
using parking.Models;
using parking.Config;
using parking.Helpers;
using parking.DTO;

namespace parking.Views.Administration.Clients
{
    public partial class FrmClient : Form
    {
        CorrelativesController correlativesController = new CorrelativesController();
        ClientController clientController = new ClientController();
        Helpers.Helpers h = new Helpers.Helpers();
        string userId, clientId, clientName, clientLastName, clientEmail,clientDni, clientAddress, clientPhone,moduleId= "CLI";
        bool flagIsPaperbin = false;


        public FrmClient()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void startForm()
        {
            getClients("");
            flagIsPaperbin = false;
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId,"Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxDestroy.Enabled= false;
            PbxRecovery.Enabled = false;

            MskPhoneNumber.Enabled = false;
            MskPhoneNumber.Clear();
            

            foreach(TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = false;
                txt.Clear();
            }

            TxtSearch.Enabled= true;

        }

        
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
                {
                    CLIENTS editClient = clientController.getClient(TxtClientCode.Text);
                    editClient.CLIENT_DNI = clientDni;
                    editClient.CLIENT_NAME = clientName;
                    editClient.CLIENT_LASTNAME = clientLastName;
                    editClient.CLIENT_EMAIL = clientEmail;
                    editClient.CLIENT_ADDRESS = clientAddress;
                    editClient.CLIENT_PHONE = clientPhone;

                    if (clientController.updateClient(editClient) > 0)
                    {
                        h.MsgInfo(Helpers.App.Msg0003);
                        startForm();
                    }
                    else
                    {
                        h.MsgError(Helpers.App.Msg0017);
                    }
                }
            }
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            flagIsPaperbin = true;
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            getClients("", flagIsPaperbin);

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getClients(TxtSearch.Text.Trim(), flagIsPaperbin);

        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getClients("",flagIsPaperbin);
        }

        private void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                CLIENTS client = clientController.getClient(TxtClientCode.Text);
                client.IS_DEL = false;

                if (clientController.updateClient(client) > 0)
                {
                    h.MsgInfo(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0018);
                }
            }

        }

        private void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                CLIENTS client = clientController.getClient(TxtClientCode.Text);

                if (clientController.deleteClient(client.CLIENT_CODE) > 0)
                {
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }

        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PbxSearch_Click(sender, e);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                CLIENTS client= clientController.getClient(TxtClientCode.Text);
                client.IS_DEL = true;
                if(clientController.updateClient(client) > 0)
                {
                    h.MsgInfo(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }
        }

        private void DgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEdit.Enabled = PermissionManager.HasPermission(moduleId,"Modificar");
            BtnDelete.Enabled = PermissionManager.HasPermission(moduleId,"Eliminar");
            BtnEdit.Enabled = flagIsPaperbin ? false : true;
            BtnDelete.Enabled = flagIsPaperbin ? false : true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = true;
            PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
            PbxDestroy.Enabled= PermissionManager.HasPermission("PAP", "Eliminar");

            MskPhoneNumber.Enabled = true;
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = true;
            }

            CLIENTS client = clientController.getClient(DgvClients.CurrentRow.Cells[0].Value.ToString());
            TxtClientCode.Text = client.CLIENT_CODE;
            TxtName.Text = client.CLIENT_NAME;
            TxtLastName.Text = client.CLIENT_LASTNAME;
            TxtMail.Text = client.CLIENT_EMAIL;
            TxtAddress.Text = client.CLIENT_ADDRESS;
            MskPhoneNumber.Text = client.CLIENT_PHONE;
            TxtDni.Text = client.CLIENT_DNI;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;

            MskPhoneNumber.Enabled = true;

            foreach(TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = true;
                txt.Clear();
            }
            TxtDni.Focus();

            string newCode = moduleId + correlativesController.getNextId(moduleId);
            TxtClientCode.Text = newCode;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(validateData() == 0)
            {
                setValues();
                CLIENTS newClient = new CLIENTS();
                newClient.CLIENT_CODE = clientId;
                newClient.CLIENT_DNI = clientDni;
                newClient.CLIENT_NAME = clientName;
                newClient.CLIENT_LASTNAME = clientLastName;
                newClient.CLIENT_EMAIL = clientEmail;
                newClient.CLIENT_ADDRESS = clientAddress;
                newClient.CLIENT_PHONE = clientPhone;
                newClient.USER_ID = userId;
                newClient.INSERTED_AT = DateTime.Now;

                if (clientController.saveClient(newClient) > 0)
                {
                    h.MsgInfo(Helpers.App.Msg0001);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0015);
                }
            }
        }

        private void setValues()
        {
            clientId= TxtClientCode.Text;
            clientDni= h.SanitizeStr(TxtDni.Text.Trim());   
            clientName = h.SanitizeStr(TxtName.Text.Trim());
            clientLastName = h.SanitizeStr(TxtLastName.Text.Trim());
            clientEmail = h.SanitizeStr(TxtMail.Text.Trim());
            clientAddress = h.SanitizeStr(TxtAddress.Text.Trim());
            clientPhone = h.SanitizeStr(MskPhoneNumber.Text);
            userId = Config.User.userId;
        }

        private int validateData()
        {
            int error = 0;

            if (!Regex.Match(TxtDni.Text, RegexPatterns.AlphanumericPattern).Success)
            {
                
                h.MsgWarning("INGRESAR DNI DE USUARIO CORRECTAMENTE. ¡SOLO NÚMEROS O LETRAS!");
                error++;
                TxtDni.Focus();
                return error;
            }

            if (!Regex.Match(TxtName.Text, RegexPatterns.AlphabeticPatternWithAccent).Success)
            {
                h.MsgWarning("INGRESAR NOMBRE CORRECTAMENTE. ¡SOLO LETRAS!");
                error++;
                TxtName.Focus();
                return error;
            }

            if (!Regex.Match(TxtLastName.Text, RegexPatterns.AlphabeticPatternWithAccent).Success)
            {
                h.MsgWarning("INGRESAR APELLIDO CORRECTAMENTE. ¡SOLO LETRAS!");
                error++;
                TxtLastName.Focus();
                return error;
            }

            if (!Regex.Match(TxtMail.Text, RegexPatterns.EmailPattern).Success)
            {
                h.MsgWarning("INGRESAR EMAIL CORRECTAMENTE. ¡FORMATO DE EMAIL INCORRECTO!");
                error++;
                TxtMail.Focus();
                return error;
            }

            if (MskPhoneNumber.Text.Trim().Length==0)
            {
                h.MsgWarning("INGRESAR NÚMERO TELEFÓNICO.");
                error++;
                MskPhoneNumber.Focus();
                return error;
            }

            if(!Regex.Match(TxtAddress.Text, RegexPatterns.AddressPattern).Success)
            {
                h.MsgWarning("INGRESAR DIRECCIÓN CORRECTAMENTE. ¡SOLO LETRAS Y NÚMEROS!");
                error++;
                TxtAddress.Focus();
                return error;
            }
            return error;
        }

        public void getClients(string searchFilter="",bool isDel= false)
        {
            DgvClients.Rows.Clear();
            IEnumerable<ClientDTO> clients = clientController.getClients(searchFilter,isDel);
            if (clients.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);

                if(searchFilter!="")
                {
                    getClients("",isDel);
                }
                return;
            }

            foreach(var client in clients)
            {
                DgvClients.Rows.Add(client.CLIENT_CODE, client.CLIENT_NAME +" "+ client.CLIENT_LASTNAME,client.CLIENT_ADDRESS, client.CLIENT_PHONE,client.CLIENT_DNI,Convert.ToDateTime(client.INSERTED_AT).ToShortDateString());
            }
        }
    }
}
