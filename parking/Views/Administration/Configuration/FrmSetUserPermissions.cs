using parking.Controllers;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Configuration
{

    public partial class FrmSetUserPermissions : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        RoleController roleController = new RoleController();
        RolePermissionsController rolePermissionController = new RolePermissionsController();
        PermissionController permissionController = new PermissionController();
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
            List<USER_ROLES> roles = roleController.getRoles("");

            CmbRoles.DataSource = roles;
            CmbRoles.DisplayMember = "ROLE_NAME";
            CmbRoles.ValueMember = "ROLE_ID";
            CmbRoles.SelectedIndex = -1;
        }

        private void fillTrvPermissions()
        {
            TrvPermissions.Nodes.Clear();
           

            List<USER_PERMISSIONS> permissions = permissionController.getPermissions("");

            if (permissions == null || !permissions.Any())
            {
                h.MsgError("Sin registros en la base de datos");
                return;
            }

            foreach (var perm in permissions)
            {
                TreeNode node = new TreeNode(perm.PERMISSION_NAME + " - " + perm.PERMISSION_DESCRIPTION);
                node.Tag = perm.PERMISSION_ID;
                TrvPermissions.Nodes.Add(node);
            }
            foreach (TreeNode node in TrvPermissions.Nodes)
            {
                node.Checked = false;
            }

        }



       

        private void startForm()
        {
            fillCmbRoles();
            fillTrvPermissions();
            TrvPermissions.Enabled = false;
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
                    h.MsgError("Seleccione un rol");
                    return;
                }

                int roleId = Convert.ToInt32(CmbRoles.SelectedValue);

                foreach (TreeNode node in TrvPermissions.Nodes)
                {
                    ROLE_PERMISSIONS rp = rolePermissionController.getRolePermission(roleId, Convert.ToInt32(node.Tag));
                    
                    if (node.Checked)
                    {
                        rolePermission.ROLE_ID = roleId;
                        rolePermission.PERMISSION_ID = Convert.ToInt32(node.Tag);

                        if(rp == null)rolePermissionController.saveRolePermission(rolePermission);
                    }
                    else
                    {
                        if (rp != null) {
                            rolePermissionController.deleteRolePermission(rp);
                        }
                    }
                }
                h.MsgInfo("Permisos guardados correctamente");
                startForm();
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
                    }
                    int roleId = id;
                    IEnumerable<dynamic> lst = rolePermissionController.getPermissionsByRole(roleId);
                    if (lst != null && lst.Any())
                    {
                        foreach (var item in lst)
                        {
                            foreach (TreeNode node in TrvPermissions.Nodes)
                            {
                                if (Convert.ToInt32(node.Tag) == item.PERMISSION_ID)
                                {
                                    node.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
