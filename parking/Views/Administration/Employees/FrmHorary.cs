using Microsoft.Win32;
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

namespace parking.Views.Administration.Employees
{
    public partial class FrmHorary : Form
    {
        HoraryController horaryController= new HoraryController();
        Helpers.Helpers h = new Helpers.Helpers();
        CorrelativesController correlativesController = new CorrelativesController();
        string horaryCode,description;
        TimeSpan inititalHour, finalHour;
        public FrmHorary()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startForm()
        {
            getHoraries("");
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = true;

            foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                Txt.Enabled = false;
                Txt.Clear();
            }

            TxtSearch.Enabled = true;
            DtpFinalHour.Enabled = false;
            DtpInitialHour.Enabled = false;
            DtpInitialHour.Text= "00:00:00";
            DtpFinalHour.Text = "00:00:00";
        }

        private void setValues()
        {
            horaryCode = TxtHoraryCode.Text;
            description = h.SanitizeStr(TxtDescription.Text.Trim());
            inititalHour = TimeSpan.Parse(DtpInitialHour.Text);
            finalHour = TimeSpan.Parse(DtpFinalHour.Text);
            
        }

        private void getHoraries(string searchFilter)
        {
            DgvHoraries.Rows.Clear();
            List<HORARY> horaries = horaryController.getHoraries(searchFilter);

            if (searchFilter != "")
            {
                if (horaries.Count == 0)
                {
                    h.MsgInfo("No se encontraron resultados");
                    getHoraries("");
                    return;
                }
            }

            foreach (HORARY horary in horaries)
            {
                DgvHoraries.Rows.Add(horary.HORARY_CODE, horary.HORARY_DESCRIPTION, horary.INITIAL_HOUR, horary.FINAL_HOUR, Convert.ToDateTime(horary.INSERTED_AT).ToShortDateString());
            }
        }

        private int validateData()
        {
            int count = 0;
            string onlyLetters = "^[a-zA-Z\\s]+$";

            if (!Regex.Match(TxtDescription.Text.Trim(), onlyLetters).Success)
            {
                h.MsgWarning("Ingresar descripción del horario correctamente. ¡Solo letras!");
                count++;
                return count;
            }

            if (DtpInitialHour.Value.TimeOfDay >= DtpFinalHour.Value.TimeOfDay)
            {
                h.MsgWarning("La hora de inicio no puede ser mayor o igual a la hora de fin");
                count++;
                return count;
            }

            return count;

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            BtnNew.Enabled = false;
            BtnEdit.Enabled = false;

            foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                Txt.Enabled = true;
                Txt.Clear();
            }

            TxtDescription.Focus();
            DtpInitialHour.Enabled = true;
            DtpFinalHour.Enabled = true;

            var nextId = "HOR" + correlativesController.getNextId("HOR");

            TxtHoraryCode.Text = nextId;
            BtnNew.Enabled = false;
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getHoraries("");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            HORARY horary = horaryController.getHorary(TxtHoraryCode.Text);
            if (h.MsgQuestion($"¿Esta seguro que desea eliminar el permiso {horary.HORARY_DESCRIPTION} de la base de datos?") == "S")
            {
                if (horaryController.deleteHorary(horary) > 0)
                {
                    h.MsgInfo("Horario eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al eliminar horario.");
                }
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                HORARY horary = new HORARY()
                {
                    HORARY_CODE = horaryCode,
                    HORARY_DESCRIPTION = description,
                    INITIAL_HOUR = inititalHour,
                    FINAL_HOUR = finalHour
                };

                if (h.MsgQuestion($"¿Esta seguro que desea modificar el horario {horary.HORARY_DESCRIPTION}?") == "S")
                {
                    if (horaryController.updateHorary(horary) > 0)
                    {
                        h.MsgSuccess("Horario modificado correctamente.");
                        startForm();
                    }
                    else
                    {
                        h.MsgError("Error al modificar horario.");
                    }
                }
            }

        }

        private void DgvHoraries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvHoraries.Rows.Count > 0)
            {
                HORARY horary = horaryController.getHorary(DgvHoraries.CurrentRow.Cells[0].Value.ToString());

                if (horary != null)
                {
                    TxtDescription.Focus();
                    foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
                    {
                        Txt.Enabled = true;
                    }

                    TxtHoraryCode.Enabled = false;

                    TxtHoraryCode.Text = horary.HORARY_CODE;
                    TxtDescription.Text = horary.HORARY_DESCRIPTION;
                    DtpInitialHour.Text = horary.INITIAL_HOUR.ToString();
                    DtpFinalHour.Text = horary.FINAL_HOUR.ToString();
                    DtpInitialHour.Enabled = true;
                    DtpFinalHour.Enabled = true;

                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnNew.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = true;

                }
                else
                {
                    h.MsgError("El registro no ha sido encontrado en la base de datos.");
                }

            }

        }

        private void FrmHorary_Load(object sender, EventArgs e)
        {
            startForm();

        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getHoraries(TxtSearch.Text.Trim());
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getHoraries(TxtSearch.Text);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (validateData() == 0)
            {
                setValues();
                HORARY horary = new HORARY()
                {
                    HORARY_CODE = horaryCode,
                    HORARY_DESCRIPTION = description,
                    INITIAL_HOUR = inititalHour,
                    FINAL_HOUR = finalHour,
                    INSERTED_AT = DateTime.Now
                };

                int result = horaryController.saveHorary(horary);
                if(result > 0)
                {
                    h.MsgSuccess("Horario guardado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al guardar el horario.");
                }
            }

        }
    }
}
