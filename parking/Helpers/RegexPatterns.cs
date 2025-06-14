using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Helpers
{
    internal class RegexPatterns
    {
        public static string EmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public static string PhonePattern = @"^(\d{10})$";
        public static string NumberPattern = @"^(\d+)$";
        public static string DecimalPattern = @"^(\d+)(\.\d+)?$";
        public static string DatePattern = @"^(\d{4}-\d{2}-\d{2})$";
        public static string TimePattern = @"^(\d{2}:\d{2}:\d{2})$";
        public static string AlphanumericPattern = @"^([a-zA-Z0-9\s]+)$";
        public static string AlphanumericPatternWithAccentAndSpecialChars = @"^([a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ,.]+)$";
        public static string AlphabeticPattern = @"^([a-zA-Z\s]+)$";
        public static string AlphabeticPatternWithAccent = @"^([a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+)$";
        public static string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
        public static string UsernamePattern = "^[a-zA-Z0-9_]+$";
    public static string AddressPattern= @"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ,.\-]+$";
        public static string LicensePlatePattern = @"^([a-zA-Z0-9\s]{1,10})$";
        public static string AlphabeticPatternWithAccentAndSpecialChars = @"^([a-zA-Z\sáéíóúÁÉÍÓÚñÑ,.]+)$";
        public static string RTNPattern = @"^\d{14}$";
        public static string DNIPattern= @"^[A-Z\d]{13,15}$";
        public static string Percentage= @"^(\d{1,2}|100)(\.\d+)?%$"; 
    }
}
