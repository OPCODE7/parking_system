using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using parking.Config;
using parking.Controllers;
using parking.DTO;
using parking.Helpers;
using parking.Models;
using parking.Views.Reports.DataSets;
using parking.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration.Employees
{
    public partial class FrmEmployees : Form
    {
        CorrelativesController correlativesController = new CorrelativesController();
        Helpers.Helpers h= new Helpers.Helpers();
        EmployeeController employeeController = new EmployeeController();
        JobPositionController jobPositionController = new JobPositionController();
        HoraryController horaryController = new HoraryController();
        LogBookAppController lac= new LogBookAppController();

        string dni,name,lastname,phone,email,address,employeeCode,jobPositionCode,horaryCode,moduleId= "EMP";
        bool flagIsPaperBin = false;

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        public FrmEmployees()
        {
            InitializeComponent();
        }

        private void DgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvEmployees.Rows.Count > 0)
            {
                EMPLOYEES employee = employeeController.getEmployee(DgvEmployees.CurrentRow.Cells[0].Value.ToString());

                if (employee != null)
                {
                    TxtDni.Focus();
                    foreach(TextBox Txt in this.Controls.OfType<TextBox>())
                    {
                        Txt.Enabled = true;
                    }

                    MskPhoneNumber.Enabled = true;
                    TxtEmployeeCode.Enabled = false;

                    foreach(ComboBox Cmb in this.Controls.OfType<ComboBox>())
                    {
                        Cmb.Enabled = true;
                    }
                    PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                    PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");

                    TxtEmployeeCode.Text = employee.EMPLOYEE_CODE;
                    TxtDni.Text = employee.EMPLOYEE_DNI;
                    TxtEmployeeName.Text = employee.EMPLOYEE_NAME;
                    TxtLastName.Text = employee.EMPLOYEE_LASTNAME;
                    MskPhoneNumber.Text = employee.EMPLOYEE_PHONE;
                    TxtEmail.Text = employee.EMPLOYEE_EMAIL;
                    TxtAddress.Text = employee.EMPLOYEE_ADDRESS;
                    CmbJobPosition.SelectedValue = employee.JOB_POSITION_CODE;
                    CmbHorary.SelectedValue = employee.HORARY_CODE;


                    BtnEdit.Enabled = PermissionManager.HasPermission(moduleId,"Modificar");
                    BtnDelete.Enabled = PermissionManager.HasPermission(moduleId,"Eliminar");
                    BtnEdit.Enabled = flagIsPaperBin ? false : true;
                    BtnDelete.Enabled = flagIsPaperBin ? false : true;
                    BtnNew.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = true;

                }
                else
                {
                    h.MsgError(App.Msg0011);
                }

            }

        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if(validateData() == 0)
            {
                setValues();
                EMPLOYEES newEmployee = new EMPLOYEES();
                newEmployee.EMPLOYEE_CODE = employeeCode;
                newEmployee.EMPLOYEE_DNI = dni;
                newEmployee.EMPLOYEE_NAME = name;
                newEmployee.EMPLOYEE_LASTNAME = lastname;
                newEmployee.EMPLOYEE_PHONE = phone;
                newEmployee.EMPLOYEE_EMAIL = email;
                newEmployee.EMPLOYEE_ADDRESS = address;
                newEmployee.JOB_POSITION_CODE = jobPositionCode;
                newEmployee.HORARY_CODE = horaryCode;
                newEmployee.INSERTED_AT = DateTime.Now;

                if (employeeController.saveEmployee(newEmployee) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó al empleado {name} {lastname}.", moduleId, DateTime.Now);
                    h.MsgInfo(App.Msg0001);
                    startForm();
                }
                else
                {
                    h.MsgError(App.Msg0015);
                }
            }
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if(validateData() == 0)
            {
               if(h.MsgQuestion(App.Msg0002)=="S")
               {
                    setValues();
                    EMPLOYEES newEmployee = employeeController.getEmployee(TxtEmployeeCode.Text.Trim());
                    string changes = "";
                    var separator = ", ";

                    if (newEmployee.EMPLOYEE_CODE != employeeCode)
                        changes += $"EMPLOYEE_CODE: '{newEmployee.EMPLOYEE_CODE}' → '{employeeCode}'{separator}";

                    if (newEmployee.EMPLOYEE_DNI != dni)
                        changes += $"EMPLOYEE_DNI: '{newEmployee.EMPLOYEE_DNI}' → '{dni}'{separator}";

                    if (newEmployee.EMPLOYEE_NAME != name)
                        changes += $"EMPLOYEE_NAME: '{newEmployee.EMPLOYEE_NAME}' → '{name}'{separator}";

                    if (newEmployee.EMPLOYEE_LASTNAME != lastname)
                        changes += $"EMPLOYEE_LASTNAME: '{newEmployee.EMPLOYEE_LASTNAME}' → '{lastname}'{separator}";

                    if (newEmployee.EMPLOYEE_PHONE != phone)
                        changes += $"EMPLOYEE_PHONE: '{newEmployee.EMPLOYEE_PHONE}' → '{phone}'{separator}";

                    if (newEmployee.EMPLOYEE_EMAIL != email)
                        changes += $"EMPLOYEE_EMAIL: '{newEmployee.EMPLOYEE_EMAIL}' → '{email}'{separator}";

                    if (newEmployee.EMPLOYEE_ADDRESS != address)
                        changes += $"EMPLOYEE_ADDRESS: '{newEmployee.EMPLOYEE_ADDRESS}' → '{address}'{separator}";

                    if (newEmployee.JOB_POSITION_CODE != jobPositionCode)
                        changes += $"JOB_POSITION_CODE: '{newEmployee.JOB_POSITION_CODE}' → '{jobPositionCode}'{separator}";

                    if (newEmployee.HORARY_CODE != horaryCode)
                        changes += $"HORARY_CODE: '{newEmployee.HORARY_CODE}' → '{horaryCode}'{separator}";



                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(changes))
                        changes = changes.TrimEnd(',', ' ');

                    newEmployee.EMPLOYEE_CODE = employeeCode;
                    newEmployee.EMPLOYEE_DNI = dni;
                    newEmployee.EMPLOYEE_NAME = name;
                    newEmployee.EMPLOYEE_LASTNAME = lastname;
                    newEmployee.EMPLOYEE_PHONE = phone;
                    newEmployee.EMPLOYEE_EMAIL = email;
                    newEmployee.EMPLOYEE_ADDRESS = address;
                    newEmployee.JOB_POSITION_CODE = jobPositionCode;
                    newEmployee.HORARY_CODE = horaryCode;

                    if (employeeController.updateEmployee(newEmployee) > 0)
                    {
                        string logDesc = $"El usuario {Config.User.userName} modificó al empleado {name} {lastname}. Cambios: {changes}.";
                        await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);
                        h.MsgInfo(App.Msg0003);
                        startForm();
                    }
                    else
                    {
                        h.MsgError(App.Msg0017);
                    }
               }
            }

        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            EMPLOYEES employee = employeeController.getEmployee(TxtEmployeeCode.Text);

            employee.IS_DEL = true;

            if (h.MsgQuestion(App.Msg0004)=="S")
            {
                if (employeeController.updateEmployee(employee) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió al empleado {employee.EMPLOYEE_NAME} {employee.EMPLOYEE_LASTNAME} a la papelera de reciclaje.", moduleId, DateTime.Now);
                    h.MsgInfo(App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(App.Msg0016);
                }
            }

        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getEmployees("",flagIsPaperBin);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                getEmployees(TxtSearch.Text.Trim(), flagIsPaperBin);
            }
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            flagIsPaperBin = true;
            PbxDestroy.Visible = true;
            PbxRecovery.Visible = true;
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            getEmployees("", true);
        }

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            EMPLOYEES employee = employeeController.getEmployee(TxtEmployeeCode.Text);


            if (h.MsgQuestion(App.Msg0007) == "S")
            {
                if (employeeController.deleteEmployee(employee) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó permanentemente al empleado {employee.EMPLOYEE_NAME} {employee.EMPLOYEE_LASTNAME}.", moduleId, DateTime.Now);
                    h.MsgInfo(App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(App.Msg0015);
                }
            }
        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            EMPLOYEES employee = employeeController.getEmployee(TxtEmployeeCode.Text);
            employee.IS_DEL = false;

            if (h.MsgQuestion(App.Msg0009) == "S")
            {
                if (employeeController.updateEmployee(employee) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró al empleado {employee.EMPLOYEE_NAME} {employee.EMPLOYEE_LASTNAME} de la papelera.", moduleId, DateTime.Now);
                    h.MsgInfo(App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(App.Msg0019);
                }
            }
        }

        private void PbxPrint_Click(object sender, EventArgs e)
        {
            if (DgvEmployees.Rows.Count > 0)
            {
                FrmDefaultRpt frmGenericRpt = new FrmDefaultRpt();


                DataTable dt = h.GetDataTableFromDataGridView(DgvEmployees);

                string pathRpt = @"..\..\Views\Reports\RDLC\ReportEmployees.rdlc";

                string dtsName = "DtsEmployees";
                frmGenericRpt.fillRpt(dt, pathRpt, dtsName);
                frmGenericRpt.ShowDialog();
            }
            else
            {
                h.MsgError(Helpers.App.Msg0012);
            }
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getEmployees(TxtSearch.Text, flagIsPaperBin);
        }

        private void startForm()
        {
            flagIsPaperBin = false;
            getEmployees("");
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId,"Crear");
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnEdit.Enabled = false;
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Enabled = false;
            PbxPrint.Enabled = PermissionManager.HasPermission("RPT", "Crear");
            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Clear();
            }

            foreach (ComboBox Cmb in this.Controls.OfType<ComboBox>())
            {
                Cmb.Enabled = false;
                Cmb.SelectedIndex = -1;
            }
            MskPhoneNumber.Enabled = false;
            MskPhoneNumber.Clear();
            TxtDni.Focus();
            TxtSearch.Enabled = true;
        }

        private void getEmployees(string searchFilter="",bool isDel=false)
        {
            DgvEmployees.Rows.Clear();
            IEnumerable<EmployeeDTO> employess = employeeController.getEmployees(searchFilter,isDel);
            if (employess.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getEmployees("", isDel);
                }
                return;
            }


            foreach (var item in employess)
            {
                DgvEmployees.Rows.Add(item.EMPLOYEE_CODE,item.EMPLOYEE_DNI,item.EMPLOYEE_NAME+" " +item.EMPLOYEE_LASTNAME,item.DESCRIPTION_JOB_POSITION,item.HORARY_DESCRIPTION,item.EMPLOYEE_PHONE,Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }
        }

        private void setValues()
        {
            employeeCode= TxtEmployeeCode.Text.Trim();
            dni = h.SanitizeStr(TxtDni.Text.Trim());
            name = h.SanitizeStr(TxtEmployeeName.Text.Trim());  
            lastname = h.SanitizeStr(TxtLastName.Text.Trim());
            phone = h.SanitizeStr(MskPhoneNumber.Text.Trim());
            email = h.SanitizeStr(TxtEmail.Text.Trim());
            address = h.SanitizeStr(TxtAddress.Text.Trim());
            jobPositionCode = CmbJobPosition.SelectedValue.ToString();
            horaryCode = CmbHorary.SelectedValue.ToString();
        }

        private int validateData()
        {
            int error = 0;

            if (!Regex.Match(TxtDni.Text, RegexPatterns.DNIPattern).Success)
            {
                h.MsgWarning("Ingresar DNI correctamente. ¡Solo letras y números!");
                TxtDni.Focus();
                error++;
                return error;
            }

            if(!MskPhoneNumber.MaskFull)
            {
                h.MsgWarning("Ingresar número de teléfono correctamente.");
                MskPhoneNumber.Focus();
                error++;
                return error;
            }

            if (!Regex.Match(TxtEmployeeName.Text, RegexPatterns.AlphabeticPattern).Success)
            {
                h.MsgWarning("Ingresar nombre correctamente. ¡Solo letras sin acentos!");
                TxtEmployeeName.Focus();
                error++;
                return error;

            }

            if (!Regex.Match(TxtLastName.Text,RegexPatterns.AlphabeticPattern).Success)
            {
                h.MsgWarning("Ingresar apellido correctamente. ¡Solo letras sin acentos!");
                TxtLastName.Focus();
                error++;
                return error;
            }

            if(!Regex.Match(TxtEmail.Text,RegexPatterns.EmailPattern).Success)
            {
                h.MsgWarning("Ingresar correo electrónico correctamente.");
                TxtEmail.Focus();
                error++;
                return error;
            }

            if(!Regex.Match(TxtAddress.Text, RegexPatterns.AddressPattern).Success)
            {
                h.MsgWarning("Ingresar dirección correctamente. ¡Solo letras, números, puntos y guiones!");
                TxtAddress.Focus();
                error++;
                return error;
            }

            if(CmbJobPosition.SelectedValue == null)
            {
                h.MsgWarning("Seleccionar un cargo.");
                CmbJobPosition.Focus();
                error++;
                return error;
            }

            if(CmbHorary.SelectedValue == null)
            {
                h.MsgWarning("Seleccionar un horario.");
                CmbHorary.Focus();
                error++;
                return error;
            }

            return error;

        }

        private void fillCmbJobPosition()
        {
            CmbJobPosition.DataSource = jobPositionController.getJobPositions("",false);
            CmbJobPosition.DisplayMember = "DESCRIPTION_JOB_POSITION";
            CmbJobPosition.ValueMember = "JOB_POSITION_CODE";
            CmbJobPosition.SelectedIndex= -1;
        }

        private void fillCmbHoraries()
        {
            CmbHorary.DataSource = horaryController.getHoraries("");
            CmbHorary.DisplayMember = "HORARY_DESCRIPTION";
            CmbHorary.ValueMember = "HORARY_CODE";
            CmbHorary.SelectedIndex = -1;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            BtnNew.Enabled = false;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;
                Txt.Clear();
            }

            foreach (ComboBox Cmb in this.Controls.OfType<ComboBox>())
            {
                Cmb.Enabled = true;
            }

            MskPhoneNumber.Enabled = true;
            TxtEmployeeCode.Enabled = false;
            TxtDni.Focus();


            string nextId = moduleId + correlativesController.getNextId(moduleId);

            TxtEmployeeCode.Text = nextId;
            BtnNew.Enabled = false;
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            startForm();
            fillCmbJobPosition();
            fillCmbHoraries();
        }
    }
}
