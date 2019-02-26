using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class EventTask : Task, IStartableTask, IPausableTask {
        //properties
        public string Location { get; private set; }
        public DateTime StartedDatetime { get; private set; }
        public DateTime PausedDatetime { get; private set; }

        public Status PauseTask() {
            Status = Status.Paused;
            PausedDatetime = DateTime.Now;

            return Status;
        }

        public Status StartTask() {
            Status = Status.Started;
            StartedDatetime = DateTime.Now;

            return Status;
        }
    }//end of event class
}
