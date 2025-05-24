using parking.Config;
using parking.Controllers;
using parking.DTO;
using parking.Models;
using parking.Views.Reports.DataSets;
using parking.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Employees
{
    public partial class FrmSalaries : Form
    {
        bool flagIsPaperbin = false,isUpdate= false;
        string moduleId = "SAL";
        SalariesController sc = new SalariesController();
        EmployeeController ec = new EmployeeController();
        LogBookAppController lac = new LogBookAppController();
        CorrelativesController correlativesController = new CorrelativesController();
        EmployeeSalaryController esc= new EmployeeSalaryController();
        DataBaseController dbc = new DataBaseController();

        Helpers.Helpers h = new Helpers.Helpers();
        string salaryId, employeeId,userId;
        decimal baseSalary, increase, totalSalary;
        bool state;
        IEnumerable<EmployeeDTO> allEmployees;
        public FrmSalaries()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSalaries_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getSalaries("", false);
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getSalaries(TxtSearch.Text.Trim(), flagIsPaperbin);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) getSalaries(TxtSearch.Text.Trim(), flagIsPaperbin);
        }

        private void DgvSalaries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSalaries.Rows.Count == 0) return;

            SALARIES salary = sc.getSalary(DgvSalaries.CurrentRow.Cells[0].Value.ToString());
           

            if (salary != null)
            {
                EMPLOYEE_SALARY lastEmpSalary = esc.getLastEmployeeSalary(salary.SALARY_CODE,"",null,null);
               

                TxtBaseSalary.Enabled = true;
                TxtIncrease.Enabled = true;
                CmbEmployees.Enabled = true;
                CmbState.Enabled = true;

                CmbEmployees.SelectedValue = lastEmpSalary.EMPLOYEE_CODE;
                CmbState.SelectedIndex= lastEmpSalary.SALARY_STATE ? 0 : 1;
                TxtSalaryCode.Text= salary.SALARY_CODE;
                TxtBaseSalary.Text = salary.BASE_SALARY.ToString();
                TxtIncrease.Text = salary.INCREASE.ToString();
                TxtTotalSalary.Visible = true;
                LblTotalSalary.Visible = true;
                TxtTotalSalary.Text = salary.TOTAL_SALARY.ToString();

                BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
                BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                BtnDelete.Enabled = flagIsPaperbin ? false : true;
                BtnEdit.Enabled = flagIsPaperbin ? false : true;
                PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");
                BtnNew.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = true;

                setValues();

            }
            else
            {
                h.MsgInfo(Helpers.App.Msg0011);
            }
        }

        private int validateData()
        {
            int errors = 0;

            if (!Regex.Match(TxtBaseSalary.Text.Trim(), Helpers.RegexPatterns.DecimalPattern).Success)
            {
                errors++;
                h.MsgError("INGRESAR EL SALARIO BASE EN FORMATO CORRECTO. ¡SOLO NUMEROS!");
                TxtBaseSalary.Focus();
                return errors;

            }

            if (!Regex.Match(TxtIncrease.Text.Trim(), Helpers.RegexPatterns.DecimalPattern).Success)
            {
                errors++;
                h.MsgError("INGRESAR EL AUMENTO EN FORMATO CORRECTO. ¡SOLO NUMEROS!");
                TxtIncrease.Focus();
                return errors;
            }

            if (CmbEmployees.SelectedIndex == -1)
            {
                errors++;
                h.MsgError("SELECCIONAR UN EMPLEADO!");
                CmbEmployees.Focus();
                return errors;
            }

            if (isUpdate)
            {
                if (CmbState.SelectedIndex == -1)
                {
                    errors++;
                    h.MsgError("SELECCIONAR ESTADO DEL SALARIO!");
                    CmbState.Focus();
                    return errors;
                }

            }


            return errors;

        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
            {
                if (validateData() == 0)
                {
                    isUpdate = true;
                    setValues();
                    SALARIES salary = sc.getSalary(salaryId);
                    if (salary != null)
                    {
                        salary.BASE_SALARY = baseSalary;
                        salary.INCREASE = increase;
                        salary.TOTAL_SALARY = totalSalary;

                        string changes = "";
                        var separator = ", ";

                        if (salary.BASE_SALARY != baseSalary)
                            changes += $"BASE_SALARY: '{salary.BASE_SALARY}' → '{baseSalary}'{separator}";

                        if (salary.INCREASE != increase)
                            changes += $"INCREASE: '{salary.INCREASE}' → '{increase}'{separator}";

                        if (!string.IsNullOrEmpty(changes))
                            changes = changes.TrimEnd(',', ' ');

                        EMPLOYEE_SALARY lastSalary = esc.getLastEmployeeSalary("", employeeId, state,false);

                        if (sc.updateSalary(salary) > 0)
                        {
                            EMPLOYEE_SALARY currentEmpSal = esc.getLastEmployeeSalary(salary.SALARY_CODE, employeeId, null,false);

                            if (currentEmpSal != null && currentEmpSal.SALARY_STATE != state)
                            {
                                currentEmpSal.SALARY_STATE = state;
                                esc.updateSalary(currentEmpSal);

                                if (lastSalary != null)
                                {
                                    lastSalary.SALARY_STATE = !state; 
                                    esc.updateSalary(lastSalary);
                                }
                            }
                            else
                            {
                                h.MsgError("No se pudo recuperar el salario actual para actualizar su estado.");
                            }


                            string logDesc = $"El usuario {Config.User.userName} modificó el salario con código {salaryId}. Cambios: {changes}.";
                            await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);

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

            TxtSalaryCode.Enabled = false;
            TxtTotalSalary.Enabled = false;
            TxtBaseSalary.Focus();
            CmbEmployees.Enabled = true;
           

            var nextId = moduleId + correlativesController.getNextId(moduleId);
            TxtSalaryCode.Text = nextId;
        }

        private void setValues()
        {
            salaryId = TxtSalaryCode.Text.Trim();
            employeeId = CmbEmployees.SelectedValue.ToString();
            state= CmbState.SelectedIndex==0 ? true : false;
            baseSalary = decimal.Parse(TxtBaseSalary.Text.Trim());
            increase = decimal.Parse(TxtIncrease.Text.Trim());
            totalSalary = baseSalary + increase;
            userId = User.userId;

        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();

                SALARIES salary = new SALARIES
                {
                    SALARY_CODE = salaryId,
                    BASE_SALARY = baseSalary,
                    INCREASE = increase,
                    TOTAL_SALARY = totalSalary,
                    INSERTED_AT= DateTime.Now,
                    USER_CODE= userId
                };


                EMPLOYEE_SALARY empSalary = new EMPLOYEE_SALARY
                {
                    EMPLOYEE_SALARY_CODE = "EMS" + correlativesController.getNextId("EMS"),
                    EMPLOYEE_CODE = employeeId,
                    SALARY_CODE = salaryId,
                    USER_CODE = userId,
                    SALARY_STATE= true,
                    INSERTED_AT = DateTime.Now
                  
                };

                EMPLOYEE_SALARY lastSalary = esc.getLastEmployeeSalary("", employeeId,true, false);

                if (sc.saveSalary(salary) > 0)
                {
                    

                    if (esc.saveEmployeeSalary(empSalary) > 0)
                    {
                        if (lastSalary != null) {
                            lastSalary.SALARY_STATE = false;
                            esc.updateSalary(lastSalary);
                        } 
                    }
                    

                    string logDesc = $"El usuario {Config.User.userName} insertó el salario con código {salaryId}.";
                    await lac.saveLog(Config.User.userId, "Insertar", logDesc, moduleId, DateTime.Now);

                    h.MsgSuccess(Helpers.App.Msg0001);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0017);
                }
            }

        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                SALARIES salary= sc.getSalary(TxtSalaryCode.Text);

                salary.IS_DEL = true;
                EMPLOYEE_SALARY lastSal = esc.getLastEmployeeSalary("", employeeId, false, false);

                if (sc.updateSalary(salary) > 0)
                {
                    EMPLOYEE_SALARY currentEmpSal = esc.getLastEmployeeSalary(salary.SALARY_CODE,employeeId,true, false);
                    currentEmpSal.SALARY_STATE = false;

                    esc.updateSalary(currentEmpSal);


                    if (lastSal != null)
                    {
                        lastSal.SALARY_STATE = true;
                        esc.updateSalary(lastSal);
                    }

                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió el salario con código{salary.SALARY_CODE} a la papelera de reciclaje.", moduleId, DateTime.Now);

                    h.MsgSuccess(Helpers.App.Msg0005);
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
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            flagIsPaperbin = true;
            getSalaries("", flagIsPaperbin);
        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                SALARIES salary= sc.getSalary(TxtSalaryCode.Text);
                salary.IS_DEL = false;
                if (sc.updateSalary(salary) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró el salario con código {salary.SALARY_CODE} de la papelera.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0010);
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
                EMPLOYEE_SALARY lastEmpSalary = esc.getLastEmployeeSalary(TxtSalaryCode.Text, employeeId, null, null);

                if (esc.deleteEmployeeSalary(lastEmpSalary.EMPLOYEE_SALARY_CODE) > 0)
                {
                    if(sc.deleteSalary(TxtSalaryCode.Text) > 0)
                    {
                       await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente el salario con código {TxtSalaryCode.Text}.", moduleId, DateTime.Now);
                        h.MsgSuccess(Helpers.App.Msg0008);
                        startForm();
                    }
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }

        }

        private void PbxPrint_Click(object sender, EventArgs e)
        {
            if (DgvSalaries.Rows.Count > 0)
            {
                FrmDefaultRpt frmGenericRpt = new FrmDefaultRpt();


                DataTable dt = h.GetDataTableFromDataGridView(DgvSalaries);

                string pathRpt = @"..\..\Views\Reports\RDLC\ReportSalaries.rdlc";

                string dtsName = "DtsEmployees";
                frmGenericRpt.fillRpt(dt, pathRpt, dtsName);
                frmGenericRpt.ShowDialog();
            }
            else
            {
                h.MsgError(Helpers.App.Msg0012);
            }
        }

        private void CmbEmployees_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (CmbEmployees.Items.Count > 0)
                {
                    var item = (dynamic)CmbEmployees.SelectedItem;
                    CmbEmployees.Text = item.EMPLOYEE_FULL_NAME;
                    CmbEmployees.SelectionStart = CmbEmployees.Text.Length;
                }
                return;
            }

            filterCmbEmployees();

        }

        private void filterCmbEmployees()
        {
            string text = CmbEmployees.Text.ToLower();
            int cursorPos = CmbEmployees.SelectionStart;

            if (string.IsNullOrEmpty(text))
            {
                fillCmbEmployees();
                CmbEmployees.SelectedIndex = -1;
            }
            else
            {
                var filtrados = allEmployees
                    .Where(e => e.EMPLOYEE_FULL_NAME.ToLower().Contains(text))
                    .ToList();



                CmbEmployees.DataSource = filtrados;
                CmbEmployees.ValueMember = "EMPLOYEE_CODE";
                CmbEmployees.DisplayMember = "EMPLOYEE_FULL_NAME";
                CmbEmployees.DroppedDown = true;

                CmbEmployees.Text = text;
                CmbEmployees.SelectionStart = cursorPos;
                CmbEmployees.SelectionLength = 0;
            }

        }

        private void startForm()
        {
            getSalaries("", false);
            fillCmbEmployees();
            BtnDelete.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxPrint.Enabled = PermissionManager.HasPermission("RPT", "Crear");
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;
            flagIsPaperbin = false;
            isUpdate = false;
            CmbEmployees.Enabled = false;
            CmbState.Enabled = false;
            CmbEmployees.SelectedIndex = -1;
            CmbState.SelectedIndex = -1;


            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Enabled = false;
                textBox.Clear();
            }
            TxtTotalSalary.Visible = false;
            LblTotalSalary.Visible = false;
            TxtSearch.Enabled = true;

        }

        private void fillCmbEmployees()
        {
            allEmployees= ec.getEmployees("", false);
            CmbEmployees.DataSource = allEmployees;
            CmbEmployees.DisplayMember = "EMPLOYEE_FULL_NAME";
            CmbEmployees.ValueMember = "EMPLOYEE_CODE";
        }

        public void getSalaries(string searchFilter, bool isDel)
        {
            DgvSalaries.Rows.Clear();
            List<SalaryDTO> salaries = sc.getSalaries(searchFilter, isDel);
            if (salaries.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getSalaries("", false);
                }
                return;
            }

            foreach (var salary in salaries)
            {
                DgvSalaries.Rows.Add(salary.SALARY_CODE, salary.EMPLOYEE_NAME, salary.BASE_SALARY, salary.INCREASE, salary.TOTAL_SALARY, salary.INSERTED_AT.ToShortDateString());
            }

        }
    }
}
