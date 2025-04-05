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

namespace parking.Views.Administration.Configuration
{

    public partial class FrmSetUserPermissions : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        RoleController roleController = new RoleController();
        RolePermissionsController rolePermissionController = new RolePermissionsController();
        PermissionController permissionController = new PermissionController();

        string moduleId = "UPER";
        public FrmSetUserPermissions()
        {
            InitializeComponent();
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
            List<USER_ROLES> roles = roleController.getRoles("",false);

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
            TrvPermissions.AutoScrollOffset = new Point(0, 0);




        }

        private void startForm()
        {
            fillCmbRoles();
            fillTrvPermissions();
            TrvPermissions.Enabled = false;
            BtnSave.Enabled = PermissionManager.HasPermission(moduleId,"Crear");
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ROLE_PERMISSIONS rolePermission = new ROLE_PERMISSIONS();
            try
            {
                if (CmbRoles.SelectedValue == null)
                {
                    h.MsgError("SELECCIONE UN ROL");
                    return;
                }

                int roleId = Convert.ToInt32(CmbRoles.SelectedValue);

                foreach (TreeNode parenNode in TrvPermissions.Nodes)
                {
                    foreach(TreeNode childNode in parenNode.Nodes)
                    {
                        ROLE_PERMISSIONS rp = rolePermissionController.getRolePermission(roleId, Convert.ToInt32(childNode.Tag));

                        if (childNode.Checked)
                        {
                            rolePermission.ROLE_ID = roleId;
                            rolePermission.PERMISSION_ID = Convert.ToInt32(childNode.Tag);
                            rolePermission.INSERTED_AT = DateTime.Now;

                            if (rp == null) rolePermissionController.saveRolePermission(rolePermission);
                        }
                        else
                        {
                            if (rp != null)
                            {
                                rolePermissionController.deleteRolePermission(rp);
                            }
                        }
                    }
                   
                }

                PermissionManager.UserPermissions = rolePermissionController.getPermissionsByRole(User.roleId);

                h.MsgInfo(Helpers.App.Msg0003);
                startForm();
                if(User.roleId == roleId)
                {
                    h.MsgInfo("DEBES DESCONECTARTE PARA VER LOS CAMBIOS!");
                    
                }
               
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
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
                    foreach (TreeNode node in TrvPermissions.Nodes)
                    {
                        node.Checked = false;
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            childNode.Checked = false;
                        }
                      
                    }
                    int roleId = id;
                    IEnumerable<dynamic> lst = rolePermissionController.getPermissionsByRole(roleId);
                    if (lst != null && lst.Any())
                    {
                        foreach(TreeNode node in TrvPermissions.Nodes)
                        {
                            int counChecked = 0;
                            foreach(TreeNode childNode in node.Nodes)
                            {
                                foreach (var item in lst)
                                {
                                    if (Convert.ToInt32(childNode.Tag) == item.PERMISSION_ID)
                                    {
                                        childNode.Checked = true;
                                        counChecked++;

                                    }
                                   
                                }
                            }
                            if (counChecked == node.Nodes.Count) node.Checked = true;
                            
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
