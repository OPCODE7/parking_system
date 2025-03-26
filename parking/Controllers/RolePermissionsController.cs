using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class RolePermissionsController
    {
        Helpers.Helpers h;
        public RolePermissionsController()
        {
            h = new Helpers.Helpers();
        }


        public IEnumerable<dynamic> getPermissionsByRole(int roleId)
        {
            IEnumerable<dynamic> lst = new List<dynamic>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from rp in db.ROLE_PERMISSIONS
                                join r in db.USER_ROLES on rp.ROLE_ID equals r.ROLE_ID
                                join p in db.USER_PERMISSIONS on rp.PERMISSION_ID equals p.PERMISSION_ID
                                where rp.ROLE_ID == roleId
                                select new
                                {
                                    rp.ROLE_PERMISSION_ID,
                                    p.PERMISSION_ID,
                                    p.PERMISSION_NAME,
                                    r.ROLE_ID,
                                    r.ROLE_NAME
                                };
                    lst = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return lst;

        }

        public int saveRolePermission(ROLE_PERMISSIONS rp)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.ROLE_PERMISSIONS.Add(rp);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public ROLE_PERMISSIONS getRolePermission(int roleId,int permissionId)
        {
            ROLE_PERMISSIONS rp = new ROLE_PERMISSIONS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    rp = db.ROLE_PERMISSIONS.Where(r => r.ROLE_ID==roleId && r.PERMISSION_ID==permissionId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return rp;

        }

        public int deleteRolePermission(ROLE_PERMISSIONS rp)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                   db.Entry(rp).State = System.Data.Entity.EntityState.Deleted;
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
