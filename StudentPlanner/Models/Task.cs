using System;
using System.ComponentModel;

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
            set {
                _title = value;
                RaisePropertyChanged("Title");
                Toastr.Success("Updated", "The task title has been updated");
            }
        }
        public string Description {
            get { return _description; }
            set {
                _description = value;
                RaisePropertyChanged("Description");
                Toastr.Success("Updated", "The task description has been updated");
            }
        }
        public Priority Priority {
            get { return _priority; }
            set {
                _priority = value;
                RaisePropertyChanged("Priority");
                Toastr.Success("Updated", "The task priority has been updated");
            }
        }
        public Status Status {
            get { return _status; }
            set {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }
        public DateTime DueDatetime {
            get { return _dueDatetime; }
            set {
                _dueDatetime = value;
                RaisePropertyChanged("DueDatetime");
                RaisePropertyChanged("DueDateReadable");
                Toastr.Success("Updated", "The task due date has been updated");
            }
        }
        public DateTime CreatedDatetime {
            get { return _createdDatetime; }
            set { _createdDatetime = value; }
        }
        public DateTime CompleteDatetime {
            get { return _completeDatetime; }
            set {
                _completeDatetime = value;
                RaisePropertyChanged("CompleteDatetime");
            }
        }
        public bool IsComplete {
            get { return _isComplete; }
            set {
                _isComplete = value;
                RaisePropertyChanged("IsComplete");
            }
        }

        public string DueDateReadable { get {
                int daysDiff = ((TimeSpan)(DueDatetime - DateTime.Now)).Days;
                if (daysDiff > 0) return "Due in " + daysDiff + " days";
                else return "This task is " + (IsComplete ? "Complete": "Overdue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) {
            Database.SaveTasks();
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

        public void CompleteTask() {
            Status = Status.Complete;
            CompleteDatetime = DateTime.Now;
            IsComplete = true;
            Toastr.Success("Complete", "The task has been marked as complete");
        }

        public void CancelTask() {
            Status = Status.Cancelled;
            Toastr.Info("Cancelled", "The task has been cancelled");
        }

        public override string ToString() {
            return Title;
        }
    }
}
