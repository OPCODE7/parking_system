using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class ParkingSpaceDTO
    {
        public string PARKING_SPACE_CODE { get; set; }
        public int PARKING_SPACE_NUMBER { get; set; }
        public string PARKING_FEE_CODE { get; set; }
        public decimal PRICE_FOR_HOUR { get; set; }
        public bool STATE { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public string PARKING_TYPE_DESCRIPTION { get; set; }
        public string PARKING_TYPE_CODE { get; set; }

        public bool IS_DEL { get; set; }
    }
}
