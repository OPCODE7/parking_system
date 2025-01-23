using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using parking.Models;

namespace parking.Controllers
{
    internal class PermissionController
    {

        private Models.USER_PERMISSIONS permission;
        Helpers.Helpers h= new Helpers.Helpers();
        public PermissionController() { 
            permission= new Models.USER_PERMISSIONS();
        }

        public List<USER_PERMISSIONS> getPermissions(string searchFilter)
        {
            List<USER_PERMISSIONS> lst= new List<USER_PERMISSIONS>();
            try
            {
                using (PARKINGEntities permissions = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        lst = permissions.USER_PERMISSIONS.Where(permission => permission.PERMISSION_NAME.Contains(searchFilter)).ToList();
                    }
                    else
                    {
                        lst = permissions.USER_PERMISSIONS.Where(permission => permission.IS_DEL == false).ToList();

                    }
                }

            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
                
            }
                return lst;
        }

        public USER_PERMISSIONS getPermission(int id)
        {
            USER_PERMISSIONS permission= new USER_PERMISSIONS();
            try
            {
                using (PARKINGEntities permissions = new PARKINGEntities())
                {
                    permission = permissions.USER_PERMISSIONS.Find(id);

                }

            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
                
            }
            return permission;

        }

        public int savePermission(USER_PERMISSIONS permission)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.USER_PERMISSIONS.Add(permission);
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;

        }

        public int updatePermission(USER_PERMISSIONS permission)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(permission).State = EntityState.Modified;
                    result = db.SaveChanges();
                }

            }
            catch(Exception ex)
            {

               h.MsgError(ex.ToString());
            }
            

            return result;

        }

        public int deletePermission(USER_PERMISSIONS permission) { 
            int result= 0;

            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.USER_PERMISSIONS.Attach(permission);
                    db.USER_PERMISSIONS.Remove(permission);
                    result = db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
           

            return result;
        }
    }
}
