﻿using System;
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
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Priority Priority { get; private set; }
        private Status _status;
        public Status Status {
            get { return _status; }
            protected set {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }    // Protected set to allow child classes to update status
        public DateTime DueDatetime { get; private set; }
        public DateTime CreatedDatetime { get; private set; }
        public DateTime CompleteDatetime { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
