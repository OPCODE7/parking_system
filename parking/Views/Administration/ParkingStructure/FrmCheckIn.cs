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
    public partial class FrmCheckIn : Form
    {
        Helpers.Helpers h= new Helpers.Helpers();
        ParkingTypeController parkingTypeController = new ParkingTypeController();
        ParkingFeeController parkingFeeController = new ParkingFeeController();
        ParkingSpaceController parkingSpaceController = new ParkingSpaceController();
        CorrelativesController correlativesController = new CorrelativesController();
        CheckInController checkInController = new CheckInController();
        ClientController clientController = new ClientController();
        string checkInCode, clientCode, observations,vehiclePlate, status,parkingSpaceCode,moduleId= "CIN";
        bool isMarkedToEdit= false;
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
            getCheckIns();
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
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

        private void fillCmbParkingSpaces(string parkingType,bool getAll)
        {
            List<dynamic> parkingSpaces= getAll ? parkingSpaceController.getParkingSpacesByParkingType(parkingType).ToList() : parkingSpaceController.getParkingSpacesByParkingType(parkingType).Where(pt => pt.STATE == false).ToList();

            if(parkingSpaces.Count()>0)
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
                if (isMarkedToEdit) {
                    fillCmbParkingSpaces(pf.PARKING_TYPE_CODE, true);
                } else {
                    fillCmbParkingSpaces(pf.PARKING_TYPE_CODE,false);
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
                h.MsgInfo(Helpers.App.Msg0012);
                TxtClientCode.Clear();
                TxtClientName.Clear();
                MskClientPhone.Clear();
                TxtClientCode.Focus();
            
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                getCheckIns(TxtSearch.Text.Trim());
            }
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getCheckIns();
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getCheckIns(TxtSearch.Text.Trim());
        }

        private void DgvCheckIns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isMarkedToEdit = true;
            BtnEdit.Enabled = PermissionManager.HasPermission(moduleId,"Modificar");
            BtnDelete.Enabled = PermissionManager.HasPermission(moduleId,"Eliminar");
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = false;
            CmbParkingTypes.Enabled = true;

            foreach(TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Enabled = true;
                txt.Clear();
            }
            TxtPrice.Enabled = false;
            TxtClientName.Enabled = false;
            MskClientPhone.Enabled = false;
            TxtCheckInCode.Enabled = false;
            PbxSearchClient.Enabled = true;

            var checkIn = checkInController.getInfoCheckIn(DgvCheckIns.CurrentRow.Cells[0].Value.ToString());

            if(checkIn!= null)
            {

                if(checkIn.CHECK_IN_STATE=="FINALIZADO")
                {
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = false;
                }
                TxtCheckInCode.Text = checkIn.CHECK_IN_CODE;
                TxtClientCode.Text= checkIn.CLIENT_DNI;
                getInfoClient(checkIn.CLIENT_DNI);
                CmbParkingTypes.SelectedValue= checkIn.PARKING_FEE_CODE;
                PARKING_FEE pf = parkingFeeController.getParkingFee(CmbParkingTypes.SelectedValue.ToString());
                fillCmbParkingSpaces(pf.PARKING_TYPE_CODE, true);
                CmbParkingSpaces.SelectedValue= checkIn.PARKING_SPACE_CODE;

                TxtPrice.Text= checkIn.PRICE_FOR_HOUR.ToString();
                TxtObservations.Text = checkIn.OBSERVATIONS;
                TxtVehiclePlate.Text = checkIn.VEHICLE_PLATE;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(h.MsgQuestion(Helpers.App.Msg0002) == "S")
            {
                if (validateData() == 0)
                {
                    setValues();
                    CHECK_IN checkIn = checkInController.getCheckIn(TxtCheckInCode.Text);
                    PARKING_SPACE lastPs = parkingSpaceController.getParkingSpace(checkIn.PARKING_SPACE_CODE);

                    checkIn.CLIENT_DNI = clientCode;
                    checkIn.PARKING_SPACE_CODE = parkingSpaceCode;
                    checkIn.OBSERVATIONS = observations;
                    checkIn.VEHICLE_PLATE = vehiclePlate;
                    if (checkInController.updateCheckIn(checkIn) > 0)
                    {
                        if (lastPs.PARKING_SPACE_CODE != parkingSpaceCode)
                        {
                            PARKING_SPACE newPs = parkingSpaceController.getParkingSpace(parkingSpaceCode);
                            lastPs.STATE = false;
                            newPs.STATE= true;
                            if (parkingSpaceController.updateParkingSpace(lastPs) < 0 || parkingSpaceController.updateParkingSpace(newPs) < 0)
                            {
                                h.MsgError(Helpers.App.Msg0017);

                            }
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                    CHECK_IN checkIn = checkInController.getCheckIn(TxtCheckInCode.Text);

                    if (checkInController.deleteCheckIn(checkIn) > 0)
                    {
                        PARKING_SPACE ps = parkingSpaceController.getParkingSpace(CmbParkingSpaces.SelectedValue.ToString());
                        ps.STATE = false;
                        if (parkingSpaceController.updateParkingSpace(ps) < 0)
                        {
                            h.MsgError(Helpers.App.Msg0017);
                        }
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
            if(e.KeyCode==Keys.Enter)
            {
                getInfoClient(TxtClientCode.Text.Trim());
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                CHECK_IN checkIn = new CHECK_IN();
                checkIn.CHECK_IN_CODE = checkInCode;
                checkIn.CLIENT_DNI = clientCode;
                checkIn.PARKING_SPACE_CODE = parkingSpaceCode;
                checkIn.OBSERVATIONS= observations;
                checkIn.VEHICLE_PLATE = vehiclePlate;
                checkIn.CHECK_IN_TIME = DateTime.Now;
                checkIn.INSERTED_AT = DateTime.Now;
                checkIn.CHECK_IN_STATE = "ACTIVO";
                checkIn.USER_CODE= Config.User.userId;

                if (checkInController.saveCheckIn(checkIn)>0)
                {
                    PARKING_SPACE ps = parkingSpaceController.getParkingSpace(parkingSpaceCode);
                    ps.STATE = true;
                    if (parkingSpaceController.updateParkingSpace(ps) < 0)
                    {
                        h.MsgError(Helpers.App.Msg0017);
                    }

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
            clientCode = TxtClientCode.Text.Trim().Length==0 ? clientController.getClient("CLI000001").CLIENT_CODE : h.SanitizeStr(TxtClientCode.Text.Trim());
            parkingSpaceCode = h.SanitizeStr(CmbParkingSpaces.SelectedValue.ToString());
            observations= h.SanitizeStr(TxtObservations.Text.Trim());
            vehiclePlate = h.SanitizeStr(TxtVehiclePlate.Text.Trim());
        }

        private int validateData()
        {
            int error = 0;

            if(TxtClientCode.Text.Trim()!="")
            {
                ClientController clientController = new ClientController();
                CLIENTS client = clientController.getClient(TxtClientCode.Text.Trim());

                if (client == null)
                {
                    h.MsgError("CLIENTE NO ENCONTRADO.");
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


            if (!Regex.Match(TxtPrice.Text,RegexPatterns.DecimalPattern).Success)
            {
                h.MsgError("PRECIO NO VÁLIDO.");
                error++;
                TxtPrice.Focus();
                return error;
            }

            if (!Regex.Match(TxtObservations.Text, RegexPatterns.AlphanumericPattern).Success)
            {
                h.MsgError("OBSERVACIONES NO VÁLIDAS.");
                error++;
                TxtObservations.Focus();
                return error;
            }
           
            if (!Regex.Match(TxtVehiclePlate.Text,RegexPatterns.LicensePlatePattern).Success)
            {
                h.MsgError("PLACA NO VÁLIDA.");
                error++;
                TxtVehiclePlate.Focus();
                return error;
            }

            return error;
        }

        private void getCheckIns(string searchFilter="",string state="")
        {
            DgvCheckIns.Rows.Clear();
            var checkIns = checkInController.getCheckIns(searchFilter,state);

            if (checkIns.Count() == 0) {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getCheckIns();
                }
                return;
            }

            foreach (var checkIn in checkIns)
            {
                DgvCheckIns.Rows.Add(checkIn.CHECK_IN_CODE, checkIn.VEHICLE_PLATE, checkIn.PARKING_SPACE_NUMBER, checkIn.CLIENT_NAME + " " + checkIn.CLIENT_LASTNAME, checkIn.DESCRIPTION_PARKING_TYPE,checkIn.CHECK_IN_TIME, checkIn.CHECK_IN_STATE);
            }
        }
    }
}
