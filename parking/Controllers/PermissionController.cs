using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using parking.DTO;
using parking.Models;

namespace parking.Controllers
{
    internal class PermissionController: DataBaseController
    {

        private USER_PERMISSIONS permission;
        Helpers.Helpers h= new Helpers.Helpers();
        public PermissionController() { 
            permission= new USER_PERMISSIONS();
        }

        public IEnumerable<PermissionDTO> getPermissions(string searchFilter = "", bool isDel = false)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from p in db.USER_PERMISSIONS
                                join m in db.APP_MODULES on p.MODULE_ID equals m.MODULE_ID
                                where p.IS_DEL == isDel
                                select new PermissionDTO
                                {
                                    PERMISSION_ID = p.PERMISSION_ID,
                                    PERMISSION_DESCRIPTION = p.PERMISSION_DESCRIPTION,
                                    MODULE_ID = p.MODULE_ID,
                                    MODULE_NAME = m.MODULE_NAME,
                                    ACTION = p.ACTION,
                                    INSERTED_AT = p.INSERTED_AT,
                                    IS_DEL = p.IS_DEL
                                };
                    var result= query.ToList();

                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        result = result.Where(p =>
                            p.PERMISSION_DESCRIPTION.Contains(searchFilter) ||
                            p.MODULE_NAME.Contains(searchFilter) ||
                            p.ACTION.Contains(searchFilter) ||
                            p.PERMISSION_ID.ToString().Contains(searchFilter) ||
                            h.DoesDateMatch(p.INSERTED_AT,searchFilter)).ToList();
                    }

                    return result.OrderBy(p => p.PERMISSION_ID).ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return Enumerable.Empty<PermissionDTO>();
        }


        public PermissionDTO getPermissionInfo(int id)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from p in db.USER_PERMISSIONS
                                join m in db.APP_MODULES on p.MODULE_ID equals m.MODULE_ID
                                where p.PERMISSION_ID == id
                                select new PermissionDTO
                                {
                                    PERMISSION_ID = p.PERMISSION_ID,
                                    PERMISSION_DESCRIPTION = p.PERMISSION_DESCRIPTION,
                                    MODULE_ID = p.MODULE_ID,
                                    MODULE_NAME = m.MODULE_NAME,
                                    ACTION = p.ACTION,
                                    INSERTED_AT = p.INSERTED_AT,
                                    IS_DEL = p.IS_DEL
                                };

                    return query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
                return null;
            }
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
