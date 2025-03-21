using parking.Views.Administration.Configuration;
using parking.Views.Administration.Employees;
using parking.Views.Administration.ParkingStructure;
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

        public AdminPanel()
        {
            InitializeComponent();
        }


        private void PbxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

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

            ParkingStructure.FrmCheckOut frmCheckOut = new ParkingStructure.FrmCheckOut();
            frmCheckOut.MdiParent = this;
            frmCheckOut.Show();

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            this.Focus();
            
        }

        private void BtnCompanyData_Click(object sender, EventArgs e)
        {
            List<Form> form = Application.OpenForms.Cast<Form>().ToList().Where(x => x.Name != "AdminPanel").ToList();
            form.ForEach(x => x.Hide());

            FrmCompany frmCompany = new FrmCompany();
            frmCompany.MdiParent = this;
            frmCompany.Show();
        }
    }
}
