using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Week {

        //properties
        public int WeekNumber { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Day> Days { get; private set; } = new List<Day>();

        public Week(int weekNumber, DateTime startDate, DateTime endDate) {
            WeekNumber = weekNumber;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Week(int weekNumber, DateTime startDate, DateTime endDate, List<Day> days) : this(weekNumber, startDate, endDate) {
            Days = days;
        }

        //methods
        public void AddDay(Day day)
        {
            Days.Add(day);
        }

    }//end of the Week Class
}
