using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {

    public enum Priority {
         High,
         Medium,
         Low
    }

    public enum Status {
        NotStarted,
        Started,
        Paused,
        Complete,
        Cancelled
    }

    public abstract class Task: INotifyPropertyChanged {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        private Status _status;
        public Status Status {
            get { return _status; }
            set {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }
        public DateTime DueDatetime { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime CompleteDatetime { get; set; }
        public string DueDateReadable { get { return DueDatetime.ToShortDateString(); } }
        public bool IsComplete { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Task() { }

        public Task(
            string title, string description, Priority priority,
            Status status, DateTime dueDatetime, DateTime createdDatetime
        ) : this(title, description, priority, dueDatetime, createdDatetime) {
            Status = status;
        }
        
        public Task(string title, string description, Priority priority, DateTime dueDatetime, DateTime createdDatetime) {
            Title = title;
            Description = description;
            Priority = priority;
            DueDatetime = dueDatetime;
            CreatedDatetime = createdDatetime;

            Status = Status.NotStarted;
        }

        public void UpdatePriority(Priority priority) {
            Priority = priority;
        }

        public Status CompleteTask() {
            Status = Status.Complete;
            CompleteDatetime = DateTime.Now;
            
            return Status;
        }

        public Status CancelTask() {
            Status = Status.Cancelled;
            return Status;
        }

        public void UpdateDueDatetime(DateTime dt) {
            DueDatetime = dt;
        }

        public override string ToString() {
            return Title;
        }
    }
}
