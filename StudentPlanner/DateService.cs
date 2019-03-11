using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner
{
    class DateService
    {
        //planner starts from 31/12/2018
        //getting the week number relative to this
        public static int GetWeekNumber(DateTime dt)
        {
            DateTime startDate = new DateTime(2018, 12, 31);
            int days = (dt - startDate).Days;

            return (days / 7) + 1;
        }

        public static bool DateAfterToday(DateTime dt)
        {
            return dt >= DateTime.Now;
        }
    }
}
