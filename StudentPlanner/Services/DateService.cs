using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner
{
    class DateService
    {
        //planner starts from 31/12/2018
        //getting the week number relative to this
        public static int GetWeekNumber(DateTime time) {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);

            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) time = time.AddDays(3);

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static bool DateAfterToday(DateTime dt)
        {
            return dt >= DateTime.Now;
        }
    }
}
