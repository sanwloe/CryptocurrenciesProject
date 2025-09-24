using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Helpers
{
    public static class DateTimeHelper
    {
        public static long GetUnixTimeMs(this DateTime dateTime)
        {
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUniversalTime().ToUnixTimeMilliseconds();
        }
        public static DateTime GetDateTimeFromUnix(this long unixTime) 
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTime);
            return dateTimeOffset.LocalDateTime;
        }
    }
}
