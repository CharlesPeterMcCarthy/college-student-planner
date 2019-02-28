using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Notification {
        //properties
        public Task Task { get; private set; }
        public bool IsDismissed { get; private set; } = false;

        public Notification(Task task) {
            Task = task;
        }

        public void Show() {
            // To be implemented
        }

        public void Dismiss() {
            IsDismissed = true;
        }

    }//end of the notification class
}
