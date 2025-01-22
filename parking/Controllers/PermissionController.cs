using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void getPermissions(string searchFilter, DataGridView dgvPermissions)
        {
            try
            {
                using (PARKINGEntities permissions = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        var lst = permissions.USER_PERMISSIONS.Where(permission => permission.PERMISSION_NAME.Contains(searchFilter)).ToList();

                    }
                    else
                    {
                        var lst = permissions.USER_PERMISSIONS.Where(permission => permission.IS_DEL == false).ToList();

                    }
                }
            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
                
            }
                

        }
    }
}
