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
using parking.Config;
using parking.Controllers;
using parking.DTO;
using parking.Helpers;
using parking.Models;
using parking.Views.Reports.DataSets;
using parking.Views.Reports;


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
        PasswordHasher pwdHasher = new PasswordHasher();
        LogBookAppController lac = new LogBookAppController();

        string userCode, userName, userPassword, employeeCode, moduleId = "USR";
        bool userState, isEdit = false, flagIsPaperbin = false;
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
            getUsers("", false);
            flagIsPaperbin = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxPrint.Enabled = PermissionManager.HasPermission("RPT", "Crear");
            BtnCancel.Enabled = false;
            ChkState.Enabled = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;

            foreach (System.Windows.Forms.TextBox Txt in this.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                Txt.Enabled = false;
                Txt.Text = "";
            }

            foreach (System.Windows.Forms.ComboBox Cmb in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                Cmb.Enabled = false;
                Cmb.SelectedIndex = -1;
            }

            TxtSearch.Enabled = true;
        }

        private void setValues()
        {
            userCode = TxtUserCode.Text.Trim();
            userName = h.SanitizeStr(TxtUserName.Text.Trim());
            userPassword = pwdHasher.MakeHash(TxtPwd.Text.Trim());
            userState = ChkState.Checked;
            employeeCode = CmbEmployees.SelectedValue.ToString();
            roleId = Convert.ToInt32(CmbRole.SelectedValue);
        }

        private int validateData()
        {
            int error = 0;

            if (!Regex.Match(TxtUserName.Text, RegexPatterns.UsernamePattern).Success)
            {
                h.MsgError("EL NOMBRE DE USUARIO NO ES VÁLIDO. ¡LETRAS MAYÚSCULAS O MINÚSCULAS, NÚMEROS Y GUIÓN BAJO SON PERMITIDOS!");
                TxtUserName.Focus();
                error++;
                return error;
            }

            if (isEdit == false)
            {
                if (!Regex.Match(TxtPwd.Text, RegexPatterns.PasswordPattern).Success)
                {
                    h.MsgError("LA CONTRASEÑA NO ES VÁLIDA. ¡DEBE CONTENER AL MENOS UNA LETRA MAYÚSCULA, UNA MINÚSCULA, UN NÚMERO Y UN CARACTER ESPECIAL!");
                    TxtPwd.Focus();
                    error++;
                    return error;
                }
            }

            if (CmbRole.SelectedValue == null)
            {
                h.MsgError("DEBE SELECCIONAR UN ROL PARA EL USUARIO.");
                CmbRole.Focus();
                error++;
                return error;
            }

            if (CmbEmployees.SelectedValue == null)
            {
                h.MsgError("DEBE SELECCIONAR UN EMPLEADO PARA EL USUARIO.");
                CmbEmployees.Focus();
                error++;
                return error;
            }
            return error;
        }

        private void getUsers(string searchFilter, bool isDel)
        {
            DgvUsers.Rows.Clear();
            IEnumerable<UserDTO> users = userController.getUsers(searchFilter, isDel);

            if (users.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getUsers("", isDel);
                    TxtSearch.Clear();
                }
                return;
            }



            foreach (var item in users)
            {
                DgvUsers.Rows.Add(item.USER_CODE, item.USER_NAME, item.ROLE_NAME, item.USER_STATE ? "ACTIVO" : "INACTIVO", Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }


        }

        private void fillCmbEmployees()
        {
            var employees = employeeController.getEmployees("");

            CmbEmployees.DataSource = employees;
            CmbEmployees.DisplayMember = "EMPLOYEE_NAME";
            CmbEmployees.ValueMember = "EMPLOYEE_CODE";
            CmbEmployees.SelectedIndex = -1;


        }

        private void fillCmbRoles()
        {
            List<USER_ROLES> lst = roleController.getRoles("", false);

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



            var nextId = moduleId + correlativesController.getNextId(moduleId);

            TxtUserCode.Text = nextId;
            BtnNew.Enabled = false;

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getUsers(TxtSearch.Text.Trim(), flagIsPaperbin);
        }


        private void DgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvUsers.Rows.Count > 0)
            {
                UserDTO user = userController.getInfoUser(DgvUsers.CurrentRow.Cells[0].Value.ToString());

                if (user != null)
                {
                    isEdit = true;
                    BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                    BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
                    BtnEdit.Enabled = flagIsPaperbin ? false : true;
                    BtnDelete.Enabled = flagIsPaperbin ? false : true;
                    BtnNew.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = true;
                    ChkState.Enabled = true;
                    PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                    PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");

                    TxtUserCode.Enabled = false;
                    TxtUserName.Enabled = true;
                    TxtPwd.Enabled = true;
                    CmbRole.Enabled = true;
                    CmbEmployees.Enabled = true;

                    TxtUserName.Focus();
                    TxtUserCode.Text = user.USER_CODE;
                    TxtUserName.Text = user.USER_NAME;
                    CmbRole.Text = user.ROLE_NAME;
                    ChkState.Checked = user.USER_STATE == true ? true : false;

                    CmbEmployees.SelectedValue = user.EMPLOYEE_CODE;
                    CmbRole.SelectedValue = user.ROLE_ID;
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0011);
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
                    USERS newUser = userController.getUser(TxtUserCode.Text);
                    EMPLOYEE_USER empUser = employeeUserController.getEmployeeUser(TxtUserCode.Text);

                    string cambios = "";
                    var separator = ", ";

                    if (newUser.USER_NAME != userName)
                        cambios += $"USER_NAME: '{newUser.USER_NAME}' → '{userName}'{separator}";

                    if (newUser.USER_STATE != userState)
                        cambios += $"USER_STATE: '{newUser.USER_STATE}' → '{userState}'{separator}";

                    if (newUser.ROLE_ID != roleId)
                        cambios += $"ROLE_ID: '{newUser.ROLE_ID}' → '{roleId}'{separator}";

                    if (!string.IsNullOrEmpty(userPassword) && newUser.USER_PASSWORD != userPassword)
                        cambios += $"USER_PASSWORD: '[oculto]' → '[nuevo]'{separator}";

                    if (empUser.EMPLOYEE_CODE != employeeCode)
                        cambios += $"EMPLOYEE_CODE: '{empUser.EMPLOYEE_CODE}' → '{employeeCode}'{separator}";

                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(cambios))
                        cambios = cambios.TrimEnd(',', ' ');

                    newUser.USER_CODE = userCode;
                    newUser.USER_NAME = userName;
                    if (!String.IsNullOrEmpty(userPassword)) newUser.USER_PASSWORD = userPassword;
                    newUser.USER_STATE = userState;
                    newUser.ROLE_ID = roleId;
                    empUser.EMPLOYEE_CODE = employeeCode;
                    empUser.USER_CODE = userCode;



                    if (userController.updateUser(newUser) > 0 && employeeUserController.updateEmployeeUser(empUser) > 0)
                    {
                        if (!string.IsNullOrEmpty(cambios))
                        {
                            string logDesc = $"El usuario {User.userName} modificó al usuario {userName}. Cambios: {cambios}.";
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

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                USERS user = userController.getUser(TxtUserCode.Text);

                if (userController.deleteUser(user.USER_CODE) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {User.userName} eliminó permanentemente al usuario {user.USER_NAME}.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0008);
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
                USERS user = userController.getUser(TxtUserCode.Text);
                user.IS_DEL = false;
                if (userController.updateUser(user) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {User.userName} restauró al usuario {user.USER_NAME} de la papelera.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0018);
                }
            }
        }

        private void PbxPrint_Click(object sender, EventArgs e)
        {
            if (DgvUsers.Rows.Count > 0)
            {
                FrmDefaultRpt frmGenericRpt = new FrmDefaultRpt();


                DataTable dt = h.GetDataTableFromDataGridView(DgvUsers);

                string pathRpt = @"..\..\Views\Reports\RDLC\ReportUsers.rdlc";

                string dtsName = "DtsUsers";
                frmGenericRpt.fillRpt(dt, pathRpt, dtsName);
                frmGenericRpt.ShowDialog();
            }
            else
            {
                h.MsgError(Helpers.App.Msg0012);
            }
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            flagIsPaperbin = true;
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            getUsers("", flagIsPaperbin);
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {

            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                USERS user = userController.getUser(TxtUserCode.Text);
                user.IS_DEL = true;
                if (userController.updateUser(user) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {User.userName} movió al usuario {user.USER_NAME} a la papelera de reciclaje.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0005);
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
            if (e.KeyCode == Keys.Enter)
            {
                getUsers(TxtSearch.Text, flagIsPaperbin);
            }
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getUsers("", flagIsPaperbin);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                USERS user = new USERS();
                user.USER_CODE = userCode;
                user.USER_NAME = userName;
                user.USER_PASSWORD = userPassword;
                user.USER_STATE = userState;
                user.ROLE_ID = roleId;
                user.CREATED_BY= Config.User.userId;
                user.INSERTED_AT = DateTime.Now;

                if (userController.saveUser(user) > 0)
                {
                    var nextId = "EUS" + correlativesController.getNextId("EUS");
                    EMPLOYEE_USER employeeUser = new EMPLOYEE_USER();
                    employeeUser.EMPLOYEE_USER_ID = nextId;
                    employeeUser.EMPLOYEE_CODE = employeeCode;
                    employeeUser.USER_CODE = userCode;
                    employeeUser.INSERTED_AT = DateTime.Now;
                    if (employeeUserController.saveEmployeeUser(employeeUser) > 0)
                    {
                        await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {User.userName} insertó al usuario {userName}.", moduleId, DateTime.Now);

                        h.MsgInfo(Helpers.App.Msg0001);
                        startForm();
                    }
                    else
                    {
                        h.MsgError("OCURRIO UN ERROR EL USUARIO NO PUDO SER ASIGNADO AL EMPLEADO CORRECTAMENTE.");
                    }
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0015);
                }
            }
        }
    }
}
