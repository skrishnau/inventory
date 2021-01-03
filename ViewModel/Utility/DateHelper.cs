using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Utility
{
    public class DateHelper
    {
        public static string ToFormattedDateString(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy/MM/dd") : "";
        }

        public static string ToFormattedDateTimeString(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy/MM/dd HH:mm:ss") : "";
        }

        public static DateTime? ConvertToDateTime(string str)
        {
            DateTime date;
            if (DateTime.TryParse(str, out date))
                return date;
            return null;
        }

        public static bool IsValidIgnoreWhiteSpaceAndNull(string dt)
        {
            if (string.IsNullOrEmpty(dt))
                return true;
            DateTime date;
            return DateTime.TryParse(dt, out date);
        }
    }
}
