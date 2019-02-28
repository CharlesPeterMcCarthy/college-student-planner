using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Day {

        //properties
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime Date { get; private set; }
        public List<Task> Tasks { get; private set; }

        public Day(DateTime date, List<Task> tasks) : this(date) {
            Tasks = tasks;
        }

        public Day(DateTime date) {
            Date = date;
            SetDayOfWeek();
        }

        public void AddTask(Task task) {
            Tasks.Add(task);
        }

        private void SetDayOfWeek() {
            DayOfWeek = Date.DayOfWeek;
        }

    }//end of the Day Class
}
