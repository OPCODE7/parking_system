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
using parking.Controllers;
using parking.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration
{
    public partial class FrmUsers : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        UserController userController = new UserController();
        CorrelativesController correlativesController = new CorrelativesController();
        RoleController roleController = new RoleController();
        EmployeeController employeeController = new EmployeeController();
        EmployeeUserController employeeUserController = new EmployeeUserController();
        Helpers.PasswordHasher pwdHasher = new Helpers.PasswordHasher();

        string userCode, userName, userPassword,employeeCode;
        bool userState;
        int roleId;
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            startForm();
            fillCmbEmployees();
            fillCmbRoles();
        }

        private void startForm()
        {
            getUsers("");
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = true;
            BtnCancel.Enabled = false;
            ChkState.Enabled = false;

            foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                Txt.Enabled = false;
                Txt.Text = "";
            }

            foreach(System.Windows.Forms.ComboBox Cmb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                Cmb.Enabled = false;
                Cmb.SelectedIndex = -1;
            }
            
            TxtSearch.Enabled = true;
        }

        private void setValues()
        {
            userCode= TxtUserCode.Text.Trim();
            userName = h.SanitizeStr(TxtUserName.Text.Trim());
            userPassword = pwdHasher.makeHash(TxtPwd.Text.Trim());
            userState = ChkState.Checked;
            employeeCode = CmbEmployees.SelectedValue.ToString();
            roleId = Convert.ToInt32(CmbRole.SelectedValue);
        }

        private int validateData()
        {
            int error = 0;
            string userName = "^[a-zA-Z0-9_]+$";
            string userPassword = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,15}";

            if (!Regex.Match(TxtUserName.Text, userName).Success)
            {
                h.MsgError("El nombre de usuario no es válido. ¡Letras mayúsculas o minúsculas, números y guión bajo son permitidos!");
                error++;
                return error;
            }

            if (!Regex.Match(TxtPwd.Text, userPassword).Success)
            {
                h.MsgError("La contraseña no es válida. ¡Debe contener al menos una letra mayúscula, una minúscula, un número y un caracter especial!");
                error++;
                return error;
            }

            if (CmbRole.SelectedValue==null)
            {
                h.MsgError("Debe seleccionar un rol para el usuario.");
                error++;
                return error;
            }

            if (CmbEmployees.SelectedValue == null)
            {
                h.MsgError("Debe seleccionar un empleado para el usuario.");
                error++;
                return error;
            }
            return error;
        }

        private void getUsers(string searchFilter)
        {
            DgvUsers.Rows.Clear();
            var users = userController.getUsers(searchFilter);

            if (users.Count() ==0 )
            {
                h.MsgInfo("No se encontraron registros en la base de datos.");
                if (searchFilter != "")
                {
                    getUsers("");
                }
                return;
            }

            foreach (var item in users)
            {
                DgvUsers.Rows.Add(item.USER_CODE, item.USER_NAME,item.ROLE_NAME, item.USER_STATE ? "ACTIVO" : "INACTIVO" ,Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }


        }

        private void fillCmbEmployees()
        {
            var employees= employeeController.getEmployees("");

            CmbEmployees.DataSource = employees;
            CmbEmployees.DisplayMember = "EMPLOYEE_NAME"; 
            CmbEmployees.ValueMember = "EMPLOYEE_CODE";  
            CmbEmployees.SelectedIndex = -1;


        }

        private void fillCmbRoles()
        {
            List<USER_ROLES> lst = roleController.getRoles("");

            CmbRole.DataSource = lst;
            CmbRole.DisplayMember = "ROLE_NAME";
            CmbRole.ValueMember = "ROLE_ID";
            CmbRole.SelectedIndex = -1;
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnDelete.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            ChkState.Enabled = true;

            foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                Txt.Enabled = true;
            }

            foreach (System.Windows.Forms.ComboBox Cmb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                Cmb.Enabled = true;
            }

            TxtUserCode.Enabled = false;
            TxtUserName.Focus();



            var nextId = "USR" + correlativesController.getNextId("USR");

            TxtUserCode.Text = nextId;
            BtnNew.Enabled = false;
        
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getUsers(TxtSearch.Text.Trim());
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getUsers(TxtSearch.Text);
            }

        }

        private void DgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DgvUsers.Rows.Count>0)
            {
                var user = userController.getUser(DgvUsers.CurrentRow.Cells[0].Value.ToString());

                if(user != null)
                {

                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnNew.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = true;
                    ChkState.Enabled = true;

                    TxtUserCode.Enabled = false;
                    TxtUserName.Enabled = true;
                    TxtPwd.Enabled = true;
                    CmbRole.Enabled = true;
                    CmbEmployees.Enabled = true;

                    TxtUserName.Focus();
                    TxtUserCode.Text = user.USER_CODE;
                    TxtUserName.Text = user.USER_NAME;
                    TxtPwd.Text = user.USER_PASSWORD;
                    CmbRole.Text = user.ROLE_NAME;
                    ChkState.Checked = user.USER_STATE == true ? true : false;

                    CmbEmployees.SelectedValue = user.EMPLOYEE_CODE;
                    CmbRole.SelectedValue = user.ROLE_ID;
                }
                else
                {
                    h.MsgError("El registro no ha sido encontrado en la base de datos.");
                }
            }

        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getUsers("");
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
                USERS user= new USERS();
                user.USER_CODE = userCode;
                user.USER_NAME = userName;
                user.USER_PASSWORD = userPassword;
                user.USER_STATE = userState;
                user.ROLE_ID = roleId;
                user.INSERTED_AT = DateTime.Now;
               
                if(userController.saveUser(user) > 0){
                    var nextId = "EUS" + correlativesController.getNextId("EUS");
                    EMPLOYEE_USER employeeUser= new EMPLOYEE_USER();
                    employeeUser.EMPLOYEE_USER_ID = nextId;
                    employeeUser.EMPLOYEE_CODE = employeeCode;
                    employeeUser.USER_CODE = userCode;
                    employeeUser.INSERTED_AT = DateTime.Now;
                    if (employeeUserController.saveEmployeeUser(employeeUser) > 0)
                    {
                        h.MsgInfo("Usuario guardado correctamente.");
                           startForm();
                    }
                    else
                    {
                        h.MsgError("Ocurrio un error el usuario no pudo ser asignado al empleado correctamente.");
                    }
                }
                else
                {
                    h.MsgError("Ocurrio un error el usuario no pudo ser guardado correctamente.");
                }
            }
        }
    }
}
