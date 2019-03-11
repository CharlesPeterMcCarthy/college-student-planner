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

        public AddTask(Planner p) : this()
        {
            Planner = p;
        }

        private void SetComboBoxSources() {
            comboTaskType.ItemsSource = new string[] { "Assignment", "Event", "Exam", "Payment" };
            comboPriority.ItemsSource = Enum.GetNames(typeof(Priority));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check what has been selected 
            string selected = comboTaskType.SelectedItem.ToString();

            Assignment.Visibility = selected == "Assignment" ? Visibility.Visible : Visibility.Hidden;
            Event.Visibility = selected == "Event" ? Visibility.Visible : Visibility.Hidden;
            Exam.Visibility = selected == "Exam" ? Visibility.Visible : Visibility.Hidden;
            Payment.Visibility = selected == "Payment" ? Visibility.Visible : Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selected = comboTaskType.SelectedItem.ToString();

            string title = tblkTitle.Text;
            string description = tblkDescription.Text;
            string prioritycombo = comboPriority.SelectedItem.ToString();
            Priority priority;
            DateTime due = dueDate.SelectedDate.Value.Date;
            Console.WriteLine(due);

            Console.WriteLine("test");

            if (DateService.DateAfterToday(due))
            {
                if (prioritycombo == "High") priority = Priority.High;
                else if (prioritycombo == "Medium") priority = Priority.Medium;
                else priority = Priority.Low;

                Models.Task newTask = null;

                switch (selected)
                {
                    case "Assignment":
                        string subject = tbxSubject.Text;
                        int percentage = int.Parse(tbxPercentage.Text);
                        newTask = new AssignmentTask(title, description, priority, due, DateTime.Now, subject, percentage);
                        break;
                    case "Exam":
                        string subjectExam = tbxSubjectExam.Text;
                        string materials = tbxMaterials.Text;
                        int percentageExam = int.Parse(tbxPercentExam.Text);
                        newTask = new ExamTask(title, description, priority, due, DateTime.Now, subjectExam, percentageExam, new List<string>(materials.Split(',')));
                        break;
                    case "Event":
                        string location = tbxLocation.Text;
                        newTask = new EventTask(title, description, priority, due, DateTime.Now, location);
                        break;
                    case "Payment":
                        decimal amount = decimal.Parse(tbxAmount.Text);
                        newTask = new PaymentTask(title, description, priority, due, DateTime.Now, amount);
                        break;
                        
                }

                int weekNumber = DateService.GetWeekNumber(due);
                Console.WriteLine("week " + weekNumber);
                Week week = Planner.Weeks.Find(w => w.WeekNumber == weekNumber);
                if (week != null)
                {
                    Day day = week.Days.Find(d => d.Date.Date == newTask.DueDatetime.Date);

                    if (day != null)
                    {
                        Console.WriteLine("Nothing new - add task");
                        day.Tasks.Add(newTask);
                    } else
                    {
                        Console.WriteLine("New day 1");
                        Day newDay = new Day(newTask.DueDatetime.Date, new List<Models.Task>(new Models.Task[] { newTask }));
                        week.AddDay(newDay);
                    }
                } else
                {
                    Console.WriteLine("New week");
                    Week newWeek = new Week(weekNumber, DateTime.Now, DateTime.Now);

                    Console.WriteLine("New day 2");
                    Day newDay = new Day(newTask.DueDatetime.Date, new List<Models.Task>(new Models.Task[] { newTask }));
                    newWeek.AddDay(newDay);

                    Planner.AddWeek(newWeek);
                }
            }
        }
    }
}
