using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Config
{
    internal class PermissionManager
    {
        public static IEnumerable<dynamic> UserPermissions= new List<dynamic>();

        public static bool HasPermission(string module, string permission)
        {

            return UserPermissions.Any(p => p.MODULE_ID.ToLower() == module.ToLower() && p.ACTION.ToLower() == permission.ToLower());
        }
    }
}
