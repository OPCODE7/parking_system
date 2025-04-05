using parking.Config;
using parking.Views.Administration.Configuration;
using parking.Views.Administration.Employees;
using parking.Views.Administration.ParkingStructure;
using parking.Views.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace parking.Views.Administration
{
    public partial class AdminPanel : Form
    {
        PermissionManager pm = new PermissionManager();
        public AdminPanel()
        {
            InitializeComponent();
        }


       
        private void startForm()
        {

            
            BtnUsers.Enabled = PermissionManager.HasPermission("USR", "Acceso");
            BtnManageUsers.Enabled = PermissionManager.HasPermission("USR", "Acceso");
            BtnConfig.Enabled = PermissionManager.HasPermission("CFG", "Acceso");
            BtnPermissions.Enabled = PermissionManager.HasPermission("PER", "Acceso");
            BtnRoles.Enabled = PermissionManager.HasPermission("ROL", "Acceso");
            BtnEmployees.Enabled = PermissionManager.HasPermission("EMP", "Acceso");
            BtnHorary.Enabled = PermissionManager.HasPermission("HOR", "Acceso");
            BtnParkingType.Enabled = PermissionManager.HasPermission("PTY", "Acceso");
            BtnParkingSpace.Enabled = PermissionManager.HasPermission("PSP", "Acceso");
            BtnParkingFee.Enabled = PermissionManager.HasPermission("PKF", "Acceso");
            BtnCheckIn.Enabled = PermissionManager.HasPermission("CIN", "Acceso");
            BtnClients.Enabled = PermissionManager.HasPermission("CLI", "Acceso");
            BtnCheckout.Enabled = PermissionManager.HasPermission("COUT", "Acceso");
            BtnCompanyData.Enabled = PermissionManager.HasPermission("COMP", "Acceso");
            BtnBillRanges.Enabled = PermissionManager.HasPermission("RFAC", "Acceso");
            BtnUserPermissions.Enabled = PermissionManager.HasPermission("UPER", "Acceso");
            BtnReports.Enabled= PermissionManager.HasPermission("RPT", "Acceso");


            BtnJobPositions.Enabled = PermissionManager.HasPermission("JPS", "Acceso");


        }

        private void BtnUsers_Click_1(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.MdiParent = this;
            frmUsers.Show();
        }

        private void BtnPermissions_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());
            FrmPermissions frmPermissions= new FrmPermissions();
            frmPermissions.MdiParent = this;
            frmPermissions.Show();
        }

        private void BtnRoles_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name!="AdminPanel").ToList();
            form.ForEach(x => x.Hide());
            

            FrmRoles frmRoles = new FrmRoles();
            frmRoles.MdiParent = this;
            frmRoles.Show();
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());


            FrmEmployees frmEmployees= new FrmEmployees();
            frmEmployees.MdiParent = this;
            frmEmployees.Show();

        }

        private void BtnHorary_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());


            FrmHorary frmHorary = new FrmHorary();
            frmHorary.MdiParent = this;
            frmHorary.Show();

        }

        private void BtnJobPositions_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmJobPositions frmJobPositions = new FrmJobPositions();
            frmJobPositions.MdiParent = this;
            frmJobPositions.Show();

        }

        private void BtnParkingType_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

           FrmParkingTypes frmParkingTypes = new FrmParkingTypes();
            frmParkingTypes.MdiParent = this;
            frmParkingTypes.Show();

        }

        private void BtnParkingSpace_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmParkingSpace frmParkingSpace = new FrmParkingSpace();
            frmParkingSpace.MdiParent = this;
            frmParkingSpace.Show();

        }

        private void BtnParkingFee_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmParkingFee frmParkingFee = new FrmParkingFee();
            frmParkingFee.MdiParent = this;
            frmParkingFee.Show();

        }

        private void BtnCheckIn_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmCheckIn frmCheckIn = new FrmCheckIn();
            frmCheckIn.MdiParent = this;
            frmCheckIn.Show();
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            Clients.FrmClient frmClient = new Clients.FrmClient();
            frmClient.MdiParent = this;
            frmClient.Show();
            

        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmCheckOut frmCheckOut = new FrmCheckOut();
            frmCheckOut.MdiParent = this;
            frmCheckOut.Show();

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            LblUserLogged.Text= User.userName;
            LblFecha.Text= DateTime.Now.ToLongDateString();
            LblRole.Text= User.roleName;
            startForm();


        }

        private void BtnCompanyData_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmCompany frmCompany = new FrmCompany();
            frmCompany.MdiParent = this;
            frmCompany.Show();
        }

        private void BtnBillRanges_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmBillRanges frmBillRanges = new FrmBillRanges();
            frmBillRanges.MdiParent = this;
            frmBillRanges.Show();

        }

        private void BtnUserPermissions_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmSetUserPermissions frmSetUserPermissions = new FrmSetUserPermissions();
            frmSetUserPermissions.MdiParent = this;
            frmSetUserPermissions.Show();

        }

        private void PbxLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}
