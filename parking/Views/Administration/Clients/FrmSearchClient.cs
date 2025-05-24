using parking.Controllers;
using parking.Views.Administration.ParkingStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Clients
{
    public partial class FrmSearchClient : Form
    {
        ClientController clientController = new ClientController();
        Helpers.Helpers h= new Helpers.Helpers();
        public FrmSearchClient()
        {
            InitializeComponent();
        }

        private void FrmSearchClient_Load(object sender, EventArgs e)
        {
            getClients("",false);
        }

        public void getClients(string searchFilter = "",bool isDel= false)
        {
            DgvClients.Rows.Clear();
            var clients = clientController.getClients(searchFilter,isDel);
            if (clients.Count() == 0)
            {
                h.MsgInfo("No se encontraron resultados.");

                if (searchFilter != "")
                {
                    getClients();
                }
                return;
            }

            foreach (var client in clients)
            {
                DgvClients.Rows.Add(client.CLIENT_CODE,client.CLIENT_DNI, client.CLIENT_NAME + " " + client.CLIENT_LASTNAME, client.CLIENT_ADDRESS, client.CLIENT_PHONE, client.USER_NAME, Convert.ToDateTime(client.INSERTED_AT).ToShortDateString());
            }

        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter) getClients(TxtSearch.Text.Trim());
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getClients(TxtSearch.Text.Trim());
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getClients();
        }

        private void DgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvClients.Rows.Count > 0)
            {
                string clientCode = DgvClients.CurrentRow.Cells[0].Value.ToString();
                FrmCheckIn checkIn = new FrmCheckIn();
                checkIn = ((FrmCheckIn)Owner);
                checkIn.getInfoClient(clientCode);
                Close();
            }

        }
    }
}
