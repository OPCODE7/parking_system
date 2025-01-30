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
    public partial class FrmJobPositions : Form
    {
        Helpers.Helpers h= new Helpers.Helpers();
        Controllers.JobPositionController jobPositionController = new Controllers.JobPositionController();
        Controllers.CorrelativesController correlativesController = new Controllers.CorrelativesController();

        string description, jpsCode;
        
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

            foreach(TextBox textBox in this.Controls.OfType<TextBox>()){
                textBox.Enabled = true;
                textBox.Clear();
            }

            TxtDescription.Focus();

            var nextId= "JPS" + correlativesController.getNextId("JPS");
            TxtJPSCode.Text = nextId;
        }

        private void FrmJobPositions_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void setValues()
        {
            jpsCode= TxtJPSCode.Text.Trim();
            description = h.SanitizeStr(TxtDescription.Text.Trim());
        }

        private int validateData()
        {
            int error = 0;
            string onlyLetters = "^[a-zA-Z\\s]*$";
            if (!Regex.IsMatch(TxtDescription.Text.Trim(), onlyLetters))
            {
                h.MsgWarning("El campo descripción solo puede contener letras.");
                error++;
                return error;
            }
            return error;
        }

        private void startForm()
        {
            getJobPositions("");
            BtnDelete.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;

            foreach(TextBox textBox in this.Controls.OfType<TextBox>()){
                textBox.Enabled= false;
                textBox.Clear();
            }

            TxtSearch.Enabled = true;


        }

        private void getJobPositions(string searchFilter)
        {
            DgvJobPositions.Rows.Clear();
            List<JOB_POSITIONS> jobPositions = jobPositionController.getJobPositions(searchFilter);
            if (searchFilter != "")
            {
                if (jobPositions.Count == 0)
                {
                    h.MsgInfo("No se encontraron registros en la base de datos.");
                    getJobPositions("");
                    return;
                }

            }

            foreach(JOB_POSITIONS j in jobPositions)
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
            getJobPositions("");
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getJobPositions(TxtSearch.Text.Trim());
        }

       

        private void DgvJobPositions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvJobPositions.Rows.Count > 0)
            {
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnNew.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = true;
                TxtDescription.Enabled = true;

                JOB_POSITIONS jps = jobPositionController.getJobPosition(DgvJobPositions.CurrentRow.Cells[0].Value.ToString());
                TxtJPSCode.Text = jps.JOB_POSITION_CODE;
                TxtDescription.Text = jps.DESCRIPTION_JOB_POSITION;

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            JOB_POSITIONS jps = jobPositionController.getJobPosition(TxtJPSCode.Text);
            if (h.MsgQuestion($"¿Está seguro de eliminar el cargo {jps.DESCRIPTION_JOB_POSITION} definitivamente de la base de datos?") == "S")
            {
                if (jobPositionController.deleteJobPosition(jps) > 0)
                {
                    h.MsgInfo("Cargo eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al eliminar el cargo.");
                }
            }


        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                JOB_POSITIONS jps = jobPositionController.getJobPosition(TxtJPSCode.Text);
                jps.DESCRIPTION_JOB_POSITION = description;

                if(h.MsgQuestion($"¿Está seguro de actualizar el cargo {jps.DESCRIPTION_JOB_POSITION} definitivamente de la base de datos?") == "S")
                {
                    if (jobPositionController.updateJobPosition(jps) > 0)
                    {
                        h.MsgInfo("Cargo actualizado correctamente.");
                        startForm();
                    }
                    else
                    {
                        h.MsgError("Error al actualizar el cargo.");
                    }
                }

            }

        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getJobPositions(TxtSearch.Text.Trim());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(validateData()== 0)
            {
                setValues();
                JOB_POSITIONS jps = new JOB_POSITIONS();
                jps.JOB_POSITION_CODE = jpsCode;
                jps.DESCRIPTION_JOB_POSITION = description;
                jps.INSERTED_AT = DateTime.Now;

                if (jobPositionController.saveJobPosition(jps) >0)
                {
                    h.MsgInfo("Registro guardado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al guardar el registro.");
                }
            }
        }
    }
}
