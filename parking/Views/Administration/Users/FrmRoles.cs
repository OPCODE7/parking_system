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
    public partial class FrmRoles : Form
    {
        Helpers.Helpers h= new Helpers.Helpers();
        RoleController roleController = new RoleController();
        string roleName,roleDescription;
        int roleId;
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void startForm()
        {
            getRoles("");
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = false;
            BtnNew.Enabled = true;
            BtnCancel.Enabled = false;

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
            string permissionNamePattern = "^[a-zA-Z\\s]+$";
            string permissionDescriptionPattern = "^[a-zA-Z,.\\s]+$";
            if (!Regex.Match(TxtRoleName.Text, permissionNamePattern).Success)
            {
                h.MsgWarning("Ingresar nombre del rol correctamente. ¡Solo letras!");
                TxtRoleName.Focus();
                error++;
                return error;

            }

            if (!Regex.Match(TxtRoleDescription.Text, permissionDescriptionPattern).Success)
            {
                h.MsgWarning("Ingresar descripción del rol correctamente. ¡Solo letras y signos de puntuación!");
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



            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;

            }

            TxtRoleCode.Enabled = false;
            TxtRoleName.Focus();

            using (PARKINGEntities db = new PARKINGEntities())
            {
                try
                {
                    var nextId = db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('USER_ROLES')").FirstOrDefault();

                    nextId= nextId==1 ? 1 : nextId+1;

                    TxtRoleCode.Text = nextId.ToString();
                    BtnNew.Enabled = false;
                }
                catch(Exception ex)
                {
                    h.MsgError(ex.ToString());
                }
                
            }
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
                    h.MsgSuccess("El rol ha sido guardado correctamente");
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
                        h.MsgSuccess("El rol ha sido actualizado correctamente.");
                        startForm();
                    }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            USER_ROLES registro = new USER_ROLES { ROLE_ID = Convert.ToInt32(TxtRoleCode.Text.Trim())};

            if (h.MsgQuestion($"¿Esta seguro que desea eliminar el rol {registro.ROLE_NAME} de la base de datos?") == "S")
            {
                int result = roleController.deleteRole(registro);

                if (result > 0)
                {
                    h.MsgSuccess("El rol ha sido eliminado correctamente.");
                    startForm();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getRoles(TxtSearch.Text);
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getRoles("");
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                getRoles(TxtSearch.Text);
            }
        }

        public void getRoles(string searchFilter)
        {
           
            DgvRoles.Rows.Clear();
            List<USER_ROLES> lst = roleController.getRoles(searchFilter);

            if (lst.Count == 0)
            {
                h.MsgInfo("No se encontraron registros en la base de datos.");
                if (searchFilter != "")
                {
                    getRoles("");
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
