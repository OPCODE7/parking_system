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

namespace parking.Views.Administration.Clients
{
    public partial class FrmClient : Form
    {
        CorrelativesController correlativesController = new CorrelativesController();
        ClientController clientController = new ClientController();
        Helpers.Helpers h = new Helpers.Helpers();
        string userId, clientId, clientName, clientLastName, clientEmail,clientDni, clientAddress, clientPhone;

        public object TxtEmail { get; private set; }

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
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnNew.Enabled = true;
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
                if (h.MsgQuestion("¿Estás seguro de modificar este cliente?") == "S")
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
                        h.MsgInfo("Cliente actualizado correctamente.");
                        startForm();
                    }
                    else
                    {
                        h.MsgError("Error al actualizar cliente.");
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(h.MsgQuestion("¿Estás seguro de eliminar este cliente?") == "S")
            {
                if(clientController.deleteClient(TxtClientCode.Text.Trim()) > 0)
                {
                    h.MsgInfo("Cliente eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al eliminar cliente.");
                }
            }
        }

        private void DgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = true;

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

            string newCode = "CLI" + correlativesController.getNextId("CLI");
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
                    h.MsgInfo("Cliente guardado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al guardar cliente.");
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
            string onlyNumbers = "^[0-9]+$";
            string onlyLetters = "^[a-zA-Z\\s]+$";
            string address = "^[a-zA-Z0-9,.\\s]+$";
            string emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$";

            if (!Regex.Match(TxtDni.Text, onlyNumbers).Success)
            {
                
                h.MsgWarning("Ingresar DNI de usuario correctamente. ¡Solo números!");
                error++;
                TxtDni.Focus();
                return error;

            }

            if (!Regex.Match(TxtName.Text, onlyLetters).Success)
            {
                h.MsgWarning("Ingresar nombre correctamente. ¡Solo letras!");
                error++;
                TxtName.Focus();
                return error;
            }

            if (!Regex.Match(TxtLastName.Text, onlyLetters).Success)
            {
                h.MsgWarning("Ingresar apellido correctamente. ¡Solo letras!");
                error++;
                TxtLastName.Focus();
                return error;
            }

            if (!Regex.Match(TxtMail.Text, emailPattern).Success)
            {
                h.MsgWarning("Ingresar email correctamente. ¡Formato de email incorrecto!");
                error++;
                TxtMail.Focus();
                return error;
            }

            if (MskPhoneNumber.Text.Trim().Length==0)
            {
                h.MsgWarning("Ingresar número telefónico.");
                error++;
                MskPhoneNumber.Focus();
                return error;
            }

            if(!Regex.Match(TxtAddress.Text, address).Success)
            {
                h.MsgWarning("Ingresar dirección correctamente. ¡Solo letras y números!");
                error++;
                TxtAddress.Focus();
                return error;
            }
            return error;
        }

        public void getClients(string searchFilter="")
        {
            DgvClients.Rows.Clear();
            var clients = clientController.getClients(searchFilter);
            if (clients.Count() == 0)
            {
                h.MsgInfo("No se encontraron resultados.");

                if(searchFilter!="")
                {
                    getClients();
                }
                return;
            }

            foreach(var client in clients)
            {
                DgvClients.Rows.Add(client.CLIENT_CODE, client.CLIENT_NAME +" "+ client.CLIENT_LASTNAME,client.CLIENT_ADDRESS, client.CLIENT_PHONE,client.USER_NAME,Convert.ToDateTime(client.INSERTED_AT).ToShortDateString());
            }

        }


    }
}
