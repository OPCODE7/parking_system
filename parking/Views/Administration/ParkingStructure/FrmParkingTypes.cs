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
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmParkingTypes : Form
    {
        ParkingTypeController parkingTypeController = new ParkingTypeController();
        Helpers.Helpers h = new Helpers.Helpers();
        CorrelativesController correlativesController = new CorrelativesController();
        LogBookAppController lac= new LogBookAppController();

        string parkingTypeCode, parkingTypeDescription, moduleId = "PTY";
        bool flagIsPaperbin;
        public FrmParkingTypes()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmParkingTypes_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void setValues()
        {
            parkingTypeCode = TxtParkingTypeCode.Text;
            parkingTypeDescription = h.SanitizeStr(TxtParkingTypeDescription.Text.Trim());
        }

        private void startForm()
        {
            getparkingTypes("", false);
            flagIsPaperbin = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            BtnCancel.Enabled = false;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Clear();
            }
            TxtSearch.Enabled = true;
            TxtSearch.Focus();

        }

        private int validateData()
        {
            int error = 0;

            if (!Regex.Match(TxtParkingTypeDescription.Text, RegexPatterns.AlphabeticPatternWithAccent).Success)
            {
                h.MsgWarning("INGRESAR DESCRIPCIÓN DEL TIPO DE PARQUEO CORRECTAMENTE. ¡SOLO LETRAS!");
                TxtParkingTypeDescription.Focus();
                error++;
                return error;
            }

            return error;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                PARKING_TYPES parkingType = new PARKING_TYPES();
                parkingType.PARKING_TYPE_CODE = parkingTypeCode;
                parkingType.DESCRIPTION_PARKING_TYPE = parkingTypeDescription;
                parkingType.INSERTED_AT = DateTime.Now;

                int result = parkingTypeController.saveParkingType(parkingType);

                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó el tipo de parqueo {parkingTypeDescription}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0001);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0015);
                }
            }
        }

        private void DgvParkingTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PARKING_TYPES parkingType = parkingTypeController.getParkingType(DgvParkingTypes.CurrentRow.Cells[0].Value.ToString());
            if (parkingType != null)
            {

                BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
                BtnEdit.Enabled = flagIsPaperbin ? false : true;
                BtnDelete.Enabled = flagIsPaperbin ? false : true;
                PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");
                BtnSave.Enabled = false;
                BtnNew.Enabled = false;
                BtnCancel.Enabled = true;

                foreach (TextBox Txt in this.Controls.OfType<TextBox>())
                {
                    Txt.Enabled = true;
                }

                TxtParkingTypeDescription.Focus();


                TxtParkingTypeCode.Text = parkingType.PARKING_TYPE_CODE;
                TxtParkingTypeDescription.Text = parkingType.DESCRIPTION_PARKING_TYPE;
            }
            else
            {
                h.MsgError(Helpers.App.Msg0011);
            }

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getparkingTypes(TxtSearch.Text.Trim(), flagIsPaperbin);
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getparkingTypes("", flagIsPaperbin);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getparkingTypes(TxtSearch.Text.Trim(), flagIsPaperbin);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {

            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                PARKING_TYPES parkingType = parkingTypeController.getParkingType(TxtParkingTypeCode.Text);
                parkingType.IS_DEL = true;
                int result = parkingTypeController.updateParkingType(parkingType);

                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió el tipo de parqueo {parkingType.DESCRIPTION_PARKING_TYPE} a la papelera de reciclaje.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }

            }

        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {

            if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
            {
                if (validateData() == 0)
                {
                    setValues();
                    PARKING_TYPES pt = parkingTypeController.getParkingType(parkingTypeCode);

                    string changes = "";
                    var separator = ", ";

                    if (pt.DESCRIPTION_PARKING_TYPE!= parkingTypeDescription)
                        changes += $"DESCRIPTION_PARKING_TYPE: '{pt.DESCRIPTION_PARKING_TYPE}' → '{parkingTypeDescription}'{separator}";
                    
                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(changes))
                        changes = changes.TrimEnd(',', ' ');

                    pt.DESCRIPTION_PARKING_TYPE = parkingTypeDescription;

                    int result = parkingTypeController.updateParkingType(pt);

                    if (result > 0)
                    {
                        if (!string.IsNullOrEmpty(changes))
                        {
                            string logDesc = $"El usuario {Config.User.userName} modificó el tipo de parqueo {parkingTypeDescription}. Cambios: {changes}.";
                            await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);
                        }
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
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            flagIsPaperbin = true;
            getparkingTypes("", flagIsPaperbin);
        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {

            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                PARKING_TYPES parkingType = parkingTypeController.getParkingType(TxtParkingTypeCode.Text);
                parkingType.IS_DEL = false;
                int result = parkingTypeController.updateParkingType(parkingType);
                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró el tipo de parqueo {parkingType.DESCRIPTION_PARKING_TYPE} de la papelera.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0018);
                }

            }
        }

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                int result = parkingTypeController.deleteParkingType(TxtParkingTypeCode.Text);
                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente el tipo de parqueo {TxtParkingTypeDescription.Text}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }

            }
        }

        private void getparkingTypes(string searchFilter, bool isDel)
        {
            DgvParkingTypes.Rows.Clear();


            List<PARKING_TYPES> parkingTypes = parkingTypeController.getParkingTypes(searchFilter, isDel);

            if (parkingTypes.Count == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);

                if (searchFilter != "")
                {
                    getparkingTypes("", isDel);
                }
                return;
            }

            foreach (var parkingType in parkingTypes)
            {
                DgvParkingTypes.Rows.Add(parkingType.PARKING_TYPE_CODE, parkingType.DESCRIPTION_PARKING_TYPE, Convert.ToDateTime(parkingType.INSERTED_AT).ToShortDateString());
            }


        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;
            }
            TxtParkingTypeDescription.Focus();

            string newCode = moduleId + correlativesController.getNextId(moduleId);
            TxtParkingTypeCode.Text = newCode;

        }
    }
}
