using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration
{
    public partial class FrmUsers : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        Controllers.UserController userController = new Controllers.UserController();
        Controllers.CorrelativesController correlativesController = new Controllers.CorrelativesController();
        Controllers.RoleController roleController = new Controllers.RoleController();
        Controllers.EmployeeController employeeController = new Controllers.EmployeeController();

        string userCode, userName, userPassword;
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
            userName = h.SanitizeStr(TxtUserName.Text.Trim());
            userPassword = h.SanitizeStr(TxtPwd.Text.Trim());
            userState = ChkState.Checked;
            roleId = Convert.ToInt32(CmbRole.SelectedValue);
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

        }
    }
}
