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

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmParkingFee : Form
    {
        CorrelativesController correlativeController = new CorrelativesController();
        Helpers.Helpers h = new Helpers.Helpers();
        ParkingFeeController parkingFeeController = new ParkingFeeController();
        ParkingTypeController parkingTypeController = new ParkingTypeController();

        string pfCode, ptCode,userId,moduleId= "PKF";
        decimal pfPrice;
        bool flagIsPaperbin;
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
            getParkingFees("",false);
            flagIsPaperbin = false;
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId,"Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
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
            CmbParkingTypes.DataSource = parkingTypeController.getParkingTypes("",false);
            CmbParkingTypes.DisplayMember = "DESCRIPTION_PARKING_TYPE";
            CmbParkingTypes.ValueMember = "PARKING_TYPE_CODE";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void getParkingFees(string searchFilter,bool isDel)
        {
            DgvParkingFees.Rows.Clear();
            var parkingFees = parkingFeeController.getParkingFees(searchFilter,isDel);
            if (parkingFees.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getParkingFees("",isDel);
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

            if (!Regex.Match(TxtPrice.Text,RegexPatterns.DecimalPattern).Success)
            {
                h.MsgWarning("INGRESAR EL PRECIO CORRECTAMENTE. !SOLO NÚMEROS ENTEROS O DECIMALES CON DOS CIFRAS DESPÚES DEL PUNTO¡");
                error++;
                TxtPrice.Focus();
                return error;
            }

            if (CmbParkingTypes.SelectedValue == null)
            {
                h.MsgWarning("SELECCIONAR TIPO DE PARQUEO.");
                error++;
                CmbParkingTypes.Focus();
                return error;

            }

            if (CmbParkingTypes.SelectedValue != null && parkingFeeController.getParkingFees("", false).Any(pf => pf.PARKING_TYPE_CODE == CmbParkingTypes.SelectedValue.ToString())==true){
               
                h.MsgWarning("YA EXISTE UNA TARIFA ASOCIADA A ESTE TIPO DE PARQUEO!");
                error++;
                CmbParkingTypes.Focus();
                return error;
            }
            return error;
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getParkingFees(TxtSearch.Text.Trim(), flagIsPaperbin);
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getParkingFees("",flagIsPaperbin);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getParkingFees(TxtSearch.Text.Trim(),flagIsPaperbin);
            }
        }

        private void DgvParkingFees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
            BtnDelete.Enabled = PermissionManager.HasPermission(moduleId,"Eliminar");
            BtnEdit.Enabled = flagIsPaperbin ? false : true;
            BtnDelete.Enabled= flagIsPaperbin ? false : true;
            PbxRecovery.Enabled = PermissionManager.HasPermission("PAP","Modificar");
            PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");



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
            if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
            {
                if (validateData() == 0)
                {
                    setValues();

                    pf.PRICE_FOR_HOUR = pfPrice;
                    pf.PARKING_TYPE_CODE= ptCode;

                    if (parkingFeeController.updateParkingFee(pf) > 0)
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

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            flagIsPaperbin = true;
            getParkingFees("", flagIsPaperbin);
            
        }

        private void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                PARKING_FEE pf = parkingFeeController.getParkingFee(TxtParkingFeeCode.Text.Trim());
                pf.IS_DEL = false;
                if (parkingFeeController.updateParkingFee(pf) > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0010);
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
                PARKING_FEE pf = parkingFeeController.getParkingFee(TxtParkingFeeCode.Text.Trim());
                if (parkingFeeController.deleteParkingFee(pf) > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        { 
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                PARKING_FEE pf = parkingFeeController.getParkingFee(TxtParkingFeeCode.Text.Trim());
                pf.IS_DEL = true;
                if (parkingFeeController.updateParkingFee(pf) > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
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

            string nextCode = moduleId + correlativeController.getNextId(moduleId);
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
                    h.MsgSuccess(Helpers.App.Msg0001);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0015);
                }
            }

        }
    }
}
