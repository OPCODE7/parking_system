using parking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Controllers
{
    internal class UserController
    {
        private Models.UserModel userModel;
        public UserController()
        {
            userModel = new Models.UserModel();
        }


        /*
        public string Login(string userName,string pwd)
        {
            if (userModel.Login(userName, pwd))
            {
                return "Exito";
            }
            else
            {
                return "Usuario y/o contraseña incorrectos.";
            }

        }
        */

        public bool Login(string username, string password)
        {
            bool result = false;
            using (PARKINGEntities db= new PARKINGEntities())
            {
                var lst = db.USERS.Where(user => (user.USER_NAME == username && user.IS_DEL==false)).ToList();

                if (lst.Count>0)
                {
                    foreach (var item in lst)
                    {
                        if (item.USER_NAME.ToString() == username && item.USER_PASSWORD.ToString() == password && item.USER_STATE==true)
                        {
                            Config.User.userName = username;
                            Config.User.roleId = item.ROLE_ID;

                            result= true;
                        }
                        else
                        {
                            result= false;

                        }
                    }

                }
                else
                {
                    result= false;
                }
            }

            return result;
        }

        /*
        public string SaveUser(Dictionary<string, string> data) {
            if (userModel.SaveUser(data))
            {
                return "El usuario ha sido registrado con éxito.";
            }
            else
            {
                return "Error al registrar usuario.";
            }
        }
        */
        
    }
}
