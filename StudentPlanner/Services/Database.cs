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

        private const string TASKS_FILE = "../../tasks.json";
        private const string USER_FILE = "../../user.json";
        private static bool canSave = false;

        public static void TurnOnSaving() {
            canSave = true;
        }

        public static void GetDatabaseConent() {
            GetUser();
            List<Task> tasks = GetTasks();
            List<Week> weeks = SortTasks(tasks);

            User.Planner = new Planner(weeks);
        }

        private static void GetUser() {
            using (StreamReader sr = new StreamReader(USER_FILE)) {
                string json = sr.ReadToEnd();

                var user = JsonConvert.DeserializeObject<dynamic>(json);

                User.StudentID = user.StudentID;
                User.Name = user.Name;
                User.DOB = user.DOB;
            }
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

            using (StreamReader sr = new StreamReader(TASKS_FILE)) {
                string json = sr.ReadToEnd();

                if (json.Length > 0) tasks = JsonConvert.DeserializeObject<List<Task>>(json, new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }

            return tasks;
        }

        public static void SaveTasks() {
            if (!canSave) return;
            List<Task> tasks = new List<Task>();
            List<Week> weeks = User.Planner.Weeks;

            foreach (Week w in weeks) {
                foreach(Day d in w.Days) {
                    tasks.AddRange(d.Tasks);
                }
            }

            using (StreamWriter sw = File.CreateText(TASKS_FILE)) {
                sw.Write(JsonConvert.SerializeObject(tasks, Formatting.Indented, new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Auto
                }));
            }
        }

        public static void DeleteTask(Task t) {
            int weekNum = DateService.GetWeekNumber(t.DueDatetime);
            User.Planner.Weeks.Find(w => w.WeekNumber == weekNum).Days.Find(d => d.Date.Date == t.DueDatetime.Date).Tasks.Remove(t);
            SaveTasks();
        }
    }
}
