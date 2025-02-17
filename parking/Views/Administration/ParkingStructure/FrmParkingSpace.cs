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
using System.Windows.Forms.VisualStyles;

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmParkingSpace : Form
    {
        ParkingSpaceController psc= new ParkingSpaceController();
        Helpers.Helpers h= new Helpers.Helpers();
        CorrelativesController correlativeController= new CorrelativesController();
        ParkingTypeController parkingTypeController = new ParkingTypeController();
        string psCode,parkingType,userId;
        int psNumber;
        bool psState;
        public FrmParkingSpace()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmParkingSpace_Load(object sender, EventArgs e)
        {
            fillCmbParkingTypes();
            startForm();
        }

        private void startForm()
        {
            getParkingSpaces("");
            BtnNew.Enabled = true;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            ChkState.Enabled = false;
            ChkState.Checked = false;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Clear();
            }

            CmbParkingTypes.Enabled = false;
            CmbParkingTypes.SelectedIndex = -1;

            TxtSearch.Enabled = true;
            TxtSearch.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                PARKING_SPACE newPs= new PARKING_SPACE();
                newPs.PARKING_SPACE_CODE = psCode;
                newPs.PARKING_SPACE_NUMBER = psNumber;
                newPs.PARKING_TYPE_CODE = parkingType;
                newPs.STATE = psState;
                newPs.USER_CODE = userId;
                newPs.INSERTED_AT = DateTime.Now;
                
                if(psc.saveParkingSpace(newPs) > 0)
                {
                    h.MsgInfo("Espacio de parqueo guardado correctamente");
                    startForm();
                }
                else
                {
                    h.MsgError("El espacio de parqueo no ha sido guardado correctamente.");
                }
            }
        }

        private void setValues()
        {
            psCode= TxtParkingSpaceCode.Text;
            psNumber= Convert.ToInt32(h.SanitizeStr(TxtNumberSpace.Text.Trim()));
            parkingType= CmbParkingTypes.SelectedValue.ToString();
            psState = ChkState.Checked ? true : false;
            userId = Config.User.userId;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtNumberSpace.Enabled = true;
            CmbParkingTypes.Enabled = true;
            ChkState.Enabled = true;

            TxtNumberSpace.Focus();

            string nextPsCode = "PSP" + correlativeController.getNextId("PSP");
            TxtParkingSpaceCode.Text = nextPsCode;
        }

        private int validateData()
        {
            int error = 0;
            string onlyNumbers = "^[0-9]+$";

            if (!Regex.Match(TxtNumberSpace.Text, onlyNumbers).Success) {
                h.MsgError("Ingresar correctamente el número del espacio de parqueo. ¡Sólo números!");
                error++;
                TxtNumberSpace.Focus();
                return error;
            }

            if (CmbParkingTypes.SelectedValue == null)
            {
                h.MsgError("Seleccionar tipo de parqueo.");
                error++; 
                TxtNumberSpace.Focus();
                return error;

            }
            return error;
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getParkingSpaces("");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getParkingSpaces(TxtSearch.Text.Trim());
            }
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getParkingSpaces(TxtSearch.Text.Trim());
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PARKING_SPACE ps = psc.getParkingSpace(TxtParkingSpaceCode.Text);
            if (h.MsgQuestion($"¿Estás seguro que deseas actualizar el espacio de parqueo número {ps.PARKING_SPACE_NUMBER} de la base de datos?")=="S")
            {
                if (validateData() == 0)
                {
                    setValues();
                    ps.PARKING_SPACE_NUMBER = psNumber;
                    ps.PARKING_TYPE_CODE = parkingType;
                    ps.STATE = psState;
                    if (psc.updateParkingSpace(ps) > 0)
                    {
                        h.MsgInfo("Espacio de parqueo actualizado correctamente.");
                        startForm();
                    }
                    else
                    {
                        h.MsgError("El espacio de parqueo no ha sido actualizado correctamente.");
                    }
                }
            }


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            PARKING_SPACE ps = psc.getParkingSpace(TxtParkingSpaceCode.Text);
            if (h.MsgQuestion($"¿Estás seguro que deseas eliminar el espacio de parqueo número {ps.PARKING_SPACE_NUMBER} de la base de datos?") == "S")
            {
                if(psc.deleteParkingSpace(ps.PARKING_SPACE_CODE) > 0)
                {
                    h.MsgInfo("Espacio de parqueo eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("El espacio de parqueo no ha sido eliminado correctamente.");
                }

            }
        }

        private void DgvParkingTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnNew.Enabled = false;
            BtnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            BtnCancel.Enabled = true;
            BtnSave.Enabled = false;
            TxtNumberSpace.Enabled = true;
            CmbParkingTypes.Enabled = true;
            ChkState.Enabled = true;

            PARKING_SPACE ps = psc.getParkingSpace(DgvParkingTypes.CurrentRow.Cells[0].Value.ToString());
            TxtParkingSpaceCode.Text = ps.PARKING_SPACE_CODE;
            TxtNumberSpace.Text = ps.PARKING_SPACE_NUMBER.ToString();
            CmbParkingTypes.SelectedValue = ps.PARKING_TYPE_CODE;
            ChkState.Checked = (bool)ps.STATE;
        }

        private void getParkingSpaces(string searchFilter)
        {
            DgvParkingTypes.Rows.Clear();
            var parkingSpaces= psc.getParkingSpaces(searchFilter);

            if (parkingSpaces.Count() == 0)
            {
                h.MsgInfo("No se encontraron resultados para la búsqueda.");
                if (searchFilter != "")
                {
                    getParkingSpaces("");
                }
                return;
            }

            foreach(var ps in parkingSpaces)
            {
                DgvParkingTypes.Rows.Add(
                    ps.PARKING_SPACE_CODE,
                    ps.PARKING_SPACE_NUMBER,
                    ps.PARKING_TYPE_DESCRIPTION,
                    ps.PARKING_STATE,
                    Convert.ToDateTime(ps.INSERTED_AT).ToShortDateString()
                );
            }

        }

        public void fillCmbParkingTypes()
        {
            CmbParkingTypes.DataSource = parkingTypeController.getParkingTypes("");
            CmbParkingTypes.ValueMember = "PARKING_TYPE_CODE";
            CmbParkingTypes.DisplayMember = "DESCRIPTION_PARKING_TYPE";
        }
    }
}
