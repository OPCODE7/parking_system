using parking.Models;
using System;
using System.Collections;
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
        Helpers.Helpers h = new Helpers.Helpers();
        public UserController()
        {
            userModel = new Models.UserModel();
        }

        public bool Login(string username, string password)
        {
            bool result = false;
            using (PARKINGEntities db = new PARKINGEntities())
            {
                USERS lst = db.USERS.FirstOrDefault(user => (user.USER_NAME == username && user.IS_DEL == false));

                if (lst != null)
                {
                    if (lst.USER_NAME.ToString() == username && lst.USER_PASSWORD.ToString() == password && lst.USER_STATE == true)
                    {
                        Config.User.userName = username;
                        Config.User.roleId = lst.ROLE_ID;

                        result = true;
                    }
                    else
                    {
                        result = false;

                    }

                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public IEnumerable<dynamic> getUsers(string searchFilter)
        {
           IEnumerable<dynamic> users= new List<dynamic>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                       users= db.USERS
                        .Join(db.USER_ROLES, user => user.ROLE_ID, role =>    role.ROLE_ID, (user, role) => new
                         {
                             USER_CODE = user.USER_CODE,
                             USER_NAME = user.USER_NAME,
                             ROLE_NAME = role.ROLE_NAME,
                             USER_STATE = user.USER_STATE,
                             IS_DEL = user.IS_DEL,
                             INSERTED_AT = user.INSERTED_AT
                         })
                        .Where(user => (user.IS_DEL == false && user.USER_STATE == true && user.USER_NAME.Contains(searchFilter))).ToList();

                    }
                    else
                    {
                        users = db.USERS
                        .Join(db.USER_ROLES, user => user.ROLE_ID, role => role.ROLE_ID, (user, role) => new
                        {
                            USER_CODE = user.USER_CODE,
                            USER_NAME = user.USER_NAME,
                            ROLE_NAME = role.ROLE_NAME,
                            USER_STATE = user.USER_STATE,
                            IS_DEL = user.IS_DEL,
                            INSERTED_AT = user.INSERTED_AT
                        })
                        .Where(user => (user.IS_DEL == false && user.USER_STATE == true)).ToList();


                    }


                }

            }
            catch (Exception ex)
            {
                h.MsgError("Error al obtener usuarios: " + ex.Message);
            }

            return users;

        }
    }
}
