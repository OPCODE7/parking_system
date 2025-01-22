using parking.Views.Administration.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.MdiParent = this;
            frmUsers.Show();
        }

        private void BtnPermissions_Click(object sender, EventArgs e)
        {
            FrmPermissions frmPermissions= new FrmPermissions();
            frmPermissions.MdiParent = this;
            frmPermissions.Show();
        }
    }
}
