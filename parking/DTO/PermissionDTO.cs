using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class PermissionDTO
    {
        public int PERMISSION_ID { get; set; }
        public string PERMISSION_DESCRIPTION { get; set; }
        public string MODULE_ID { get; set; }
        public string MODULE_NAME { get; set; }
        public string ACTION { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public bool IS_DEL { get; set; }
    }
}
