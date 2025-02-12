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
    public partial class FrmParkingTypes : Form
    {
        ParkingTypeController parkingTypeController = new ParkingTypeController();
        Helpers.Helpers h = new Helpers.Helpers();
        CorrelativesController correlativesController = new CorrelativesController();
        string parkingTypeCode, parkingTypeDescription, parkingTypePrice;
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
            parkingTypePrice = h.SanitizeStr(TxtParkingTypePrice.Text.Trim());
        }

        private void startForm()
        {
            getparkingTypes("");
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = true;
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
            string parkingTypeDescriptionPattern = "^[a-zA-Z\\s]+$";
            string parkingTypePricePattern = "^[0-9.]+$";

            if (!Regex.Match(TxtParkingTypePrice.Text, parkingTypePricePattern).Success)
            {
                h.MsgWarning("Ingresar precio del tipo de parqueo correctamente. ¡Solo números!");
                TxtParkingTypePrice.Focus();
                error++;
                return error;
            }

            if (!Regex.Match(TxtParkingTypeDescription.Text, parkingTypeDescriptionPattern).Success)
            {
                h.MsgWarning("Ingresar descripción del tipo de parqueo correctamente. ¡Solo letras!");
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                PARKING_TYPES parkingType = new PARKING_TYPES();
                parkingType.PARKING_TYPE_CODE = parkingTypeCode;
                parkingType.DESCRIPTION_PARKING_TYPE = parkingTypeDescription;
                parkingType.PARKING_TYPE_PRICE = Convert.ToDecimal(parkingTypePrice);
                parkingType.INSERTED_AT = DateTime.Now;

                int result = parkingTypeController.saveParkingType(parkingType);

                if (result > 0)
                {
                    h.MsgInfo("Tipo de parqueo guardado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al guardar el tipo de parqueo.");
                }
            }
        }

        private void DgvParkingTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            BtnSave.Enabled = false;
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;
            }

            TxtParkingTypePrice.Focus();

           PARKING_TYPES parkingType= parkingTypeController.getParkingType(DgvParkingTypes.CurrentRow.Cells[0].Value.ToString());
            TxtParkingTypeCode.Text = parkingType.PARKING_TYPE_CODE;
            TxtParkingTypeDescription.Text = parkingType.DESCRIPTION_PARKING_TYPE;
            TxtParkingTypePrice.Text = parkingType.PARKING_TYPE_PRICE.ToString();

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getparkingTypes(TxtSearch.Text.Trim());
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getparkingTypes("");
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                getparkingTypes(TxtSearch.Text.Trim());
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            PARKING_TYPES parkingType= parkingTypeController.getParkingType(TxtParkingTypeCode.Text);
            if (h.MsgQuestion($"¿Estás seguro que deseas eliminar {parkingType.DESCRIPTION_PARKING_TYPE} de la base de datos?")=="S")
            {
                int result = parkingTypeController.deleteParkingType(TxtParkingTypeCode.Text);

                if (result > 0)
                {
                    h.MsgInfo("Tipo de parqueo eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al eliminar el tipo de parqueo.");
                }

            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                PARKING_TYPES currentPTY= parkingTypeController.getParkingType(parkingTypeCode);

                if (h.MsgQuestion($"¿Estás seguro de actualizar {currentPTY.DESCRIPTION_PARKING_TYPE}?")=="S")
                {
                    PARKING_TYPES parkingType = new PARKING_TYPES();
                    parkingType.PARKING_TYPE_CODE = parkingTypeCode;
                    parkingType.DESCRIPTION_PARKING_TYPE = parkingTypeDescription;
                    parkingType.PARKING_TYPE_PRICE = Convert.ToDecimal(parkingTypePrice);

                    int result = parkingTypeController.updateParkingType(parkingType);

                    if (result > 0)
                    {
                        h.MsgInfo("Tipo de parqueo actualizado correctamente.");
                        startForm();
                    }
                    else
                    {
                        h.MsgError("Error al actualizar el tipo de parqueo.");
                    }
                }
            }

        }

        private void getparkingTypes(string searchFilter)
        {
            DgvParkingTypes.Rows.Clear();
         
            
            List<PARKING_TYPES> parkingTypes = parkingTypeController.getParkingTypes(searchFilter);

            if (parkingTypes.Count == 0)
            {
                h.MsgInfo("No hay registros de tipos de parqueo");

                if (searchFilter != "")
                {
                    getparkingTypes("");
                }
                return;
            }

            foreach (var parkingType in parkingTypes)
            {
                DgvParkingTypes.Rows.Add(parkingType.PARKING_TYPE_CODE, parkingType.DESCRIPTION_PARKING_TYPE, parkingType.PARKING_TYPE_PRICE,Convert.ToDateTime(parkingType.INSERTED_AT).ToShortDateString());
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
            TxtParkingTypePrice.Focus();

            string newCode = "PTY" + correlativesController.getNextId("PTY");
            TxtParkingTypeCode.Text = newCode;

        }
    }
}
