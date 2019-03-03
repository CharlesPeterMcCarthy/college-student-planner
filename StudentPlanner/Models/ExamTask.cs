using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class ExamTask : Task, IStartableTask {
        //properties
        public List<string> MaterialsNeeded { get; private set; }
        public DateTime StartedDatetime { get; private set; }

        public ExamTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, 
            List<string> materialsNeeded, DateTime startedDatetime
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            MaterialsNeeded = materialsNeeded;
            StartedDatetime = startedDatetime;
        }

        public ExamTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, List<string> materialsNeeded
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            MaterialsNeeded = materialsNeeded;
        }

        // More constructors will probably be needed

        //methods
        public Status StartTask() {
            Status = Status.Started;
            StartedDatetime = DateTime.Now;

            return Status;
        }

        public void AddMaterial(string material)
        {
            MaterialsNeeded.Add(material);
        }//end of add materials method
    }//end of exam class
}
