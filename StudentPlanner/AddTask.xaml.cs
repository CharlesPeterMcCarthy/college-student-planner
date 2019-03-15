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
            string type = comboTaskType.SelectedItem.ToString();
            string title = tblkTitle.Text;
            string description = tblkDescription.Text;
            Priority priority = GetPriority();
            DateTime due = dueDate.SelectedDate.Value.Date;

            Models.Task newTask = CreateNewTask(type, title, description, priority, due);

            if (newTask != null) {
                int weekNumber = DateService.GetWeekNumber(newTask.DueDatetime);

                SaveNewTask(newTask, weekNumber);
            }
        }

        private Models.Task CreateNewTask(string type, string title, string description, Priority priority, DateTime due) {
            if (title.Length < 3) {
                Console.WriteLine("Title length is too short.");
                return null;
            }
            if (description.Length < 10) {
                Console.WriteLine("Description length is too short.");
                return null;
            }
            if (!DateService.DateAfterToday(due)) {
                Console.WriteLine("The due date must be in the future.");
                return null;
            }

            Models.Task newTask = null;
            
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
                    Console.WriteLine("Invalid task type.");
                    break;
            }

            if (newTask != null) tblkCreated.Visibility = Visibility.Visible;
            
            return newTask;
        }

        private Priority GetPriority() {
            string prioritycombo = comboPriority.SelectedItem.ToString();

            if (prioritycombo == "High") return Priority.High;
            else if (prioritycombo == "Medium") return Priority.Medium;
            else return Priority.Low;
        }

        private bool SaveNewTask(Models.Task newTask, int weekNumber) {
            if (newTask == null) {
                Console.WriteLine("Task is not defined");
                return false;
            }
            if (weekNumber < 1 || weekNumber > 52) {
                Console.WriteLine("Invalid week number");
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
    }
}
