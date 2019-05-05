using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace StudentPlanner {
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    /// 

    public partial class AddTask : Page {
        public Planner Planner { get; set; }

        public AddTask() {
            InitializeComponent();

            SetComboBoxSources();
        }

        public AddTask(Planner p) : this() {
            Planner = p;
        }

        private void SetComboBoxSources() {
            comboTaskType.ItemsSource = new string[] { "Assignment", "Event", "Exam", "Payment" };
            comboPriority.ItemsSource = Enum.GetNames(typeof(Priority));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string selected = comboTaskType.SelectedItem.ToString();

            Assignment.Visibility = selected == "Assignment" ? Visibility.Visible : Visibility.Collapsed;
            Event.Visibility = selected == "Event" ? Visibility.Visible : Visibility.Collapsed;
            Exam.Visibility = selected == "Exam" ? Visibility.Visible : Visibility.Collapsed;
            Payment.Visibility = selected == "Payment" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SaveTask(object sender, RoutedEventArgs e) {
            string type = "";
            Priority priority = Priority.Low;
            DateTime due = DateTime.Now;
            string title = tblkTitle.Text;
            string description = tblkDescription.Text;

            try {
                type = comboTaskType.SelectedItem.ToString();
                priority = GetPriority();
            } catch (NullReferenceException err) {
                Toastr.Warning("Warning", "Please choose an option in all dropdown menus");
                return;
            }

            try {
                due = dueDate.SelectedDate.Value.Date;
                due = due.Date + new TimeSpan(23, 59, 59);
            } catch (InvalidOperationException err) {
                Toastr.Warning("Warning", "Please select a valid date");
                return;
            }
            
            Task newTask = CreateNewTask(type, title, description, priority, due);

            if (newTask != null) {
                int weekNumber = DateService.GetWeekNumber(newTask.DueDatetime);

                SaveNewTask(newTask, weekNumber);
                NavigationService.Navigate(new MyPlanner());
            }
            else Toastr.Error("Error", "Failed to create new task");
        }

        private Task CreateNewTask(string type, string title, string description, Priority priority, DateTime due) {
            if (title.Length < 3) {
                Toastr.Warning("Warning", "Title length is too short");
                return null;
            }
            if (description.Length < 10) {
                Toastr.Warning("Warning", "Description length is too short.");
                return null;
            }
            if (!DateService.DateAfterToday(due)) {
                Toastr.Warning("Warning", "The due date must be in the future.");
                return null;
            }

            Task newTask = null;

            Toastr.TurnOffNotifications(); // Prevent multiple 'update' notifications

            DateTime now = DateTime.Now;

            switch (type) {
                case "Assignment":
                    string subject = tbxSubject.Text;
                    int percentage = int.Parse(tbxPercentage.Text);

                    newTask = new AssignmentTask(title, description, priority, due, now, subject, percentage);
                    break;
                case "Exam":
                    string subjectExam = tbxSubjectExam.Text;
                    string materials = tbxMaterials.Text;
                    int percentageExam = int.Parse(tbxPercentExam.Text);

                    newTask = new ExamTask(title, description, priority, due, now, subjectExam, percentageExam, new List<string>(materials.Split(',')));
                    break;
                case "Event":
                    string location = tbxLocation.Text;

                    newTask = new EventTask(title, description, priority, due, now, location);
                    break;
                case "Payment":
                    decimal amount = decimal.Parse(tbxAmount.Text);

                    newTask = new PaymentTask(title, description, priority, due, now, amount);
                    break;
                default:
                    Toastr.Error("Error", "Invalid task type.");
                    break;
            }

            Toastr.TurnOnNotifications();

            if (newTask != null) Toastr.Success("Created", "The '" + title + "' task has been created");
            
            return newTask;
        }

        private Priority GetPriority() {
            string prioritycombo = comboPriority.SelectedItem.ToString();

            if (prioritycombo == "High") return Priority.High;
            else if (prioritycombo == "Medium") return Priority.Medium;
            else return Priority.Low;
        }

        private bool SaveNewTask(Task newTask, int weekNumber) {
            if (newTask == null) {
                Toastr.Error("Error", "Task is not defined");
                return false;
            }
            if (weekNumber < 1 || weekNumber > 52) {
                Toastr.Error("Error", "Invalid week number");
                return false;
            }

            Week week = FindWeek(weekNumber);

            if (week != null) {
                Day day = FindDay(week, newTask.DueDatetime.Date);

                if (day != null) {
                    day.AddTask(newTask);
                } else {
                    Day newDay = CreateNewDay(newTask);
                    week.AddDay(newDay);
                }
            } else {
                week = CreateNewWeek(weekNumber);
                Day newDay = CreateNewDay(newTask);
                week.AddDay(newDay);

                Planner.AddWeek(week);
            }

            Database.SaveTasks();

            return true;
        }

        private Week FindWeek(int weekNumber) {
            return Planner.Weeks.Find(w => w.WeekNumber == weekNumber);
        }

        private Day FindDay(Week week, DateTime dt) {
            return week.Days.Find(d => d.Date.Date == dt);
        }

        private Day CreateNewDay(Models.Task newTask) {
            return new Day(newTask.DueDatetime.Date, new List<Models.Task>(new Models.Task[] { newTask }));
        }

        private Week CreateNewWeek(int weekNumber) {
            return new Week(weekNumber);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new MyPlanner());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
