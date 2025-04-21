using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class BillDTO
    {
        public string BILL_NUMBER { get; set; }
        public string BILL_CODE { get; set; }
        public DateTime DATE_OF_ISSUE { get; set; }
        public decimal ISV { get; set; }
        public string RTN { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal DISCOUNT { get; set; }
        public string USER_CODE { get; set; }
        public string USER_NAME { get; set; }
        public string CLIENT_FULL_NAME { get; set; }
    }
}
