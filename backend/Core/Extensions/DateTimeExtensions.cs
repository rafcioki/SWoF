using System;
using System.Collections.Generic;

namespace Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> EachDay(this DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }
    }
}
