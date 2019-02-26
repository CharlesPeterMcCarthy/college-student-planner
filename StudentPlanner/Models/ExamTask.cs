using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class ExamTask : Task, IStartableTask {
        //properties
        public string[] MaterialsNeeded { get; private set; }
        public DateTime StartedDatetime { get; private set; }

        public Status StartTask() {
            Status = Status.Started;
            StartedDatetime = DateTime.Now;

            return Status;
        }
    }//end of exam class
}
