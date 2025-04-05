using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class UserDTO
    {
        public string USER_CODE { get; set; }
        public string USER_NAME { get; set; }
        public string USER_PASSWORD { get; set; }
        public bool USER_STATE { get; set; }
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public bool IS_DEL { get; set; }

    }
}
