using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Config
{
    internal class PermissionManager
    {
        public static List<string> UserPermissions { get; set; } = new List<string>();

        public static bool HasPermission(string permission)
        {
            return UserPermissions.Contains(permission);
        }
    }
}
