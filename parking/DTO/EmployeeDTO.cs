using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class EmployeeDTO
    {
        public string EMPLOYEE_CODE { get; set; }
        public string EMPLOYEE_DNI { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_LASTNAME { get; set; }

        public string EMPLOYEE_FULL_NAME { get; set; }
        public string DESCRIPTION_JOB_POSITION { get; set; }
        public TimeSpan INITIAL_HOUR { get; set; }
        public TimeSpan FINAL_HOUR { get; set; }

        public string HORARY_DESCRIPTION { get; set; }
        public string EMPLOYEE_PHONE { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public bool IS_DEL { get; set; }
    }
}
