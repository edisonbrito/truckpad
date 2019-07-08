using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPad.Api.Helper
{
    public static class DateHelper
    {
        public static Tuple<DateTime, DateTime> GetDateOfWeek()
        {
            var date = DateTime.Now;
            
            var currentDay = date.DayOfWeek;
            int days = (int)currentDay;

            DateTime sunday = date.AddDays(-days);

            var daysThisWeek = Enumerable.Range(0, 7)
                .Select(d => sunday.AddDays(d))
                .ToList();

            return Tuple.Create(daysThisWeek.Min(), daysThisWeek.Max());
        }

        public static Tuple<DateTime, DateTime> GetDateOfMonth()
        {
            List<DateTime> diasDoMes = Enumerable.Range(1, DateTime.DaysInMonth(2019, 07))
                    .Select(day => new DateTime(2019, 07, day))
                    .ToList();

            return Tuple.Create(diasDoMes.Min(), diasDoMes.Max());
        }
    }
}
