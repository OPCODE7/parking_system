using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class CheckOutDTO
    {
        public string CHECK_IN_CODE { get; set; }
        public string CLIENT_CODE { get; set; }
        public string OBSERVATIONS { get; set; }
        public string VEHICLE_PLATE { get; set; }
        public DateTime CHECK_IN_TIME { get; set; }
        public string PARKING_SPACE_CODE { get; set; }
        public int PARKING_SPACE_NUMBER { get; set; }
        public string DESCRIPTION_PARKING_TYPE { get; set; }
        public string PARKING_FEE_CODE { get; set; }
        public decimal PRICE_FOR_HOUR { get; set; }
        public DateTime CHECK_OUT_TIME { get; set; }
        public string CHECK_OUT_STATE { get; set; }
        public bool DEL { get; set; }
        public string USER_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CLIENT_LASTNAME { get; set; }
        public decimal ISV { get; set; }
        public DateTime DATE_OF_ISSUE { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal TOTAL { get; set; }
        public string CHECK_OUT_CODE { get; set; }
        public decimal TOTAL_TIME { get; set; }

        public decimal FULL_CHARGE { get; set; }

    }
}
