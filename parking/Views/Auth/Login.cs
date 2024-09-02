using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Views.Auth
{
    public partial class Login : Form
    {
        Helpers.Helpers help= new Helpers.Helpers();
        string userName, password;
        Controllers.UserController userController= new Controllers.UserController();
        Administration.AdminPanel frmAdminPanel= new Administration.AdminPanel();
        public Login()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            userName= help.SanitizeStr(TxtUserName.Text.Trim());
            password = help.SanitizeStr(TxtPwd.Text.Trim());
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SetValues();
            string result= userController.Login(userName, password);
            if (result == "Exito")
            {
                this.Hide();
                frmAdminPanel.ShowDialog();
            }
            else
            {
                help.MsgWarning(result);
            }

        }
    }
}
