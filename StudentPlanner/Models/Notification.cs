using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Notification {
        //properties
        public Task Task { get; private set; }
        public bool IsDismissed { get; private set; }

    }//end of the notification class
}
