using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            getUsers();
            fillCmbEmployees();
        }

        public void getUsers()
        {
            using (PARKINGEntities db= new PARKINGEntities())
            {
                var lst = db.USERS.Where(user => (user.IS_DEL == false && user.USER_STATE==true)).ToList();

                DgvUsers.DataSource = lst;

            }
        }

        private void fillCmbEmployees()
        {
            using (PARKINGEntities db = new PARKINGEntities())
            {
                var lst = db.USERS
                         .Where(user => user.IS_DEL == false && user.USER_STATE == true)
                         .Select(user => new
                         {
                             user.USER_CODE,        
                             user.USER_NAME  
                         })
                         .ToList();

                CmbEmployees.DataSource = lst;
                CmbEmployees.DisplayMember = "USER_NAME"; 
                CmbEmployees.ValueMember = "USER_CODE";  
                CmbEmployees.SelectedIndex = -1;


            }


        }
    }
}
