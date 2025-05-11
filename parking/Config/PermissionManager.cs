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

        /// <summary>
        /// Verifica si el usuario actual tiene un permiso específico dentro de un módulo determinado.
        /// </summary>
        /// <param name="module">Identificador del módulo a verificar (insensible a mayúsculas).</param>
        /// <param name="permission">Nombre de la acción o permiso requerido (insensible a mayúsculas).</param>
        /// <returns>
        /// <c>true</c> si el usuario tiene el permiso solicitado para el módulo; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool HasPermission(string module, string permission)
        {

            return UserPermissions.Any(p => p.MODULE_ID.ToLower() == module.ToLower() && p.ACTION.ToLower() == permission.ToLower());
        }
    }
}
