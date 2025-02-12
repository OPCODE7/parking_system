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
        Helpers.Helpers h;
        Helpers.PasswordHasher pwdHasher;
        public UserController()
        {
            userModel = new Models.UserModel();
            pwdHasher = new Helpers.PasswordHasher();
            h = new Helpers.Helpers();
        }

        public bool Login(string username, string password)
        {
            bool result = false;
            using (PARKINGEntities db = new PARKINGEntities())
            {
                USERS lst = db.USERS.FirstOrDefault(user => (user.USER_NAME == username && user.IS_DEL == false));

                if (lst != null)
                {
                    if (lst.USER_NAME.ToString() == username && pwdHasher.verifyPassword(password,lst.USER_PASSWORD) && lst.USER_STATE == true)
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

        public dynamic getUser(string id)
        {
            dynamic user = new USERS();
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    var query = from usr in db.USERS
                                join rol in db.USER_ROLES
                                on usr.ROLE_ID equals rol.ROLE_ID
                                join empUsr in db.EMPLOYEE_USER
                                on usr.USER_CODE equals empUsr.USER_CODE
                                join emp in db.EMPLOYEES
                                on empUsr.EMPLOYEE_CODE equals emp.EMPLOYEE_CODE
                                select new
                                {
                                    USER_CODE= usr.USER_CODE,
                                    USER_NAME= usr.USER_NAME,
                                    USER_PASSWORD= usr.USER_PASSWORD,
                                    USER_STATE= usr.USER_STATE,
                                    ROLE_ID= usr.ROLE_ID,
                                    ROLE_NAME= rol.ROLE_NAME,
                                    EMPLOYEE_CODE= emp.EMPLOYEE_CODE,
                                    EMPLOYEE_NAME= emp.EMPLOYEE_NAME,
                                    INSERTED_AT= usr.INSERTED_AT,
                                    IS_DEL= usr.IS_DEL
                                   
                                };
                    user = query.Where(u => u.IS_DEL == false && u.USER_CODE==id).FirstOrDefault();
                }

            }catch(Exception ex)
            {
               h.MsgError("Error al obtener usuario: " + ex.Message);
            }

            return user;

            
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
                        .Where(user => (user.IS_DEL == false && user.USER_NAME.Contains(searchFilter))).OrderBy(user => user.USER_CODE).ToList();

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
                        .Where(user => (user.IS_DEL == false)).OrderBy(user => user.USER_CODE).ToList();
                    }


                }

            }
            catch (Exception ex)
            {
                h.MsgError("Error al obtener usuarios: " + ex.Message);
            }

            return users;

        }

        public int saveUser(USERS user)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.USERS.Add(user);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int updateUser(USERS user)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int deleteUser(string id)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    USERS user = db.USERS.Find(id);
                    db.USERS.Attach(user);
                    db.USERS.Remove(user);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }
    }
}
