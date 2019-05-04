using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;

namespace StudentPlanner {

    class Database {

        private const string FILE = "database.json";

        public static User GetUser() {
            List<Task> tasks = GetTasks();
            List<Week> weeks = SortTasks(tasks);

            User u = new User("S00123456", "John", new DateTime(1998, 1, 12), new Planner(weeks));
            return u;
        }

        private static List<Week> SortTasks(List<Task> tasks) {
            List<Day> days = new List<Day>();
            List<Week> weeks = new List<Week>();

            foreach (Task t in tasks) {
                Day matchingDay = days.Find(d => d.Date.Date == t.DueDatetime.Date);
                if (matchingDay == null) days.Add(new Day(t.DueDatetime.Date, new List<Task>(new Task[] { t })));
                else matchingDay.AddTask(t);
            }

            foreach (Day d in days) {
                int weekNum = DateService.GetWeekNumber(d.Date);
                Week matchingWeek = weeks.Find(w => w.WeekNumber == weekNum);
                if (matchingWeek == null) weeks.Add(new Week(weekNum, new List<Day>(new Day[] { d })));
                else matchingWeek.AddDay(d);
            }

            return weeks;
        }

        private static List<Task> GetTasks() {
            List<Task> tasks = new List<Task>();

            using (StreamReader sr = new StreamReader(FILE)) {
                string json = sr.ReadToEnd();

                if (json.Length > 0) tasks = JsonConvert.DeserializeObject<List<Task>>(json, new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }

            return tasks;
        }

        public static void SaveTasks(List<Task> tasks) {
            using (StreamWriter sw = File.CreateText(FILE)) {
                sw.Write(JsonConvert.SerializeObject(tasks, Formatting.Indented, new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Auto
                }));
            }
        }
    }
}
