using parking.Config;
using parking.DTO;
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

namespace parking.Controllers
{
    internal class UserController: DataBaseController
    {
        private Models.UserModel userModel;
        Helpers.Helpers h;
        Helpers.PasswordHasher pwdHasher;
        RolePermissionsController rpc= new RolePermissionsController();
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
                    if (lst.USER_NAME.ToString() == username && pwdHasher.VerifyPassword(password,lst.USER_PASSWORD) && lst.USER_STATE == true)
                    {
                        Config.User.userName = username;
                        Config.User.realName= db.EMPLOYEES.Where(e => e.EMPLOYEE_CODE == db.EMPLOYEE_USER.Where(u => u.USER_CODE == lst.USER_CODE).Select(u => u.EMPLOYEE_CODE).FirstOrDefault()).Select(e => e.EMPLOYEE_NAME + " " + e.EMPLOYEE_LASTNAME).FirstOrDefault();
                        Config.User.roleId = lst.ROLE_ID;
                        Config.User.userId= lst.USER_CODE;
                        Config.User.roleName= db.USER_ROLES.Where(r => r.ROLE_ID == lst.ROLE_ID).Select(r => r.ROLE_NAME).FirstOrDefault();


                        PermissionManager.UserPermissions= rpc.getPermissionsByRole(lst.ROLE_ID);

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

        public USERS getUser(string userId)
        {

           USERS user = new USERS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    user = db.USERS.Find(userId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return user;
        }

        public UserDTO getInfoUser(string id)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = db.USERS
                        .Join(db.USER_ROLES, usr => usr.ROLE_ID, rol => rol.ROLE_ID, (usr, rol) => new { usr, rol })
                        .Join(db.EMPLOYEE_USER, ur => ur.usr.USER_CODE, empUsr => empUsr.USER_CODE, (ur, empUsr) => new { ur.usr, ur.rol, empUsr })
                        .Join(db.EMPLOYEES, ure => ure.empUsr.EMPLOYEE_CODE, emp => emp.EMPLOYEE_CODE, (ure, emp) => new UserDTO
                        {
                            USER_CODE = ure.usr.USER_CODE,
                            USER_NAME = ure.usr.USER_NAME,
                            USER_PASSWORD = ure.usr.USER_PASSWORD,
                            USER_STATE = ure.usr.USER_STATE,
                            ROLE_ID = ure.usr.ROLE_ID,
                            ROLE_NAME = ure.rol.ROLE_NAME,
                            EMPLOYEE_CODE = emp.EMPLOYEE_CODE,
                            EMPLOYEE_NAME = emp.EMPLOYEE_NAME,
                            INSERTED_AT = ure.usr.INSERTED_AT,
                            IS_DEL = ure.usr.IS_DEL
                        })
                        .FirstOrDefault(u => u.USER_CODE == id);

                    return query ?? new UserDTO(); 
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
            }

            return new UserDTO(); 
        }


        public IEnumerable<UserDTO> getUsers(string searchFilter = "", bool isDel = false)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = db.USERS
                        .Join(db.USER_ROLES, user => user.ROLE_ID, role => role.ROLE_ID, (user, role) => new UserDTO
                        {
                            USER_CODE = user.USER_CODE,
                            USER_NAME = user.USER_NAME,
                            ROLE_NAME = role.ROLE_NAME,
                            USER_STATE = user.USER_STATE,
                            IS_DEL = user.IS_DEL,
                            INSERTED_AT = user.INSERTED_AT
                        })
                        .Where(user => user.IS_DEL == isDel);

                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query = query.Where(user => user.USER_NAME.Contains(searchFilter));
                    }

                    return query.OrderBy(user => user.USER_CODE).ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
            }

            return Enumerable.Empty<UserDTO>(); 
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
                h.MsgError("ERROR INESPERADO: " + ex.Message);
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
                h.MsgError("ERROR INESPERADO: " + ex.Message);
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
                    if(HasReferences(db,db.EMPLOYEE_USER, e=> e.USER_CODE==id)){
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;
                    }
                    USERS user = db.USERS.Find(id);
                    db.USERS.Attach(user);
                    db.USERS.Remove(user);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
            }

            return result;
        }
    }
}
