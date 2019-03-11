using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class Week {

        //properties
        public int WeekNumber { get; private set; }
        public List<Day> Days { get; private set; } = new List<Day>();

        public Week(int weekNumber) {
            WeekNumber = weekNumber;
        }

        public Week(int weekNumber, List<Day> days) : this(weekNumber) {
            Days = days;
        }

        //methods
        public void AddDay(Day day) {
            Days.Add(day);
        }

    }//end of the Week Class
}
