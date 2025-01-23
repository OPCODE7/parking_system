using parking.Config;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Employees
{
    public partial class FrmPermissions : Form
    {
        Helpers.Helpers h= new Helpers.Helpers();
        Controllers.PermissionController permissionController = new Controllers.PermissionController();
        string permissionName, permissionDescription;
        int permissionId;
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
            getPermissions("");
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

            permissionName = h.SanitizeStr(TxtPermissionName.Text.Trim().ToString());
            permissionDescription= h.SanitizeStr(TxtPermissionDescription.Text.Trim().ToString());
            
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

            TxtPermissionCode.Enabled = false;
            TxtPermissionName.Focus();

            using (PARKINGEntities db = new PARKINGEntities())
            {
                var nextId = db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('USER_PERMISSIONS')").FirstOrDefault() + 1;
               

                TxtPermissionCode.Text = nextId.ToString();
                BtnNew.Enabled = false;
            }

        }


    

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (validateData() == 0)
            {
                setValues();

                USER_PERMISSIONS newPermission = new USER_PERMISSIONS();
                newPermission.PERMISSION_NAME= permissionName;
                newPermission.PERMISSION_DESCRIPTION = permissionDescription;
                newPermission.INSERTED_AT= DateTime.Now;
                    

                int result= permissionController.savePermission(newPermission);
                if (result > 0)
                {
                    h.MsgSuccess("El permiso ha sido guardado correctamente.");
                    DgvPermissions.Rows.Clear();
                    startForm();
                }
            }

        }

        private int validateData()
        {
            int error = 0;
            string permissionNamePattern = "^[a-zA-Z\\s]+$";
            string permissionDescriptionPattern = "^[a-zA-Z,.\\s]+$";
            if (!Regex.Match(TxtPermissionName.Text,permissionNamePattern).Success)
            {
                h.MsgWarning("Ingresar nombre del permiso correctamente. ¡Solo letras!");
                TxtPermissionName.Focus();
                error++;
                return error;

            }

            if (!Regex.Match(TxtPermissionDescription.Text, permissionDescriptionPattern).Success)
            {
                h.MsgWarning("Ingresar descripción del permiso correctamente. ¡Solo letras y signos de puntuación!");
                TxtPermissionDescription.Focus();
                error++;
                return error;
            }

            return error;

        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getPermissions(TxtSearch.Text);
        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            getPermissions("");
        }

        private void DgvPermissions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DgvPermissions.Rows.Count > 0)
            {
                    USER_PERMISSIONS permission = permissionController.getPermission(Convert.ToInt32(DgvPermissions.CurrentRow.Cells[0].Value));

                 if(permission!= null) { 
                    
                        TxtPermissionCode.Text = permission.PERMISSION_ID.ToString();
                        TxtPermissionName.Text= permission.PERMISSION_NAME;
                        TxtPermissionDescription.Text = permission.PERMISSION_DESCRIPTION;
                        TxtPermissionName.Focus();
                        TxtPermissionName.Enabled = true;
                        TxtPermissionDescription.Enabled = true;

                        BtnEdit.Enabled = true;
                        BtnDelete.Enabled= true;
                        BtnNew.Enabled = false;
                        BtnSave.Enabled = false;
                        BtnCancel.Enabled = true;

                 }else{
                    h.MsgError("El registro no ha sido encontrado en la base de datos.");
                 }

            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            setValues();

            if(validateData() == 0)
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    USER_PERMISSIONS permission = permissionController.getPermission(Convert.ToInt32(TxtPermissionCode.Text));
                    permission.PERMISSION_NAME = permissionName;
                    permission.PERMISSION_DESCRIPTION = permissionDescription;

                    int result= permissionController.updatePermission(permission);
                    if (result > 0)
                    {
                        h.MsgSuccess("El permiso ha sido actualizado correctamente.");
                        DgvPermissions.Rows.Clear();
                        startForm();
                    }
                }
            }
           

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (PARKINGEntities db = new PARKINGEntities())
            {
                USER_PERMISSIONS registro = new USER_PERMISSIONS { PERMISSION_ID = Convert.ToInt32(TxtPermissionCode.Text.Trim())};

                if (h.MsgQuestion($"¿Esta seguro que desea eliminar el permiso {registro.PERMISSION_NAME} de la base de datos?") == "S")
                {
                   int result= permissionController.deletePermission(registro);

                    if (result > 0)
                    {
                        h.MsgSuccess("El permiso ha sido eliminado correctamente.");
                        DgvPermissions.Rows.Clear();
                        startForm();
                    }
                }

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                getPermissions(TxtSearch.Text);
            }
            
        }

        private void getPermissions(string searchFilter)
        {
            DgvPermissions.Rows.Clear();
            List<USER_PERMISSIONS> lst = new List<USER_PERMISSIONS>();
            lst= permissionController.getPermissions(searchFilter);

            if(lst.Count == 0)
            {
                h.MsgWarning("No se encontraron registros en la base de datos.");
                if(searchFilter != "")
                {
                    getPermissions("");
                }
                return;
            }

            foreach (var item in lst)
            {
                DgvPermissions.Rows.Add(item.PERMISSION_ID, item.PERMISSION_NAME, item.PERMISSION_DESCRIPTION, Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }

        }
    }
}
