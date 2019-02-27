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

        //methods
        public int GetAge(DateTime DOB)
        {
            int age=0;
            DateTime Now = DateTime.Now;
            age = Now.Year - DOB.Year;
            if (DOB.Month > Now.Month)
            {
                age = Now.Year - DOB.Year;
                age -= 1;
                return age;
            }
            else
            {
                if (DOB.Day < Now.Day)
                {
                    age = Now.Year - DOB.Year;
                    return age;
                }
                else
                {
                    age = Now.Year - DOB.Year;
                    age -= 1;
                    return age;
                }

            }

        }

    }//end of the user class
}
