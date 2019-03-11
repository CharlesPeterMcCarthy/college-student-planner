using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class ExamTask : Task, IStartableTask {
        //properties
        public string Subject { get; private set; }
        public int PercentageWorth { get; private set; }
        public List<string> MaterialsNeeded { get; private set; }
        public DateTime StartedDatetime { get; private set; }
        public string Materials { get { return string.Join(", ", MaterialsNeeded); } }
        //referenced by the database
        public ExamTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, string subject,
            int percentageWorth, List<string> materialsNeeded
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            Subject = subject;
            PercentageWorth = percentageWorth;
            MaterialsNeeded = materialsNeeded;
        }
        //referenced by AddTask.xaml.cs
        public ExamTask(
            string title, string description, Priority priority,
            DateTime dueDatetime, DateTime createdDatetime, string subject,
            int percentageWorth, List<string> materialsNeeded
        ) : base(title, description, priority, dueDatetime, createdDatetime) {
            Subject = subject;
            PercentageWorth = percentageWorth;
            MaterialsNeeded = materialsNeeded;
        }

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
