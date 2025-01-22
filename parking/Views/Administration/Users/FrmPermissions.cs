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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Administration.Employees
{
    public partial class FrmPermissions : Form
    {
        Helpers.Helpers h= new Helpers.Helpers();
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


            foreach (TextBox Txt in this.Controls.OfType<TextBox>())
            {
                Txt.Enabled = true;

            }

            using (PARKINGEntities db = new PARKINGEntities())
            {
                var lst = db.USER_PERMISSIONS.Select(permission => permission.PERMISSION_ID).ToList();

                if(lst.Count > 0)
                {
                    permissionId = lst.Last() + 1;
                }
                else
                {
                    permissionId = 1;
                }

                TxtPermissionCode.Text = permissionId.ToString();
                BtnNew.Enabled = false;
            }

        }


    

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (validateData() == 0)
            {
                setValues();

                using (PARKINGEntities db = new PARKINGEntities())
                {
                    try
                    {

                        USER_PERMISSIONS newPermission = new USER_PERMISSIONS();
                        newPermission.PERMISSION_NAME= permissionName;
                        newPermission.PERMISSION_DESCRIPTION = permissionDescription;
                        newPermission.INSERTED_AT= DateTime.Now;
                    

                        db.USER_PERMISSIONS.Add(newPermission);
                        if (db.SaveChanges() > 0)
                        {
                            h.MsgSuccess("El permiso ha sido guardado correctamente.");
                            DgvPermissions.Rows.Clear();
                            startForm();
                        }
                    }catch(Exception ex)
                    {
                        h.MsgWarning(ex.ToString());
                    }
                    


                }
            }



        }

        private int validateData()
        {
            int error = 0;
            if (TxtPermissionName.Text.Trim().Length == 0)
            {
                h.MsgWarning("Ingresar nombre del permiso.");
                TxtPermissionName.Focus();
                error++;
                return error;

            }

            if (TxtPermissionDescription.Text.Trim().Length == 0)
            {
                h.MsgWarning("Ingresar descripción del permiso.");
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
                using (PARKINGEntities db= new PARKINGEntities())
                {
                    var permission = db.USER_PERMISSIONS
                        .Find(Convert.ToInt32(DgvPermissions.CurrentRow.Cells[0].Value));
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
                    var permission = db.USER_PERMISSIONS.Find(Convert.ToInt32(TxtPermissionCode.Text));
                    permission.PERMISSION_NAME = permissionName;
                    permission.PERMISSION_DESCRIPTION = permissionDescription;

                    db.Entry(permission).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
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
                var registro = new USER_PERMISSIONS { PERMISSION_ID = Convert.ToInt32(TxtPermissionCode.Text.Trim())};

                db.USER_PERMISSIONS.Attach(registro);
                db.USER_PERMISSIONS.Remove(registro);

                if (h.MsgQuestion($"¿Esta seguro que desea eliminar el permiso {registro.PERMISSION_NAME} de la base de datos?") == "S")
                {

                    if (db.SaveChanges() > 0)
                    {
                        h.MsgSuccess("El permiso ha sido eliminado correctamente.");
                        DgvPermissions.Rows.Clear();
                        startForm();
                    }
                }

            }
        }

        private void getPermissions(string searchFilter)
        {
            DgvPermissions.Rows.Clear();
            using(PARKINGEntities permissions = new PARKINGEntities())
            {
                if (searchFilter != "")
                {
                    var lst = permissions.USER_PERMISSIONS.Where(permission => permission.PERMISSION_NAME.Contains(searchFilter)).ToList();

                    foreach (var item in lst)
                    {
                        DgvPermissions.Rows.Add(item.PERMISSION_ID, item.PERMISSION_NAME, item.PERMISSION_DESCRIPTION, Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
                    }
                }
                else
                {
                    var lst = permissions.USER_PERMISSIONS.Where(permission => permission.IS_DEL==false).ToList();

                    foreach(var item in lst)
                    {
                        DgvPermissions.Rows.Add(item.PERMISSION_ID, item.PERMISSION_NAME, item.PERMISSION_DESCRIPTION,Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
                    }


                }
            }

        }
    }
}
