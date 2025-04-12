using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.Win32;
using parking.Config;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration.Employees
{
    public partial class FrmHorary : Form
    {
        HoraryController horaryController = new HoraryController();
        Helpers.Helpers h = new Helpers.Helpers();
        CorrelativesController correlativesController = new CorrelativesController();
        LogBookAppController lac = new LogBookAppController();

        string horaryCode, description, moduleId = "HOR";
        TimeSpan inititalHour, finalHour;
        bool flagIsPaperBin = false;
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
            flagIsPaperBin = false;
            getHoraries("", false);
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxDestroy.Enabled = false;
            PbxRecovery.Enabled = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Clear();
            }

            TxtSearch.Enabled = true;
            DtpFinalHour.Enabled = false;
            DtpInitialHour.Enabled = false;
            DtpInitialHour.Text = "00:00:00";
            DtpFinalHour.Text = "00:00:00";
        }

        private void setValues()
        {
            horaryCode = TxtHoraryCode.Text;
            description = h.SanitizeStr(TxtDescription.Text.Trim());
            inititalHour = TimeSpan.Parse(DtpInitialHour.Text);
            finalHour = TimeSpan.Parse(DtpFinalHour.Text);

        }

        private void getHoraries(string searchFilter, bool isDel)
        {
            DgvHoraries.Rows.Clear();
            List<HORARY> horaries = horaryController.getHoraries(searchFilter, isDel);


            if (horaries.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getHoraries("", isDel);
                }
                TxtSearch.Clear();
                return;
            }


            foreach (HORARY horary in horaries)
            {
                DgvHoraries.Rows.Add(horary.HORARY_CODE, horary.HORARY_DESCRIPTION, horary.INITIAL_HOUR, horary.FINAL_HOUR, Convert.ToDateTime(horary.INSERTED_AT).ToShortDateString());
            }
        }

        private int validateData()
        {
            int count = 0;
            if (!Regex.Match(TxtDescription.Text.Trim(), Helpers.RegexPatterns.AlphabeticPatternWithAccent).Success)
            {
                h.MsgWarning("INGRESAR DESCRIPCIÓN DEL HORARIO CORRECTAMENTE. ¡SOLO LETRAS!");
                count++;
                return count;
            }

            if (DtpInitialHour.Value.TimeOfDay >= DtpFinalHour.Value.TimeOfDay)
            {
                h.MsgWarning("LA HORA DE INICIO NO PUEDE SER MAYOR O IGUAL A LA HORA DE FIN");
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

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;
                Txt.Clear();
            }

            TxtDescription.Focus();
            DtpInitialHour.Enabled = true;
            DtpFinalHour.Enabled = true;

            var nextId = moduleId + correlativesController.getNextId(moduleId);

            TxtHoraryCode.Text = nextId;
            BtnNew.Enabled = false;
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getHoraries("", flagIsPaperBin);
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            HORARY horary = horaryController.getHorary(TxtHoraryCode.Text);
            horary.IS_DEL = true;
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                if (horaryController.updateHorary(horary) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió el horario {horary.HORARY_DESCRIPTION} a la papelera de reciclaje.", moduleId, DateTime.Now);
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
            if (validateData() == 0)
            {

                if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
                {
                    setValues();
                    HORARY horary = horaryController.getHorary(horaryCode);

                    string changes = "";
                    var separator = ", ";

                    if (horary.HORARY_DESCRIPTION != description)
                        changes += $"HORARY_DESCRIPTION: '{horary.HORARY_DESCRIPTION}' → '{description}'{separator}";

                    if (horary.INITIAL_HOUR != inititalHour)
                        changes += $"INITIAL_HOUR: '{horary.INITIAL_HOUR}' → '{inititalHour}'{separator}";

                    if (horary.FINAL_HOUR != finalHour)
                        changes += $"FINAL_HOUR: '{horary.FINAL_HOUR}' → '{finalHour}'{separator}";

                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(changes))
                        changes = changes.TrimEnd(',', ' ');

                    horary.HORARY_DESCRIPTION = description;
                    horary.INITIAL_HOUR = inititalHour;
                    horary.FINAL_HOUR = finalHour;

                    if (horaryController.updateHorary(horary) > 0)
                    {
                        if (!string.IsNullOrEmpty(changes))
                        {
                            string logDesc = $"El usuario {Config.User.userName} modificó el horario {description}. Cambios: {changes}.";
                            await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);
                        }
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

        private void DgvHoraries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvHoraries.Rows.Count > 0)
            {
                HORARY horary = horaryController.getHorary(DgvHoraries.CurrentRow.Cells[0].Value.ToString());

                if (horary != null)
                {
                    TxtDescription.Focus();
                    foreach (TextBox Txt in this.Controls.OfType<TextBox>())
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
                    PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                    PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");

                    BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                    BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
                    BtnEdit.Enabled = flagIsPaperBin ? false : true;
                    BtnDelete.Enabled = flagIsPaperBin ? false : true;
                    BtnNew.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = true;

                }
                else
                {
                    h.MsgError(Helpers.App.Msg0011);
                }

            }

        }

        private void FrmHorary_Load(object sender, EventArgs e)
        {
            startForm();

        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            PbxDestroy.Visible = true;
            PbxRecovery.Visible = true;
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            flagIsPaperBin = true;
            getHoraries("", true);
        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            HORARY horary = horaryController.getHorary(TxtHoraryCode.Text);
            horary.IS_DEL = false;
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                if (horaryController.updateHorary(horary) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró el horario {horary.HORARY_DESCRIPTION} de la papelera.", moduleId, DateTime.Now);

                    h.MsgInfo(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0019);
                }
            }
        }

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            HORARY horary = horaryController.getHorary(TxtHoraryCode.Text);
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                if (horaryController.deleteHorary(horary) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente el horario {horary.HORARY_DESCRIPTION}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getHoraries(TxtSearch.Text.Trim(), flagIsPaperBin);
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getHoraries(TxtSearch.Text, flagIsPaperBin);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
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
                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó el horario {description}.", moduleId, DateTime.Now);
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
