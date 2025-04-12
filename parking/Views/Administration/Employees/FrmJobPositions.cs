using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class FrmJobPositions : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        Controllers.JobPositionController jobPositionController = new Controllers.JobPositionController();
        Controllers.CorrelativesController correlativesController = new Controllers.CorrelativesController();
        LogBookAppController lac = new LogBookAppController();

        string description, jpsCode, moduleId = "JPS";
        bool flagIsPaperbin = false;

        public FrmJobPositions()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;

            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Enabled = true;
                textBox.Clear();
            }

            TxtDescription.Focus();

            var nextId = moduleId + correlativesController.getNextId(moduleId);
            TxtJPSCode.Text = nextId;
        }

        private void FrmJobPositions_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void setValues()
        {
            jpsCode = TxtJPSCode.Text.Trim();
            description = h.SanitizeStr(TxtDescription.Text.Trim());
        }

        private int validateData()
        {
            int error = 0;
            if (!Regex.IsMatch(TxtDescription.Text.Trim(), Helpers.RegexPatterns.AlphabeticPatternWithAccent))
            {
                h.MsgWarning("INGRESAR DESCRIPCION CORRECTAMENTE ¡SOLO LETRAS!");
                error++;
                return error;
            }
            return error;
        }

        private void startForm()
        {
            getJobPositions("", false);
            BtnDelete.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;
            flagIsPaperbin = false;


            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Enabled = false;
                textBox.Clear();
            }

            TxtSearch.Enabled = true;
        }

        private void getJobPositions(string searchFilter, bool isDel)
        {
            DgvJobPositions.Rows.Clear();
            List<JOB_POSITIONS> jobPositions = jobPositionController.getJobPositions(searchFilter, isDel);

            if (jobPositions.Count == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);

                if (searchFilter != "") getJobPositions("", isDel);
                return;
            }

            foreach (JOB_POSITIONS j in jobPositions)
            {
                DgvJobPositions.Rows.Add(j.JOB_POSITION_CODE, j.DESCRIPTION_JOB_POSITION, Convert.ToDateTime(j.INSERTED_AT).ToShortDateString());
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getJobPositions("", flagIsPaperbin);
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getJobPositions(TxtSearch.Text.Trim(), flagIsPaperbin);
        }



        private void DgvJobPositions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvJobPositions.Rows.Count > 0)
            {
                JOB_POSITIONS jps = jobPositionController.getJobPosition(DgvJobPositions.CurrentRow.Cells[0].Value.ToString());
                if (jps == null)
                {
                    h.MsgError(Helpers.App.Msg0011);
                    return;
                }
                BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
                BtnEdit.Enabled= flagIsPaperbin ? false : true;
                BtnDelete.Enabled = flagIsPaperbin ? false : true;
                BtnNew.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = true;
                TxtDescription.Enabled = true;
                PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");


                TxtJPSCode.Text = jps.JOB_POSITION_CODE;
                TxtDescription.Text = jps.DESCRIPTION_JOB_POSITION;

            }
            else
            {
                h.MsgError(Helpers.App.Msg0011);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            JOB_POSITIONS jps = jobPositionController.getJobPosition(TxtJPSCode.Text);
            jps.IS_DEL = true;
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                if (jobPositionController.updateJobPosition(jps) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió el cargo {jps.DESCRIPTION_JOB_POSITION} a la papelera de reciclaje.", moduleId, DateTime.Now);
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
                setValues();


                if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
                {
                    JOB_POSITIONS jps = jobPositionController.getJobPosition(TxtJPSCode.Text);
                    string changes = "";
                    var separator = ", ";

                    if (jps.DESCRIPTION_JOB_POSITION!= description)
                        changes += $"DESCRIPTION_JOB_POSITION: '{jps.DESCRIPTION_JOB_POSITION}' → '{description}'{separator}";

                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(changes))
                        changes = changes.TrimEnd(',', ' ');

                    jps.DESCRIPTION_JOB_POSITION = description;
                    if (jobPositionController.updateJobPosition(jps) > 0)
                    {
                        string logDesc = $"El usuario {Config.User.userName} modificó el cargo {description}. Cambios: {changes}.";
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

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            flagIsPaperbin = true;
            getJobPositions("", flagIsPaperbin);

        }

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                JOB_POSITIONS jps = jobPositionController.getJobPosition(TxtJPSCode.Text);
                if (jobPositionController.deleteJobPosition(jps) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente el cargo {jps.DESCRIPTION_JOB_POSITION}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }


        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                JOB_POSITIONS jps = jobPositionController.getJobPosition(TxtJPSCode.Text);
                jps.IS_DEL = false;
                if (jobPositionController.updateJobPosition(jps) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró el rol {jps.DESCRIPTION_JOB_POSITION} de la papelera.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0019);
                }
            }

        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getJobPositions(TxtSearch.Text.Trim(), flagIsPaperbin);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                JOB_POSITIONS jps = new JOB_POSITIONS();
                jps.JOB_POSITION_CODE = jpsCode;
                jps.DESCRIPTION_JOB_POSITION = description;
                jps.INSERTED_AT = DateTime.Now;

                if (jobPositionController.saveJobPosition(jps) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó el cargo {description}.", moduleId, DateTime.Now);
                    h.MsgInfo(Helpers.App.Msg0001);
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
