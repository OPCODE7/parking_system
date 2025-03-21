using parking.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmSearchCheckIn : Form
    {
        CheckInController checkInController = new CheckInController();
        Helpers.Helpers h = new Helpers.Helpers();
        public FrmSearchCheckIn()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSearchCheckIn_Load(object sender, EventArgs e)
        {
            getCheckIns("","ACTIVO");

        }

        private void getCheckIns(string searchFilter = "",string state="")
        {
            DgvCheckIns.Rows.Clear();
            var checkIns = checkInController.getCheckIns(searchFilter,"ACTIVO");

            if (checkIns.Count() == 0)
            {
                h.MsgInfo("No se encontraron registros.");
                if (searchFilter != "")
                {
                    getCheckIns("","ACTIVO");
                }
                return;
            }

            foreach (var checkIn in checkIns)
            {
                DgvCheckIns.Rows.Add(checkIn.CHECK_IN_CODE,checkIn.CLIENT_NAME+" "+ checkIn.CLIENT_LASTNAME, checkIn.PARKING_SPACE_NUMBER, checkIn.VEHICLE_PLATE , checkIn.DESCRIPTION_PARKING_TYPE, checkIn.INSERTED_AT);
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            getCheckIns(TxtSearch.Text.Trim());
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getCheckIns(TxtSearch.Text.Trim());
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getCheckIns();
        }

        private void DgvCheckIns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DgvCheckIns.Rows.Count >0)
            {
                string checkInCode = DgvCheckIns.CurrentRow.Cells[0].Value.ToString();
                FrmCheckOut frmCheckOut = (FrmCheckOut)this.Owner;
                frmCheckOut.getInfoCheckIn(checkInCode);
                this.Close();
            }
        }
    }
}
