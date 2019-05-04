using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Interfaces {
    interface IStartableTask {
        DateTime StartedDatetime { get; }

        void StartTask();
    }
}
