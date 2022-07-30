using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static double GetDaysBetweenTwo(string date1, string date2)
        {
            int[] date1Args = date1.Split().Select(int.Parse).ToArray();
            DateTime firstDate = new DateTime(date1Args[0], date1Args[1], date1Args[2]);

            int[] date2Args = date2.Split().Select(int.Parse).ToArray();
            DateTime secondDate = new DateTime(date2Args[0], date2Args[1], date2Args[2]);

            return Math.Abs((firstDate - secondDate).TotalDays);
        }
    }
}
