using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class RoleController
    {
        Helpers.Helpers h = new Helpers.Helpers();
        private USER_ROLES role;
        public RoleController()
        {
            role= new USER_ROLES();

        }

        public List<USER_ROLES> getRoles(string searchFilter)
        {
            List<USER_ROLES> lst = new List<USER_ROLES>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        lst = db.USER_ROLES.Where(role => role.ROLE_NAME.Contains(searchFilter)).ToList();
                    }
                    else
                    {
                        lst = db.USER_ROLES.Where(role => role.IS_DEL == false).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());

            }
            return lst;

        }

        public USER_ROLES getRole(int roleId)
        {
            USER_ROLES role = new USER_ROLES();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    role = db.USER_ROLES.Find(roleId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return role;

        }

        public int saveRole(USER_ROLES role)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.USER_ROLES.Add(role);
                    result= db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int updateRole(USER_ROLES role)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(role).State = EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int deleteRole(USER_ROLES role)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.USER_ROLES.Attach(role);
                    db.USER_ROLES.Remove(role);
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
