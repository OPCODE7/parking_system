using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class SalaryDTO
    {
        public string SALARY_CODE { get; set; }
        public decimal BASE_SALARY { get; set; }
        public decimal INCREASE { get; set; }
        public decimal TOTAL_SALARY { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public string EMPLOYEE_CODE { get; set; }

        public string EMPLOYEE_NAME { get; set; }


    }
}
