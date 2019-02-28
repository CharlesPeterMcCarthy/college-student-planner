using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class AssignmentTask : Task, IStartableTask, IPausableTask {
        //properties
        public string Subject { get; private set; }
        public int PercentageWorth { get; private set; }
        public DateTime PausedDatetime { get; private set; }
        public DateTime StartedDatetime { get; private set; }

        public AssignmentTask(
            string title, string description, Priority priority, Status status, 
            DateTime dueDatetime, DateTime createdDatetime, string subject, 
            int percentageWorth, DateTime startedDatetime, DateTime pausedDatetime
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            Subject = subject;
            PercentageWorth = percentageWorth;
            StartedDatetime = startedDatetime;
            PausedDatetime = pausedDatetime;
        }

        // More constructors will probably be needed

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
    }//end of Assignment Class
}
