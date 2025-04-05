using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class BillRangeDTO
    {
        public int BILL_RANGE_ID { get; set; }
        public string ESTABLISHMENT { get; set; }
        public string EMISSION_POINT { get; set; }
        public string DOC_TYPE { get; set; }
        public string BILL_RANGE_STATE { get; set; }
        public int INITIAL_RANGE { get; set; }
        public int FINAL_RANGE { get; set; }
        public int? LAST_USED { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public string USER_CODE { get; set; }
        public string BILL_RANGE_START { get; set; }
        public string BILL_RANGE_END { get; set; }
        public bool DEL { get; set; }
    }
}
