using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Day {

        //properties
        public string DayOfWeek { get; private set; }
        public DateTime Date { get; private set; }
        public List<Task> Tasks { get; private set; }

        //methods
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }//end of the method AddTask

    }//end of the Day Class
}
