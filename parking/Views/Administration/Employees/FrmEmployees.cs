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
    public partial class FrmEmployees : Form
    {
        Controllers.CorrelativesController correlativesController = new Controllers.CorrelativesController();
        Helpers.Helpers h= new Helpers.Helpers();
        Controllers.EmployeeController employeeController = new Controllers.EmployeeController();
        JobPositionController jobPositionController = new JobPositionController();
        HoraryController horaryController = new HoraryController();

        string dni,name,lastname,phone,email,address,employeeCode,jobPositionCode,horaryCode;

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
                    foreach(System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
                    {
                        Txt.Enabled = true;
                    }

                    MskPhoneNumber.Enabled = true;
                    TxtEmployeeCode.Enabled = false;

                    foreach(System.Windows.Forms.ComboBox Cmb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
                    {
                        Cmb.Enabled = true;
                    }

                    TxtEmployeeCode.Text = employee.EMPLOYEE_CODE;
                    TxtDni.Text = employee.EMPLOYEE_DNI;
                    TxtEmployeeName.Text = employee.EMPLOYEE_NAME;
                    TxtLastName.Text = employee.EMPLOYEE_LASTNAME;
                    MskPhoneNumber.Text = employee.EMPLOYEE_PHONE;
                    TxtEmail.Text = employee.EMPLOYEE_EMAIL;
                    TxtAddress.Text = employee.EMPLOYEE_ADDRESS;
                    CmbJobPosition.SelectedValue = employee.JOB_POSITION_CODE;
                    CmbHorary.SelectedValue = employee.HORARY_CODE;


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

        private void BtnSave_Click(object sender, EventArgs e)
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
                    h.MsgInfo("Empleado guardado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al guardar empleado.");
                }
            }
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(validateData() == 0)
            {
                setValues();
                EMPLOYEES newEmployee = employeeController.getEmployee(TxtEmployeeCode.Text.Trim());
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
                    h.MsgInfo("Empleado actualizado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al actualizar empleado.");
                }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {


            EMPLOYEES registro = new EMPLOYEES { EMPLOYEE_CODE = TxtEmployeeCode.Text.Trim().ToString()};

            if (h.MsgQuestion($"¿Esta seguro que desea eliminar el permiso {registro.EMPLOYEE_NAME+" "+ registro.EMPLOYEE_LASTNAME} de la base de datos?") == "S")
            {
                if (employeeController.deleteEmployee(registro) > 0)
                {
                    h.MsgInfo("Empleado eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al eliminar empleado.");
                }
            }

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getEmployees(TxtSearch.Text);
        }

        private void startForm()
        {
            getEmployees("");
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

            foreach (System.Windows.Forms.ComboBox Cmb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                Cmb.Enabled = false;
                Cmb.SelectedIndex = -1;
            }
            MskPhoneNumber.Enabled = false;
            MskPhoneNumber.Clear();
            TxtEmployeeName.Enabled = true;

        }

        private void getEmployees(string searchFilter)
        {
            DgvEmployees.Rows.Clear();
            var employess = employeeController.getEmployees(searchFilter);
            if (searchFilter != "")
            {
                DgvEmployees.Rows.Clear();
                var users = employeeController.getEmployees(searchFilter);

                if (users.Count() == 0)
                {
                    h.MsgInfo("No se encontraron registros en la base de datos.");
                    if (searchFilter != "")
                    {
                        getEmployees("");
                    }
                    return;
                }

            }
            

            foreach(var item in employess)
            {
                DgvEmployees.Rows.Add(item.EMPLOYEE_CODE,item.EMPLOYEE_NAME+" " +item.EMPLOYEE_LASTNAME,item.DESCRIPTION_JOB_POSITION,item.EMPLOYEE_PHONE,Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
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
            string onlyLetters = "^[a-zA-Z\\s]+$";
            string lettersNumbers = "^[a-zA-Z0-9\\s]+$";
            string address= "^[a-zA-Z0-9,.\\s]+$";
            string emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$";

            if (!Regex.Match(TxtDni.Text, lettersNumbers).Success)
            {
                h.MsgWarning("Ingresar DNI correctamente. ¡Solo letras y números!");
                TxtDni.Focus();
                error++;
                return error;
            }

            if(MskPhoneNumber.Text.Trim().Length==0)
            {
                h.MsgWarning("Ingresar número de teléfono correctamente.");
                MskPhoneNumber.Focus();
                error++;
                return error;
            }

            if (!Regex.Match(TxtEmployeeName.Text, onlyLetters).Success)
            {
                h.MsgWarning("Ingresar nombre correctamente. ¡Solo letras!");
                TxtEmployeeName.Focus();
                error++;
                return error;

            }

            if (!Regex.Match(TxtLastName.Text, onlyLetters).Success)
            {
                h.MsgWarning("Ingresar apellido correctamente. ¡Solo letras!");
                TxtLastName.Focus();
                error++;
                return error;
            }

            if(!Regex.Match(TxtEmail.Text,emailPattern).Success)
            {
                h.MsgWarning("Ingresar correo electrónico correctamente.");
                TxtEmail.Focus();
                error++;
                return error;
            }

            if(!Regex.Match(TxtAddress.Text, address).Success)
            {
                h.MsgWarning("Ingresar dirección correctamente. ¡Solo letras y números!");
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
            CmbJobPosition.DataSource = jobPositionController.getJobPositions("");
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
            BtnEdit.Enabled = false;

            foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                Txt.Enabled = true;
                Txt.Clear();
            }

            foreach (System.Windows.Forms.ComboBox Cmb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                Cmb.Enabled = true;
            }

            MskPhoneNumber.Enabled = true;
            TxtEmployeeCode.Enabled = false;
            TxtDni.Focus();


            var nextId = "EMP" + correlativesController.getNextId("EMP");

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
