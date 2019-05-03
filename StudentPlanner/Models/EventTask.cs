using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class EventTask : Task, IStartableTask, IPausableTask {
        //properties
        public string Location { get; set; }
        public DateTime StartedDatetime { get; set; }
        public DateTime PausedDatetime { get; set; }
        //referenced by the database
        public EventTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, string location
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            Location = location;
        }
        //referenced by AddTask.xaml.cs
        public EventTask(
            string title, string description, Priority priority,
            DateTime dueDatetime, DateTime createdDatetime, string location
        ) : base(title, description, priority, dueDatetime, createdDatetime)
        {
            Location = location;
        }

        // More constructors will probably be needed

        //methods
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

        public void UpdateLocation(string location)
        {
            Location = location;
        }//end of update location methods

    }//end of event class
}
