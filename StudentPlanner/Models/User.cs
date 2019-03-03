using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class User {

        //properties
        public string StudentID { get; private set; }
        public string Name { get; private set; }
        public DateTime DOB { get; private set; }
        public int Age { get; private set; }
        public Planner Planner { get; private set; }

        public User(string studentID, string name, DateTime dob, Planner planner) : this(studentID, name, dob) {
            Planner = planner;
        }

        public User(string studentID, string name, DateTime dob) {
            StudentID = studentID;
            Name = name;
            DOB = dob;

            SetAge();
        }

        private void SetAge() {
            DateTime today = DateTime.Today;
            Age = today.Year - DOB.Year;

            if (DOB > today.AddYears(-Age)) Age--;
        }

    }//end of the user class
}
