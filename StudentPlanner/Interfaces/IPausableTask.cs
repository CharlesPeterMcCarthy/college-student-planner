using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Interfaces {
    interface IPausableTask {
        DateTime PausedDatetime { get; }

        void PauseTask();
    }
}
