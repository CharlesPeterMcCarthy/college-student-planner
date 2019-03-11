using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentPlanner.Models;

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
            //check what has been selected 
            string selected = comboTaskType.SelectedItem.ToString();

            Assignment.Visibility = selected == "Assignment" ? Visibility.Visible : Visibility.Hidden;
            Event.Visibility = selected == "Event" ? Visibility.Visible : Visibility.Hidden;
            Exam.Visibility = selected == "Exam" ? Visibility.Visible : Visibility.Hidden;
            Payment.Visibility = selected == "Payment" ? Visibility.Visible : Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            CreateNewTask();
        }

        private void CreateNewTask() {
            string selected = comboTaskType.SelectedItem.ToString();

            string title = tblkTitle.Text;
            string description = tblkDescription.Text;
            Priority priority = GetPriority();
            DateTime due = dueDate.SelectedDate.Value.Date;
            DateTime now = DateTime.Now;

            if (DateService.DateAfterToday(due)) {
                Models.Task newTask = null;

                switch (selected) {
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
                }

                SaveNewTask(newTask);
                tblkCreated.Visibility = Visibility.Visible;
            }
        }

        private Priority GetPriority() {
            string prioritycombo = comboPriority.SelectedItem.ToString();

            if (prioritycombo == "High") return Priority.High;
            else if (prioritycombo == "Medium") return Priority.Medium;
            else return Priority.Low;
        }

        private void SaveNewTask(Models.Task newTask) {
            int weekNumber = DateService.GetWeekNumber(newTask.DueDatetime);
            Week week = FindWeek(weekNumber);

            if (week != null) {
                Day day = FindDay(week, newTask.DueDatetime.Date);

                if (day != null) day.AddTask(newTask);
                else {
                    Day newDay = CreateNewDay(newTask);
                    week.AddDay(newDay);
                }
            } else {
                week = CreateNewWeek(weekNumber);
                Day newDay = CreateNewDay(newTask);
                week.AddDay(newDay);

                Planner.AddWeek(week);
            }
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
    }
}
