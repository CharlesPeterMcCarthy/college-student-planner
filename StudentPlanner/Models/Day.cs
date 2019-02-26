using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Day {

        //properties
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public Task[] Tasks { get; set; }

    }//end of the Day Class
}
