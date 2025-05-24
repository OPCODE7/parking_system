using parking.Config;
using parking.Controllers;
using parking.Helpers;
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
    public partial class FrmRoles : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        RoleController roleController = new RoleController();
        DataBaseController dbController = new DataBaseController();
        Controllers.LogBookAppController lac = new Controllers.LogBookAppController();
        string roleName, roleDescription, moduleId = "ROL";
        int roleId;
        bool flagIsPaperbin = false;
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void startForm()
        {
            getRoles("", false);
            flagIsPaperbin = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "CREAR");
            BtnCancel.Enabled = false;
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Enabled = false;
            PbxDestroy.Enabled = false;
            PbxDestroy.Visible = false;
            PbxRecovery.Visible = false;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Text = "";
            }
            TxtSearch.Enabled = true;

        }

        private void setValues()
        {

            roleName = h.SanitizeStr(TxtRoleName.Text.Trim().ToString());
            roleDescription = h.SanitizeStr(TxtRoleDescription.Text.Trim().ToString());

        }

        private int validateData()
        {
            int error = 0;
            if (!Regex.Match(TxtRoleName.Text, RegexPatterns.AlphabeticPatternWithAccent).Success)
            {
                h.MsgWarning("INGRESAR NOMBRE DEL ROL CORRECTAMENTE. ¡SOLO LETRAS!");
                TxtRoleName.Focus();
                error++;
                return error;

            }

            if (!Regex.Match(TxtRoleDescription.Text, RegexPatterns.AlphabeticPatternWithAccentAndSpecialChars).Success)
            {
                h.MsgWarning("INGRESAR DESCRIPCION DEL ROL CORRECTAMENTE. ¡SOLO LETRAS, PUNTOS Y COMAS!");
                TxtRoleDescription.Focus();
                error++;
                return error;
            }

            return error;

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnDelete.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;

            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;
            }

            TxtRoleCode.Enabled = false;
            TxtRoleName.Focus();

            TxtRoleCode.Text = dbController.getNextIdModule("USER_ROLES").ToString();
        }



        private void FrmRoles_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            setValues();

            if (validateData() == 0)
            {
                USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
                string changes = "";
                var separator = ", ";

                if (role.ROLE_NAME != roleName)
                    changes += $"ROLE_NAME: '{role.ROLE_NAME}' → '{roleName}'{separator}";


                if (role.DESCRIPTION_ROLE != roleDescription)
                    changes += $"DESCRIPTION_ROLE: '{role.DESCRIPTION_ROLE}' → '{roleDescription}'{separator}";

                // Limpiar coma final
                if (!string.IsNullOrEmpty(changes))
                    changes = changes.TrimEnd(',', ' ');

                role.ROLE_NAME = roleName;
                role.DESCRIPTION_ROLE = roleDescription;

                int result = roleController.updateRole(role);
                if (result > 0)
                {
                    if (!string.IsNullOrEmpty(changes))
                    {
                        string logDesc = $"El usuario {User.userName} modificó el rol {role.ROLE_NAME}. Cambios: {changes}.";
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

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
            role.IS_DEL = true;

            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                int result = roleController.updateRole(role);

                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {User.userName} movió el rol {role.ROLE_NAME} a la papelera de reciclaje.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getRoles(TxtSearch.Text, flagIsPaperbin);
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getRoles("", flagIsPaperbin);
        }

        private void DgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvRoles.Rows.Count > 0)
            {
                USER_ROLES role = roleController.getRole(Convert.ToInt32(DgvRoles.CurrentRow.Cells[0].Value));

                if (role != null)
                {

                    TxtRoleCode.Text = role.ROLE_ID.ToString();
                    TxtRoleName.Text = role.ROLE_NAME;
                    TxtRoleDescription.Text = role.DESCRIPTION_ROLE;
                    TxtRoleName.Focus();
                    TxtRoleName.Enabled = true;
                    TxtRoleDescription.Enabled = true;

                    BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                    BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");

                    BtnEdit.Enabled = flagIsPaperbin ? false : true;
                    BtnDelete.Enabled = flagIsPaperbin ? false : true;
                    PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                    PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            flagIsPaperbin = true;
            PbxDestroy.Visible = true;
            PbxRecovery.Visible = true;
            getRoles("", flagIsPaperbin);

        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
                role.IS_DEL = false;
                int result = roleController.updateRole(role);
                if (result > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {User.userName} restauró el rol {role.ROLE_NAME} de la papelera.", moduleId, DateTime.Now);
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
                USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
                int result = roleController.deleteRole(role);
                if (result > 0)
                {
                    await lac.saveLog(User.userId, "Eliminar", $"El usuario {User.userName} eliminó permanentemente el rol {role.ROLE_NAME}.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }

        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                USER_ROLES newRole = new USER_ROLES();
                newRole.ROLE_NAME = roleName;
                newRole.DESCRIPTION_ROLE = roleDescription;
                newRole.INSERTED_AT = DateTime.Now;
                newRole.USER_CODE = Config.User.userId;

                if (roleController.saveRole(newRole) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {User.userName} insertó el rol {roleName}.", moduleId, DateTime.Now);
                    h.MsgSuccess(Helpers.App.Msg0001);
                    startForm();
                }

            }
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getRoles(TxtSearch.Text, flagIsPaperbin);
            }
        }

        public void getRoles(string searchFilter, bool isDel)
        {

            DgvRoles.Rows.Clear();
            List<USER_ROLES> lst = roleController.getRoles(searchFilter, isDel);

            if (lst.Count == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getRoles("", isDel);
                    TxtSearch.Clear();
                }
                return;
            }

            foreach (USER_ROLES role in lst)
            {
                DgvRoles.Rows.Add(role.ROLE_ID, role.ROLE_NAME, role.DESCRIPTION_ROLE, role.INSERTED_AT.ToShortDateString());
            }

        }
    }
}
