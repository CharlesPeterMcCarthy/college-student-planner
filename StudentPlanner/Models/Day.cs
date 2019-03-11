using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class Day {

        //properties
        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime Date { get; private set; }
        public ObservableCollection<Task> Tasks { get; private set; }

        //instanciating the observable collection. Taking in the list of tasks and turning it into an observable collection
        public Day(DateTime date, List<Task> tasks) : this(date) {
            Tasks = new ObservableCollection<Task>(tasks);
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
