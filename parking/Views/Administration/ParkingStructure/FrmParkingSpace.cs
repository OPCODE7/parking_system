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
using System.Windows.Forms.VisualStyles;

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmParkingSpace : Form
    {
        ParkingSpaceController psc= new ParkingSpaceController();
        Helpers.Helpers h= new Helpers.Helpers();
        CorrelativesController correlativeController= new CorrelativesController();
        ParkingFeeController parkingFeeController= new ParkingFeeController();
        string psCode,parkingFee,userId,moduleId= "PSP";
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
            startForm();
        }

        private void startForm()
        {
            fillCmbParkingFee();
            getParkingSpaces("");
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId,"Crear");
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
            TxtPrice.Enabled = false;

            CmbParkingFee.Enabled = false;
            CmbParkingFee.SelectedIndex = -1;

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
                newPs.PARKING_FEE_CODE = parkingFee;
                newPs.STATE = psState;
                newPs.USER_CODE = userId;
                newPs.INSERTED_AT = DateTime.Now;
                
                if(psc.saveParkingSpace(newPs) > 0)
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
            psCode= TxtParkingSpaceCode.Text;
            psNumber= Convert.ToInt32(h.SanitizeStr(TxtNumberSpace.Text.Trim()));
            parkingFee= CmbParkingFee.SelectedValue.ToString();
            psState = ChkState.Checked ? true : false;
            userId = Config.User.userId;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtPrice.Enabled = true;
            CmbParkingFee.Enabled = true;
            ChkState.Enabled = true;
            TxtNumberSpace.Enabled = true;

            TxtNumberSpace.Focus();

            string nextPsCode = moduleId + correlativeController.getNextId(moduleId);
            TxtParkingSpaceCode.Text = nextPsCode;
        }

        private int validateData()
        {
            int error = 0;

            if (!Regex.Match(TxtNumberSpace.Text, RegexPatterns.NumberPattern).Success) {
                h.MsgError("INGRESAR CORRECTAMENTE EL NÚMERO DEL ESPACIO DE PARQUEO. ¡SÓLO NÚMEROS!");
                error++;
                TxtPrice.Focus();
                return error;
            }

            if (CmbParkingFee.SelectedValue == null)
            {
                h.MsgError("SELECCIONAR TIPO DE PARQUEO.");
                error++; 
                TxtPrice.Focus();
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
            dynamic ps = psc.getInfoParkingSpace(TxtParkingSpaceCode.Text);
            
            if (h.MsgQuestion(Helpers.App.Msg0002)=="S")
            {
                
                if (validateData() == 0)
                {
                    setValues();
                    PARKING_SPACE editPs = psc.getParkingSpace(TxtParkingSpaceCode.Text);
                    editPs.PARKING_SPACE_NUMBER = psNumber;
                    editPs.PARKING_FEE_CODE = parkingFee;
                    editPs.STATE = psState;
                    if (psc.updateParkingSpace(editPs) > 0)
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            PARKING_SPACE ps = psc.getInfoParkingSpace(TxtParkingSpaceCode.Text);
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                if(psc.deleteParkingSpace(ps.PARKING_SPACE_CODE) > 0)
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

      

        private void CmbParkingFee_TextChanged(object sender, EventArgs e)
        {
            if (CmbParkingFee.SelectedValue != null && CmbParkingFee.SelectedValue.GetType().ToString() == "System.String")
            {
                PARKING_FEE pf = parkingFeeController.getParkingFee(CmbParkingFee.SelectedValue.ToString());
                if (pf != null) TxtPrice.Text = pf.PRICE_FOR_HOUR.ToString();
            }
        }

        private void DgvParkingTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvParkingTypes.Rows.Count > 0) {
                BtnNew.Enabled = false;
                BtnEdit.Enabled = PermissionManager.HasPermission(moduleId,"Modificar");
                BtnDelete.Enabled = PermissionManager.HasPermission(moduleId,"Eliminar");
                BtnCancel.Enabled = true;
                BtnSave.Enabled = false;
                CmbParkingFee.Enabled = true;
                ChkState.Enabled = true;
                TxtNumberSpace.Enabled = true;

                var ps = psc.getInfoParkingSpace(DgvParkingTypes.CurrentRow.Cells[0].Value.ToString());

                TxtParkingSpaceCode.Text = ps.PARKING_SPACE_CODE;
                TxtNumberSpace.Text = ps.PARKING_SPACE_NUMBER.ToString();
                CmbParkingFee.SelectedValue = ps.PARKING_FEE_CODE;
                ChkState.Checked = (bool)ps.STATE;
                TxtPrice.Text = ps.PRICE_FOR_HOUR.ToString();
                TxtNumberSpace.Focus();
            }

        }

        private void getParkingSpaces(string searchFilter)
        {
            DgvParkingTypes.Rows.Clear();
            var parkingSpaces= psc.getParkingSpaces(searchFilter);

            if (parkingSpaces.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
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

        public void fillCmbParkingFee()
        {
            CmbParkingFee.DataSource = parkingFeeController.getParkingFees("").ToList();
            CmbParkingFee.ValueMember = "PARKING_FEE_CODE";
            CmbParkingFee.DisplayMember = "DESCRIPTION_PARKING_TYPE";
        }
    }
}
