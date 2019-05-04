using StudentPlanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class EventTask : Task, IStartableTask, IPausableTask {

        private string _location;
        private DateTime _startedDatetime;
        private DateTime _pausedDatetime;

        public string Location {
            get { return _location; }
            set {
                _location = value;
                RaisePropertyChanged("Location");
                Toastr.Success("Updated", "The event location has been updated");
            }
        }
        public DateTime PausedDatetime {
            get { return _pausedDatetime; }
            set {
                _pausedDatetime = value;
                RaisePropertyChanged("PausedDatetime");
            }
        }
        public DateTime StartedDatetime {
            get { return _startedDatetime; }
            set {
                _startedDatetime = value;
                RaisePropertyChanged("StartedDatetime");
            }
        }

        public EventTask() { }

        public EventTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, string location
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            Location = location;
        }

        public EventTask(
            string title, string description, Priority priority,
            DateTime dueDatetime, DateTime createdDatetime, string location
        ) : base(title, description, priority, dueDatetime, createdDatetime) {
            Location = location;
        }

        public void PauseTask() {
            Status = Status.Paused;
            PausedDatetime = DateTime.Now;
            Toastr.Info("Paused", "The '" + Title + "' task has been paused");
        }

        public void StartTask() {
            Status = Status.Started;
            StartedDatetime = DateTime.Now;
            Toastr.Info("Started", "The '" + Title + "' task has been started");
        }

    }
}
