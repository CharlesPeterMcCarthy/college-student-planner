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
        private string _title;
        private string _description;
        private Priority _priority;
        private Status _status;
        private DateTime _dueDatetime;
        private DateTime _createdDatetime;
        private DateTime _completeDatetime;
        private bool _isComplete;


        public string Title {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("Title"); }
        }
        public string Description {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }
        public Priority Priority {
            get { return _priority; }
            set { _priority = value; RaisePropertyChanged("Priority"); }
        }
        public Status Status {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("Status"); }
        }
        public DateTime DueDatetime {
            get { return _dueDatetime; }
            set { _dueDatetime = value; RaisePropertyChanged("DueDatetime"); RaisePropertyChanged("DueDateReadable"); }
        }
        public DateTime CreatedDatetime {
            get { return _createdDatetime; }
            set { _createdDatetime = value; RaisePropertyChanged("CreatedDatetime"); }
        }
        public DateTime CompleteDatetime {
            get { return _completeDatetime; }
            set { _completeDatetime = value; RaisePropertyChanged("CompleteDatetime"); }
        }
        public bool IsComplete {
            get { return _isComplete; }
            set { _isComplete = value; RaisePropertyChanged("IsComplete"); }
        }

        public string DueDateReadable { get { return DueDatetime.ToShortDateString(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName) {
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
