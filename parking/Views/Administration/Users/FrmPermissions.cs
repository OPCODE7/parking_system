using parking.Config;
using parking.Controllers;
using parking.DTO;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Employees
{
    public partial class FrmPermissions : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        Controllers.PermissionController permissionController = new Controllers.PermissionController();
        DataBaseController dbController = new DataBaseController();
        AppModulesController appModulesController = new AppModulesController();
        string permissionDescription, moduleId, action, _moduleId = "PER";
        int permissionId;
        bool flagIsPaperbin;
        IEnumerable<dynamic> allModules;
        public FrmPermissions()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPermissions_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void startForm()
        {
            getPermissions("",false);
            fillCmbModules();
            flagIsPaperbin = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(_moduleId, "Crear");
            BtnPaperbin.Enabled = PermissionManager.HasPermission("PAP", "Acceso");
            PbxRecovery.Visible = false;
            PbxDestroy.Visible = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Enabled = false;
            BtnCancel.Enabled = false;
            CmbActions.Enabled = false;
            CmbActions.SelectedIndex = -1;
            CmbModules.Enabled = false;
            CmbModules.SelectedIndex = -1;
            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = false;
                Txt.Text = "";
            }
            TxtSearch.Enabled = true;

        }

        private void setValues()
        {

            moduleId = CmbModules.SelectedValue.ToString();
            permissionDescription = h.SanitizeStr(TxtPermissionDescription.Text.Trim().ToString());
            action = CmbActions.SelectedItem.ToString();

        }


        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnDelete.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            CmbActions.Enabled = true;
            CmbModules.Enabled = true;
            BtnNew.Enabled = false;



            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;

            }

            TxtPermissionCode.Enabled = false;
            CmbModules.Focus();

            TxtPermissionCode.Text = dbController.getNextIdModule("USER_PERMISSIONS").ToString();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (validateData() == 0)
            {
                setValues();

                USER_PERMISSIONS newPermission = new USER_PERMISSIONS();
                newPermission.PERMISSION_DESCRIPTION = permissionDescription;
                newPermission.ACTION = CmbActions.SelectedItem.ToString();
                newPermission.MODULE_ID = moduleId;
                newPermission.INSERTED_AT = DateTime.Now;
                newPermission.USER_ID = Config.User.userId;


                int result = permissionController.savePermission(newPermission);
                if (result > 0)
                {
                    h.MsgSuccess(Helpers.App.Msg0001);
                    DgvPermissions.Rows.Clear();
                    startForm();
                }
            }

        }

        private int validateData()
        {
            int error = 0;
            if (CmbModules.SelectedItem == null)
            {
                h.MsgWarning("SELECCIONAR UN MODULO");
                CmbModules.Focus();
                error++;
                return error;
            }

            if (!Regex.Match(TxtPermissionDescription.Text, Helpers.RegexPatterns.AlphabeticPatternWithAccent).Success)
            {
                h.MsgWarning("INGRESAR DESCRIPCION DEL PERMISO CORRECTAMENTE. ¡SOLO LETRAS!");
                TxtPermissionDescription.Focus();
                error++;
                return error;
            }

            if (CmbActions.SelectedItem == null)
            {
                h.MsgWarning("SELECCIONAR UNA ACCIOsN");
                CmbActions.Focus();
                error++;
                return error;
            }

            return error;
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getPermissions(TxtSearch.Text,flagIsPaperbin);
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getPermissions("",flagIsPaperbin);
        }

        private void DgvPermissions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPermissions.Rows.Count > 0)
            {
                var permission = permissionController.getPermissionInfo(Convert.ToInt32(DgvPermissions.CurrentRow.Cells[0].Value.ToString()));

                if (permission != null)
                {

                    TxtPermissionCode.Text = permission.PERMISSION_ID.ToString();
                    CmbModules.SelectedValue = permission.MODULE_ID;
                    TxtPermissionDescription.Text = permission.PERMISSION_DESCRIPTION;
                    CmbModules.Focus();
                    CmbModules.Enabled = true;
                    TxtPermissionDescription.Enabled = true;
                    CmbActions.Enabled = true;
                    CmbActions.SelectedItem = permission.ACTION;

                    BtnEdit.Enabled = PermissionManager.HasPermission(_moduleId, "Modificar");
                    BtnDelete.Enabled = PermissionManager.HasPermission(_moduleId, "Eliminar");
                    BtnEdit.Enabled = flagIsPaperbin ? false : true;
                    BtnDelete.Enabled= flagIsPaperbin ? false : true;
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (validateData() == 0)
            {

                if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
                {
                    setValues();
                    USER_PERMISSIONS permission = permissionController.getPermission(Convert.ToInt32(TxtPermissionCode.Text));
                    permission.MODULE_ID = moduleId;
                    permission.PERMISSION_DESCRIPTION = permissionDescription;
                    permission.ACTION = CmbActions.SelectedItem.ToString();

                    int result = permissionController.updatePermission(permission);
                    if (result > 0)
                    {
                        h.MsgSuccess(Helpers.App.Msg0003);
                        DgvPermissions.Rows.Clear();
                        startForm();
                    }

                }
            }
        }

        private void fillCmbModules()
        {

            allModules = appModulesController.getModules();
            CmbModules.DataSource = allModules;
            CmbModules.ValueMember = "MODULE_ID";
            CmbModules.DisplayMember = "MODULE_NAME";
            CmbModules.SelectedIndex = -1;
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                USER_PERMISSIONS registro = permissionController.getPermission(Convert.ToInt32(TxtPermissionCode.Text));
                registro.IS_DEL= true;
                int result = permissionController.updatePermission(registro);

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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }



        private void CmbModules_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (CmbModules.Items.Count > 0)
                {
                    var item = (dynamic)CmbModules.SelectedItem;
                    CmbModules.Text = item.MODULE_NAME;
                    CmbModules.SelectionStart = CmbModules.Text.Length;
                }
                return;
            }

            filterCmbModules();

        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            PbxRecovery.Visible = true;
            PbxDestroy.Visible = true;
            flagIsPaperbin = true;
            getPermissions("", flagIsPaperbin);

        }

        private void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                USER_PERMISSIONS registro = permissionController.getPermission(Convert.ToInt32(TxtPermissionCode.Text));
                registro.IS_DEL = false;
                if (permissionController.updatePermission(registro) > 0)
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
                USER_PERMISSIONS registro = permissionController.getPermission(Convert.ToInt32(TxtPermissionCode.Text));
                int result = permissionController.deletePermission(registro);
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

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PbxSearch_Click(sender, e);
            }

        }

        private void filterCmbModules()
        {
            string text = CmbModules.Text.ToLower();
            int cursorPos = CmbModules.SelectionStart;

            if (string.IsNullOrEmpty(text))
            {
                fillCmbModules();
                CmbModules.SelectedIndex = -1;
            }
            else
            {
                var filtrados = allModules
                    .Where(m => m.MODULE_NAME.ToLower().Contains(text))
                    .ToList();



                CmbModules.DataSource = filtrados;
                CmbModules.ValueMember = "MODULE_ID";
                CmbModules.DisplayMember = "MODULE_NAME";
                CmbModules.DroppedDown = true;

                CmbModules.Text = text;
                CmbModules.SelectionStart = cursorPos;
                CmbModules.SelectionLength = 0;
            }

        }

        private void getPermissions(string searchFilter,bool isDel)
        {
            DgvPermissions.Rows.Clear();

            IEnumerable<PermissionDTO> lst = permissionController.getPermissions(searchFilter,isDel);

            if (lst.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);
                if (searchFilter != "")
                {
                    getPermissions("",isDel);
                    TxtSearch.Clear();
                }
                return;
            }

            foreach (var item in lst)
            {
                DgvPermissions.Rows.Add(item.PERMISSION_ID, item.MODULE_NAME, item.PERMISSION_DESCRIPTION, item.ACTION, Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }

        }
    }
}
