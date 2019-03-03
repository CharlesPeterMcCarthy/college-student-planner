using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner {
    class Database {
        
        public User GetUser() {
            Models.Task t1 = new ExamTask("Maths Exam", "January exam for Maths", Priority.High, Status.NotStarted,
                new DateTime(2019, 1, 1, 9, 0, 0), new DateTime(2018, 12, 8), new List<string>(new string[] { "Calculator", "Pens" }));
            Models.Task t2 = new ExamTask("Programming Exam", "January exam for Programming - Open book", Priority.Medium, Status.NotStarted,
                new DateTime(2019, 1, 2, 13, 0, 0), new DateTime(2018, 12, 8), new List<string>(new string[] { "Pen", "Paper", "Notes" }));
            Models.Task t3 = new ExamTask("Web Exam", "Open book Angular web exam", Priority.High, Status.NotStarted,
                new DateTime(2019, 1, 10, 9, 0, 0), new DateTime(2018, 12, 9), new List<string>(new string[] { "Notes" }));

            Models.Task t4 = new PaymentTask("Semester Payment", "Pay the fees for this semester", Priority.High, Status.NotStarted,
                new DateTime(2019, 1, 10, 22, 0, 0), new DateTime(2018, 9, 1), 1500);
            Models.Task t5 = new PaymentTask("Rent", "Pay rent for the month of January", Priority.Medium, Status.Complete,
                new DateTime(2019, 1, 1, 15, 0, 0), new DateTime(2018, 12, 24), 400);

            Models.Task t6 = new AssignmentTask("Software Project", "Software assignment on whatever topic", Priority.Medium, Status.Started,
                new DateTime(2019, 1, 13, 21, 30, 0), new DateTime(2018, 11, 13), "Software Engineering", 30, new DateTime(2019, 1, 6, 16, 34, 29));
            Models.Task t7 = new AssignmentTask("Database CA", "CA for database - Not worth too much", Priority.Low, Status.Paused,
                new DateTime(2019, 1, 10, 13, 0, 0), new DateTime(2018, 11, 28), "Database", 5, new DateTime(2019, 1, 6, 16, 34, 29));

            Models.Task t8 = new EventTask("Clubs & Socs Day", "Clubs and societies day in the main hall", Priority.Low, Status.NotStarted,
               new DateTime(2019, 1, 10, 9, 30, 0), new DateTime(2018, 12, 29), "College Main Hall");
            Models.Task t9 = new EventTask("Relax", "Take a day off and relax for once", Priority.High, Status.Cancelled,
               new DateTime(2019, 1, 4, 9, 0, 0), new DateTime(2018, 12, 27), "Home");

            Day w1d1 = new Day(new DateTime(2019, 1, 1), new List<Models.Task>(new Models.Task[] { t1, t5 }));
            Day w1d2 = new Day(new DateTime(2019, 1, 2), new List<Models.Task>(new Models.Task[] { t2 }));
            Day w1d3 = new Day(new DateTime(2019, 1, 4), new List<Models.Task>(new Models.Task[] { t9 }));
             
            Day w2d1 = new Day(new DateTime(2019, 1, 10), new List<Models.Task>(new Models.Task[] { t3, t4, t7, t8 }));
            Day w2d2 = new Day(new DateTime(2019, 1, 13), new List<Models.Task>(new Models.Task[] { t6 }));

            Week w1 = new Week(1, new DateTime(2019, 1, 1), new DateTime(2019, 1, 7), new List<Day>(new Day[] { w1d1, w1d2, w1d3}));
            Week w2 = new Week(2, new DateTime(2019, 1, 8), new DateTime(2019, 1, 14), new List<Day>(new Day[] { w2d1, w2d2 }));

            Planner p = new Planner(new List<Week>(new Week[] { w1, w2 }));

            User u = new User("S00123456", "John", new DateTime(1998, 1, 12), p);

            return u;
        }

    }
}
