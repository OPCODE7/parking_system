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

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmParkingFee : Form
    {
        CorrelativesController correlativeController = new CorrelativesController();
        Helpers.Helpers h = new Helpers.Helpers();
        ParkingFeeController parkingFeeController = new ParkingFeeController();
        ParkingTypeController parkingTypeController = new ParkingTypeController();

        string pfCode, ptCode,userId;
        decimal pfPrice;
        public FrmParkingFee()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmParkingFee_Load(object sender, EventArgs e)
        {
            fillCmbParkingTypes();
            startForm();

        }

        private void startForm()
        {
            getParkingFees("");
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnNew.Enabled = true;

            TxtParkingFeeCode.Enabled = false;
            TxtPrice.Enabled = false;
            TxtPrice.Clear();
            TxtParkingFeeCode.Clear();
            CmbParkingTypes.Enabled = false;
            CmbParkingTypes.SelectedIndex = -1;
            TxtSearch.Focus();
        }

        private void fillCmbParkingTypes()
        {
            CmbParkingTypes.DataSource = parkingTypeController.getParkingTypes("");
            CmbParkingTypes.DisplayMember = "DESCRIPTION_PARKING_TYPE";
            CmbParkingTypes.ValueMember = "PARKING_TYPE_CODE";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void getParkingFees(string searchFilter)
        {
            DgvParkingFees.Rows.Clear();
            var parkingFees = parkingFeeController.getParkingFees(searchFilter);
            if (parkingFees.Count() == 0)
            {
                h.MsgInfo("No hay registros en la base de datos.");
                if (searchFilter != "")
                {
                    getParkingFees("");
                }
                return;
            }

            foreach(var pf in parkingFees)
            {
                DgvParkingFees.Rows.Add(pf.PARKING_FEE_CODE, pf.PRICE_FOR_HOUR,pf.DESCRIPTION_PARKING_TYPE,pf.USER_NAME,Convert.ToDateTime(pf.INSERTED_AT).ToShortDateString());
            }
            
        }

        private void setValues()
        {
            pfCode= TxtParkingFeeCode.Text;
            ptCode = CmbParkingTypes.SelectedValue.ToString();
            pfPrice = Convert.ToDecimal(h.SanitizeStr(TxtPrice.Text.Trim()));
            userId= Config.User.userId;
        }
        private int validateData()
        {
            int error = 0;
            string decimals = "^\\d+(\\.\\d{2})?$";

            if (!Regex.Match(TxtPrice.Text,decimals).Success)
            {
                h.MsgWarning("Ingresar el precio correctamente. !Solo números enteros o decimales con dos cifras despúes del punto¡");
                error++;
                TxtPrice.Focus();
                return error;
            }

            if (CmbParkingTypes.SelectedValue == null)
            {
                h.MsgWarning("Seleccionar tipo de parqueo.");
                error++;
                CmbParkingTypes.Focus();
                return error;

            }
            return error;
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getParkingFees(TxtSearch.Text.Trim());
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getParkingFees("");
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getParkingFees(TxtSearch.Text.Trim());
            }
        }

        private void DgvParkingFees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = true;
            BtnDelete.Enabled = true;

            TxtPrice.Enabled = true;
            CmbParkingTypes.Enabled = true;
            TxtPrice.Focus();

            PARKING_FEE pf = parkingFeeController.getParkingFee(DgvParkingFees.CurrentRow.Cells[0].Value.ToString());
            TxtParkingFeeCode.Text = pf.PARKING_FEE_CODE;
            TxtPrice.Text = pf.PRICE_FOR_HOUR.ToString();
            CmbParkingTypes.SelectedValue = pf.PARKING_TYPE_CODE;


        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PARKING_FEE pf= parkingFeeController.getParkingFee(TxtParkingFeeCode.Text.Trim());
            if (h.MsgQuestion($"¿Estás seguro de eliminar la tarifa?") == "S")
            {
                if (validateData() == 0)
                {
                    setValues();

                    pf.PRICE_FOR_HOUR = pfPrice;
                    pf.PARKING_TYPE_CODE= ptCode;

                    if (parkingFeeController.updateParkingFee(pf) > 0)
                    {
                        h.MsgSuccess("La tarifa se actualizó correctamente");
                        startForm();

                    }
                    else
                    {
                        h.MsgError("La tarifa no pudo ser actualizada.");
                    }
                }
               

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            PARKING_FEE pf = parkingFeeController.getParkingFee(TxtParkingFeeCode.Text.Trim());

            if (h.MsgQuestion("¿Estás seguro que deseas eliminar la tarifa?") == "S")
            {
                if (parkingFeeController.deleteParkingFee(pf) > 0)
                {
                    h.MsgSuccess("La tarifa se eliminó correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("La tarifa no pudo ser eliminada.");
                }

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnNew.Enabled = false;

            TxtPrice.Enabled = true;
            CmbParkingTypes.Enabled = true;

            string nextCode = "PKF" + correlativeController.getNextId("PKF");
            TxtParkingFeeCode.Text = nextCode;
            TxtPrice.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                PARKING_FEE newPf = new PARKING_FEE();
                newPf.PARKING_FEE_CODE = pfCode;
                newPf.PRICE_FOR_HOUR = pfPrice;
                newPf.PARKING_TYPE_CODE = ptCode;
                newPf.INSERTED_AT = DateTime.Now;
                newPf.USER_CODE = userId;

                if(parkingFeeController.saveParkingFee(newPf) > 0)
                {
                    h.MsgSuccess("La tarifa de parqueo se guardó correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("La tarifa de parqueo no se guardó correctamente.");
                }
            }

        }
    }
}
