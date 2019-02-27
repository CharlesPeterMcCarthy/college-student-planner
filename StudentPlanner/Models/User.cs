using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class User {

        //properties
        public string StudentID { get; private set; }
        public string Name { get; private set; }
        public DateTime DOB { get; private set; }
        public Planner Planner { get; private set; }

        public User(string studentID, string name, DateTime dob, Planner planner) : this(studentID, name, dob) {
            Planner = planner;
        }

        public User(string studentID, string name, DateTime dob) {
            StudentID = studentID;
            Name = name;
            DOB = dob;
        }

    }//end of the user class
}
