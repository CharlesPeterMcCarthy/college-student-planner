using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class User {

        //properties
        public string StudentID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Planner Planner { get; set; }

    }//end of the user class
}
