using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_DAL.Helper
{
    public static class DateHelper
    {
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek)
        {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return date.AddDays(-diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime date, DayOfWeek startOfWeek)
        {
            return StartOfWeek(date, startOfWeek).AddDays(6);
        }

        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return StartOfMonth(date).AddMonths(1).AddDays(-1);
        }
    
    }
}
