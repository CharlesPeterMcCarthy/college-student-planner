using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class Planner {
        //properties
        public List<Week> Weeks { get; private set; } = new List<Week>();

        public Planner() { }

        public Planner(List<Week> weeks) {
            Weeks = weeks;
        }

        //methods
        public void AddWeek(Week week)
        {
            Weeks.Add(week);
        }//end of the AddWeek Method

    }//end of the Planner Class
}
