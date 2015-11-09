using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datapel.BreezeAPI.SDK.Helper
{
    public class DateTimeHelper
    {
        const string initialDate = "01/Jan/2000";
        public static long DateToLong(DateTime date)
        {
            return Convert.ToInt64(date.ToOADate()) - Convert.ToInt64(Convert.ToDateTime(initialDate).ToOADate());
        }

        public static DateTime DateFromLong(long date)
        {
            TimeSpan days = new TimeSpan(Convert.ToInt32(date), 0, 0, 0, 0);
            DateTime epoch = Convert.ToDateTime(initialDate);
            return (epoch + days);
        }
    }
}
