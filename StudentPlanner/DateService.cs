using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner
{
    class DateService
    {

        public static int GetWeekNumber(DateTime dt)
        {
            DateTime startDate = new DateTime(2018, 12, 31);
            int days = (dt - startDate).Days;

            return (days / 7) + 1;
        }

        public static bool DateAfterToday(DateTime dt)
        {
            Console.WriteLine(dt);
            Console.WriteLine(DateTime.Now);
            return dt > DateTime.Now;
        }
    }
}
