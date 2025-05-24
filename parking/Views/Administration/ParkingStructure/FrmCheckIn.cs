using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using parking.Config;
using parking.Controllers;
using parking.DTO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration.ParkingStructure
{
    public partial class FrmCheckIn : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        ParkingTypeController parkingTypeController = new ParkingTypeController();
        ParkingFeeController parkingFeeController = new ParkingFeeController();
        ParkingSpaceController parkingSpaceController = new ParkingSpaceController();
        CorrelativesController correlativesController = new CorrelativesController();
        CheckInController checkInController = new CheckInController();
        ClientController clientController = new ClientController();
        LogBookAppController lac = new LogBookAppController();

        string checkInCode, clientCode, observations, vehiclePlate, status, parkingSpaceCode, moduleId = "CIN";
        bool isMarkedToEdit = false, flagIsPaperbin;
        public FrmCheckIn()
        {
            InitializeComponent();
        }

        private void FrmCheckIn_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            startForm();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void startForm()
        {
            fillCmbParkingFee();
            getCheckIns("","",false);
            flagIsPaperbin = false;
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            PbxSearchClient.Enabled = false;
            isMarkedToEdit = false;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Clear();
            }
            MskClientPhone.Clear();

            CmbParkingTypes.Enabled = false;
            CmbParkingTypes.SelectedIndex = -1;
            CmbParkingSpaces.Enabled = false;
            CmbParkingSpaces.SelectedIndex = -1;

            TxtSearch.Enabled = true;
            TxtSearch.Focus();
        }


        private void fillCmbParkingFee()
        {
            CmbParkingTypes.DataSource = parkingFeeController.getParkingFees("").ToList();
            CmbParkingTypes.ValueMember = "PARKING_FEE_CODE";
            CmbParkingTypes.DisplayMember = "DESCRIPTION_PARKING_TYPE";
        }

        private void fillCmbParkingSpaces(string parkingType, bool getAll)
        {
            IEnumerable<ParkingSpaceDTO> parkingSpaces = getAll ? parkingSpaceController.getParkingSpacesByParkingType(parkingType).ToList() : parkingSpaceController.getParkingSpacesByParkingType(parkingType).Where(pt => pt.STATE== false).ToList();

            if (parkingSpaces.Count() > 0)
            {
                CmbParkingSpaces.DataSource = parkingSpaces;
                CmbParkingSpaces.DisplayMember = "PARKING_SPACE_NUMBER";
                CmbParkingSpaces.ValueMember = "PARKING_SPACE_CODE";
            }
        }

        private void CmbParkingTypes_TextChanged(object sender, EventArgs e)
        {
            if (CmbParkingTypes.SelectedValue != null && CmbParkingTypes.SelectedValue.GetType().ToString() == "System.String")
            {
                PARKING_FEE pf = parkingFeeController.getParkingFee(CmbParkingTypes.SelectedValue.ToString());
                if (pf != null) TxtPrice.Text = pf.PRICE_FOR_HOUR.ToString();

                CmbParkingSpaces.Enabled = true;
                if (isMarkedToEdit)
                {
                    fillCmbParkingSpaces(pf.PARKING_TYPE_CODE, true);
                }
                else
                {
                    fillCmbParkingSpaces(pf.PARKING_TYPE_CODE, false);
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            PbxSearchClient.Enabled = true;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;
                Txt.Clear();
            }
            TxtClientName.Enabled = false;
            TxtPrice.Enabled = false;
            MskClientPhone.Enabled = false;
            CmbParkingTypes.Enabled = true;
            string newcode = moduleId + correlativesController.getNextId(moduleId);
            TxtCheckInCode.Text = newcode;
            TxtClientCode.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void PbxSearchClient_Click(object sender, EventArgs e)
        {
            Clients.FrmSearchClient frmSearchClient = new Clients.FrmSearchClient();
            this.AddOwnedForm(frmSearchClient);
            frmSearchClient.ShowDialog();
        }

        public void getInfoClient(string clientCode)
        {
            ClientController clientController = new ClientController();
            CLIENTS client = clientController.getClient(clientCode);
            if (client != null)
            {
                TxtClientCode.Text = client.CLIENT_CODE;
                TxtClientName.Text = client.CLIENT_NAME + " " + client.CLIENT_LASTNAME;
                MskClientPhone.Text = client.CLIENT_PHONE;
            }
            else
            {
                h.MsgInfo(Helpers.App.Msg0013);
                TxtClientCode.Clear();
                TxtClientName.Clear();
                MskClientPhone.Clear();
                TxtClientCode.Focus();

            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getCheckIns(TxtSearch.Text.Trim(), "", flagIsPaperbin);
            }
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getCheckIns("", "", flagIsPaperbin);
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getCheckIns(TxtSearch.Text.Trim());
        }

        private void DgvCheckIns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isMarkedToEdit = true;
            BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
            BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
            BtnEdit.Enabled = flagIsPaperbin ? false : true;
            BtnDelete.Enabled = flagIsPaperbin ? false : true;
            PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
            PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = false;
            CmbParkingTypes.Enabled = true;

            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = true;
                txt.Clear();
            }
            TxtPrice.Enabled = false;
            TxtClientName.Enabled = false;
            MskClientPhone.Enabled = false;
            TxtCheckInCode.Enabled = false;
            PbxSearchClient.Enabled = true;

            CheckInDTO checkIn = checkInController.getInfoCheckIn(DgvCheckIns.CurrentRow.Cells[0].Value.ToString());

            if (checkIn != null)
            {

                if (checkIn.CHECK_IN_STATE.ToLower() == "finalizado")
                {
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = false;
                }
                TxtCheckInCode.Text = checkIn.CHECK_IN_CODE;
                TxtClientCode.Text = checkIn.CLIENT_CODE;
                getInfoClient(checkIn.CLIENT_CODE);
                CmbParkingTypes.SelectedValue = checkIn.PARKING_FEE_CODE;
                PARKING_FEE pf = parkingFeeController.getParkingFee(CmbParkingTypes.SelectedValue.ToString());

                fillCmbParkingSpaces(pf.PARKING_TYPE_CODE, true);
                CmbParkingSpaces.SelectedValue = checkIn.PARKING_SPACE_CODE;

                TxtPrice.Text = checkIn.PRICE_FOR_HOUR.ToString();
                TxtObservations.Text = checkIn.OBSERVATIONS;
                TxtVehiclePlate.Text = checkIn.VEHICLE_PLATE;
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
            {
                if (validateData() == 0)
                {
                    setValues();
                    CHECK_IN checkIn = checkInController.getCheckIn(TxtCheckInCode.Text);
                    PARKING_SPACE lastPs = parkingSpaceController.getParkingSpace(checkIn.PARKING_SPACE_CODE);

                    string cambios = "";
                    var separator = ", ";

                    if (checkIn.CLIENT_CODE != clientCode)
                        cambios += $"CLIENT_CODE: '{checkIn.CLIENT_CODE}' → '{clientCode}'{separator}";

                    if (checkIn.PARKING_SPACE_CODE != parkingSpaceCode)
                        cambios += $"PARKING_SPACE_CODE: '{checkIn.PARKING_SPACE_CODE}' → '{parkingSpaceCode}'{separator}";

                    if (checkIn.OBSERVATIONS != observations)
                        cambios += $"OBSERVATIONS: '{checkIn.OBSERVATIONS}' → '{observations}'{separator}";

                    if (checkIn.VEHICLE_PLATE != vehiclePlate)
                        cambios += $"VEHICLE_PLATE: '{checkIn.VEHICLE_PLATE}' → '{vehiclePlate}'{separator}";

                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(cambios))
                        cambios = cambios.TrimEnd(',', ' ');

                    checkIn.CLIENT_CODE = clientCode;
                    checkIn.PARKING_SPACE_CODE = parkingSpaceCode;
                    checkIn.OBSERVATIONS = observations;
                    checkIn.VEHICLE_PLATE = vehiclePlate;

                    if (checkInController.updateCheckIn(checkIn) > 0)
                    {
                        if (lastPs.PARKING_SPACE_CODE != parkingSpaceCode)
                        {
                            PARKING_SPACE newPs = parkingSpaceController.getParkingSpace(parkingSpaceCode);
                            lastPs.STATE = false;
                            newPs.STATE = true;
                            if (parkingSpaceController.updateParkingSpace(lastPs) < 0 || parkingSpaceController.updateParkingSpace(newPs) < 0)
                            {
                                h.MsgError(Helpers.App.Msg0017);
                            }
                        }
                        string logDesc = $"El usuario {Config.User.userName} modificó la entrada con código {checkIn.CHECK_IN_CODE}. Cambios: {cambios}.";
                        await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);
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

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                CHECK_IN checkIn = checkInController.getCheckIn(DgvCheckIns.CurrentRow.Cells[0].Value.ToString());
                checkIn.IS_DEL = false;
                PARKING_SPACE pks = parkingSpaceController.getParkingSpace(checkIn.PARKING_SPACE_CODE);

                if (pks.STATE == true)
                {
                    h.MsgError("NO SE PUEDE RECUPERAR ESTA ENTRADA PORQUE EL ESPACIO DE PARQUEO YA ESTÁ SIENDO UTILIZADO EN OTRA ENTRADA ACTIVA!");
                    return;
                }

                if (checkInController.updateCheckIn(checkIn) > 0)
                {
                    PARKING_SPACE ps = parkingSpaceController.getParkingSpace(checkIn.PARKING_SPACE_CODE);
                    ps.STATE = true;
                    if (parkingSpaceController.updateParkingSpace(ps) < 0)
                    {
                        h.MsgError(Helpers.App.Msg0017);
                        return;
                    }


                    string logDesc = $"El usuario {Config.User.userName} modificó el espacio de parqueo con código {ps.PARKING_SPACE_CODE}. Cambios: STATE: 'desocupado' → 'ocupado'.";
                    await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);

                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró la entrada con código {checkIn.CHECK_IN_CODE} de la papelera.", moduleId, DateTime.Now);
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
                CHECK_IN checkIn = checkInController.getCheckIn(TxtCheckInCode.Text);

                if (checkInController.deleteCheckIn(checkIn) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente la entrada con código {checkIn.CHECK_IN_CODE}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            PbxDestroy.Visible = true;
            PbxRecovery.Visible = true;
            flagIsPaperbin = true;
            getCheckIns("", "", flagIsPaperbin);

        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                CHECK_IN checkIn = checkInController.getCheckIn(TxtCheckInCode.Text);
                checkIn.IS_DEL = true;

                if (checkInController.updateCheckIn(checkIn) > 0)
                {
                    PARKING_SPACE ps = parkingSpaceController.getParkingSpace(CmbParkingSpaces.SelectedValue.ToString());
                    ps.STATE = false;
                    if (parkingSpaceController.updateParkingSpace(ps) < 0)
                    {
                        h.MsgError(Helpers.App.Msg0017);
                        return;
                    }

                    
                    string logDesc = $"El usuario {Config.User.userName} modificó el espacio de parqueo con código {ps.PARKING_SPACE_CODE}. Cambios: STATE: 'ocupado' → 'desocupado'.";
                    await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);

                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió la entrada con código {checkIn.CHECK_IN_CODE} a la papelera de reciclaje.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }
        }

        private void TxtClientCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getInfoClient(TxtClientCode.Text.Trim());
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                CHECK_IN checkIn = new CHECK_IN();
                checkIn.CHECK_IN_CODE = checkInCode;
                checkIn.CLIENT_CODE = clientCode;
                checkIn.PARKING_SPACE_CODE = parkingSpaceCode;
                checkIn.OBSERVATIONS = observations;
                checkIn.VEHICLE_PLATE = vehiclePlate;
                checkIn.CHECK_IN_TIME = DateTime.Now;
                checkIn.INSERTED_AT = DateTime.Now;
                checkIn.CHECK_IN_STATE = "Activo";
                checkIn.USER_CODE = Config.User.userId;

                if (checkInController.saveCheckIn(checkIn) > 0)
                {
                    PARKING_SPACE ps = parkingSpaceController.getParkingSpace(parkingSpaceCode);
                    ps.STATE = true;
                    if (parkingSpaceController.updateParkingSpace(ps) < 0)
                    {
                        h.MsgError(Helpers.App.Msg0017);
                        return;
                    }

                    string logDesc = $"El usuario {Config.User.userName} modificó el espacio de parqueo con código {ps.PARKING_SPACE_CODE}. Cambios: STATE: 'desocupado' → 'ocupado'.";
                    await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);


                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó la entrada con código {checkInCode}.", moduleId, DateTime.Now);
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

            checkInCode = TxtCheckInCode.Text.Trim();
            clientCode = TxtClientCode.Text.Trim().Length == 0 ? clientController.getClient("CLI000001").CLIENT_CODE : h.SanitizeStr(TxtClientCode.Text.Trim());
            parkingSpaceCode = h.SanitizeStr(CmbParkingSpaces.SelectedValue.ToString());
            observations = h.SanitizeStr(TxtObservations.Text.Trim());
            vehiclePlate = h.SanitizeStr(TxtVehiclePlate.Text.Trim());
        }

        private int validateData()
        {
            int error = 0;

            if (TxtClientCode.Text.Trim() != "")
            {
                ClientController clientController = new ClientController();
                CLIENTS client = clientController.getClient(TxtClientCode.Text.Trim());

                if (client == null)
                {
                    h.MsgError("CLIENTE NO ENCONTRADO!");
                    error++;
                    TxtClientCode.Focus();
                    return error;
                }
            }


            if (CmbParkingTypes.SelectedIndex == -1)
            {
                h.MsgError("TIPO DE PARQUEO NO VÁLIDO.");
                error++;
                CmbParkingTypes.Focus();
                return error;
            }

            if (CmbParkingSpaces.SelectedIndex == -1)
            {
                h.MsgError("ESPACIO DE PARQUEO NO VÁLIDO.");
                error++;
                CmbParkingSpaces.Focus();
                return error;
            }


            if (!Regex.Match(TxtPrice.Text, RegexPatterns.DecimalPattern).Success)
            {
                h.MsgError("PRECIO NO VÁLIDO.");
                error++;
                TxtPrice.Focus();
                return error;
            }

            if (!Regex.Match(TxtObservations.Text, RegexPatterns.AlphanumericPatternWithAccentAndSpecialChars).Success)
            {
                h.MsgError("OBSERVACIONES NO VÁLIDAS.");
                error++;
                TxtObservations.Focus();
                return error;
            }

            if (!Regex.Match(TxtVehiclePlate.Text, RegexPatterns.LicensePlatePattern).Success)
            {
                h.MsgError("PLACA NO VÁLIDA.");
                error++;
                TxtVehiclePlate.Focus();
                return error;
            }

            return error;
        }

        private void getCheckIns(string searchFilter = "", string state = "", bool isDel = false)
        {
            DgvCheckIns.Rows.Clear();
            IEnumerable<CheckInDTO> checkIns = checkInController.getCheckIns(searchFilter, state, isDel);

            if (checkIns.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getCheckIns("", "", isDel);
                }
                return;
            }

            foreach (var checkIn in checkIns)
            {
                DgvCheckIns.Rows.Add(checkIn.CHECK_IN_CODE, checkIn.VEHICLE_PLATE, checkIn.PARKING_SPACE_NUMBER, checkIn.CLIENT_NAME + " " + checkIn.CLIENT_LASTNAME, checkIn.DESCRIPTION_PARKING_TYPE, checkIn.CHECK_IN_TIME, checkIn.CHECK_IN_STATE);
            }
        }
    }
}
