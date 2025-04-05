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

namespace parking.Views.Administration.Employees
{
    public partial class FrmRoles : Form
    {
        Helpers.Helpers h= new Helpers.Helpers();
        RoleController roleController = new RoleController();
        DataBaseController dbController= new DataBaseController();
        string roleName,roleDescription,moduleId= "ROL";
        int roleId;
        bool flagIsPaperbin = false;
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void startForm()
        {
            getRoles("",false);
            flagIsPaperbin = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId,"CREAR");
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

             roleName= h.SanitizeStr(TxtRoleName.Text.Trim().ToString());
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

            TxtRoleCode.Text= dbController.getNextIdModule("USER_ROLES").ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                USER_ROLES newRole= new USER_ROLES();
                newRole.ROLE_NAME = roleName;
                newRole.DESCRIPTION_ROLE = roleDescription;
                newRole.INSERTED_AT = DateTime.Now;

                if (roleController.saveRole(newRole) > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0001);
                    startForm();
                }

            }

        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            setValues();

            if (validateData() == 0)
            {
                    USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
                    role.ROLE_NAME = roleName;
                    role.DESCRIPTION_ROLE = roleDescription;

                    int result = roleController.updateRole(role);
                    if (result > 0)
                    {
                        h.MsgSuccess(Helpers.App.Msg0003);
                        startForm();
                    }
                    else
                    {
                        h.MsgError(Helpers.App.Msg0017);
                    }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
            role.IS_DEL = true;

            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                int result = roleController.updateRole(role);

                if (result > 0)
                {
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
            getRoles("",flagIsPaperbin);
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

                    BtnEdit.Enabled = PermissionManager.HasPermission(moduleId,"Modificar");
                    BtnDelete.Enabled = PermissionManager.HasPermission(moduleId,"Eliminar");

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

        private void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
                role.IS_DEL = false;
                int result = roleController.updateRole(role);
                if (result > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0018);
                }
            }

        }

        private void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                USER_ROLES role = roleController.getRole(Convert.ToInt32(TxtRoleCode.Text));
                int result = roleController.deleteRole(role);
                if (result > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                getRoles(TxtSearch.Text,flagIsPaperbin);
            }
        }

        public void getRoles(string searchFilter,bool isDel)
        {
           
            DgvRoles.Rows.Clear();
            List<USER_ROLES> lst = roleController.getRoles(searchFilter,isDel);

            if (lst.Count == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getRoles("",isDel);
                    TxtSearch.Clear();
                }
                return;
            }

            foreach (USER_ROLES role in lst)
            {
                DgvRoles.Rows.Add(role.ROLE_ID, role.ROLE_NAME, role.DESCRIPTION_ROLE, role.INSERTED_AT);
            }

        }
    }
}
