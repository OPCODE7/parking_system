using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.DTO
{
    internal class ClientDTO
    {
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CLIENT_LASTNAME { get; set; }
        public string CLIENT_EMAIL { get; set; }
        public string CLIENT_ADDRESS { get; set; }
        public string CLIENT_PHONE { get; set; }
        public string USER_ID { get; set; }
        public bool IS_DEL { get; set; }
        public string USER_NAME { get; set; }
        public DateTime INSERTED_AT { get; set; }
        public string CLIENT_DNI { get; set; }
    }
}
