using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class ParkingFeeDTO
    {
        public string PARKING_FEE_CODE { get; set; }
        public string PARKING_TYPE_CODE { get; set; }
        public string DESCRIPTION_PARKING_TYPE { get; set; }
        public decimal PRICE_FOR_HOUR { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public bool IS_DEL { get; set; }
        public string USER_CODE { get; set; }
        public string USER_NAME { get; set; }
    }
}
