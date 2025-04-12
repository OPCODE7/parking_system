using parking.Config;
using parking.Controllers;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration.Configuration
{

    public partial class FrmSetUserPermissions : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        RoleController roleController = new RoleController();
        RolePermissionsController rolePermissionController = new RolePermissionsController();
        PermissionController permissionController = new PermissionController();
        LogBookAppController lac = new LogBookAppController();
        AppModulesController amc= new AppModulesController();

        string moduleId = "UPER";
        APP_MODULES moduleData = new APP_MODULES();
        public FrmSetUserPermissions()
        {
            InitializeComponent();
            moduleData = amc.getModule(moduleId);
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSetUserPermissions_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void fillCmbRoles()
        {
            List<USER_ROLES> roles = roleController.getRoles("", false);

            CmbRoles.DataSource = roles;
            CmbRoles.DisplayMember = "ROLE_NAME";
            CmbRoles.ValueMember = "ROLE_ID";
            CmbRoles.SelectedIndex = -1;
        }

        private void fillTrvPermissions()
        {
            TrvPermissions.Nodes.Clear();


            var permissions = permissionController.getPermissions();

            if (permissions == null || !permissions.Any())
            {
                h.MsgError(Helpers.App.Msg0012);
                return;
            }

            var groupModules = permissions.GroupBy(p => p.MODULE_NAME);


            foreach (var groupModule in groupModules)
            {
                TreeNode nodeModule = new TreeNode(groupModule.Key);
                nodeModule.Tag = groupModule.Key;

                foreach (var permission in groupModule)
                {
                    TreeNode actionNode = new TreeNode(permission.ACTION);
                    actionNode.Tag = permission.PERMISSION_ID;
                    nodeModule.Nodes.Add(actionNode);
                }

                TrvPermissions.Nodes.Add(nodeModule);

                foreach (TreeNode node in TrvPermissions.Nodes)
                {
                    node.Checked = false;
                }
            }

            TrvPermissions.ExpandAll();
            if (TrvPermissions.Nodes.Count > 0)
            {
                var firstNode = TrvPermissions.Nodes[0];
                firstNode.EnsureVisible();
            }
        }

        private void startForm()
        {
            fillCmbRoles();
            fillTrvPermissions();
            TrvPermissions.Enabled = false;
            BtnSave.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbRoles.SelectedValue == null)
                {
                    h.MsgError("SELECCIONE UN ROL");
                    return;
                }

                int roleId = Convert.ToInt32(CmbRoles.SelectedValue);

                foreach (TreeNode parentNode in TrvPermissions.Nodes)
                {
                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        int permissionId = Convert.ToInt32(childNode.Tag);
                        bool isChecked = childNode.Checked;

                        var existing = rolePermissionController.getRolePermission(roleId, permissionId);
                        var permission = permissionController.getPermission(permissionId);
                        var role = roleController.getRole(roleId);

                        if (isChecked && existing == null)
                        {
                            var newRolePermission = new ROLE_PERMISSIONS
                            {
                                ROLE_ID = roleId,
                                PERMISSION_ID = permissionId,
                                INSERTED_AT = DateTime.Now
                            };

                            int saved = rolePermissionController.saveRolePermission(newRolePermission);

                            if (saved > 0)
                            {
                                await lac.saveLog(Config.User.userId, "Insertar",
                                     $"El usuario {User.userName} habilitó el permiso {permission.PERMISSION_DESCRIPTION} del módulo {moduleData.MODULE_NAME} para el rol {role.ROLE_NAME}.",
                                     moduleId, DateTime.Now);

                            }
                        }
                        else if (!isChecked && existing != null)
                        {
                            int deleted = rolePermissionController.deleteRolePermission(existing);

                            if (deleted > 0)
                            {
                                await lac.saveLog(Config.User.userId, "Eliminar",
                                    $"El usuario {User.userName} deshabilitó el permiso {permission.PERMISSION_DESCRIPTION} del módulo {moduleData.MODULE_NAME} para el rol {role.ROLE_NAME}.",
                                    moduleId, DateTime.Now);
                            }
                        }
                        // Si está marcado y ya existe, no hacemos nada.
                        // Si no está marcado y no existe, tampoco.
                    }
                }

                // Actualizar permisos del usuario
                PermissionManager.UserPermissions = rolePermissionController.getPermissionsByRole(User.roleId);

                h.MsgInfo(Helpers.App.Msg0003);
                startForm();

                if (User.roleId == roleId)
                {
                    h.MsgInfo("DEBES DESCONECTARTE PARA VER LOS CAMBIOS!");
                }
            }
            catch (Exception ex)
            {
                h.MsgError($"Ocurrió un error: {ex.Message}");
            }
        }

        private void CmbRoles_TextChanged(object sender, EventArgs e)
        {
            if (CmbRoles.SelectedValue != null)
            {
                var selectedRole = CmbRoles.SelectedValue;

                if (selectedRole is int id)
                {

                    TrvPermissions.Enabled = true;
                    foreach (TreeNode parentNode in TrvPermissions.Nodes)
                    {
                        parentNode.Checked = false;
                        foreach (TreeNode childNode in parentNode.Nodes)
                        {
                            childNode.Checked = false;
                        }

                    }
                    int roleId = id;
                    IEnumerable<dynamic> lst = rolePermissionController.getPermissionsByRole(roleId);
                    if (lst != null && lst.Any())
                    {
                        foreach (TreeNode parentNode in TrvPermissions.Nodes)
                        {
                            int countChecked = 0;
                            foreach (TreeNode childNode in parentNode.Nodes)
                            {
                                foreach (var item in lst)
                                {
                                    if (Convert.ToInt32(childNode.Tag) == item.PERMISSION_ID)
                                    {
                                        childNode.Checked = true;
                                        countChecked++;

                                    }

                                }
                            }
                            if (countChecked == parentNode.Nodes.Count) parentNode.Checked = true;

                        }

                    }
                }
            }
        }

        private void TrvPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode childNode in e.Node.Nodes)
                {
                    childNode.Checked = e.Node.Checked;
                }
            }
        }
    }
}
