using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class DiscountDTO
    {
        public int DISCOUNT_TYPE_ID  { get; set; }
        public int DISCOUNT_ID { get; set; }
        public string DISCOUNT_TYPE_DESCRIPTION { get; set; }
        public int HOURS { get; set; }
        public int FREQUENCY_DAYS { get; set; }
        public string DISCOUNT_PERCENTAGE { get; set; }
        public string DISCOUNT_DESCRIPTION { get; set; }
        public bool IS_ACTIVE { get; set; }




    }
}
