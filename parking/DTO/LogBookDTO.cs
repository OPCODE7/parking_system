using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class LogBookDTO
    {
        public long LOG_ID { get; set; }
        public string USER_CODE { get; set; }
        public string USER_NAME { get; set; }
        public string ACTION_TYPE { get; set; }
        public string LOG_DESCRIPTION { get; set; }
        public string MODULE_ID { get; set; }

        public string MODULE_NAME { get; set; }

        public DateTime INSERTED_AT { get; set; } 
        
    }
}
