using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class Planner {
        //properties
        public List<Week> Weeks { get; private set; }

        //methods
        public void AddWeek( Week week )
        {
            Weeks.Add(week);
        }//end of the AddWeek Method

    }//end of the Planner Class
}
