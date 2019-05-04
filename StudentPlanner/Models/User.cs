using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public static class User {

        public static string StudentID { get; set; }
        public static string Name { get; set; }
        public static DateTime DOB { get; set; }
        public static int Age {
            get {
                DateTime today = DateTime.Today;
                int age = today.Year - DOB.Year;
                if (DOB > today.AddYears(-Age)) age--;
                return age;
            }
        }

        public static Planner Planner { get; set; }

    }
}
