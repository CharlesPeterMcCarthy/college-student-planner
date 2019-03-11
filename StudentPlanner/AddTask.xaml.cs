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
        public AddTask() {
            InitializeComponent();

            SetComboBoxSources();
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

            string title = tblkTitle.ToString();
            string description = tblkDescription.ToString();
            string prioritycombo = comboPriority.SelectedItem.ToString();
            Priority priority = 0;
            DateTime due = dueDate.DisplayDate;

            if (prioritycombo == "High")
            {
                priority = Priority.High;
            }
            else if (prioritycombo == "Medium")
            {
                priority = Priority.Medium;
            }
            else if (prioritycombo == "low")
            {
                priority = Priority.Low;
            }

            switch (selected)
            {
                case "Assignment":
                    string subject = tbxSubject.ToString();
                    int percentage = int.Parse(tbxPercentage.ToString());
                    Models.Task tAssignment = new AssignmentTask(title, description, priority, Status.Paused, due, due, subject, percentage, due  );
                    //note to charles
                    //status is not in xaml -- so i have hard coded this for the minute
                    //and created, started date have been entered as the due date taken in at the start for the meantime                                                           
                    break;
                case "Exam":
                    string subjectExam = tbxSubjectExam.ToString();
                    string materials = tbxMaterials.ToString();
                    int percentageExam = int.Parse(tbxPercentExam.ToString());
                    Models.Task tExam = new ExamTask(title, description, priority, Status.Paused, due, due, subjectExam, percentageExam, new List<string>(new string[] { "Pen", "Paper", "Notes" }));
                    //status and dates again are same as the due date
                    //not sure how to bring in a list from a textbox. so used dummy data from the database
                    break;
                case "Event":
                    string location = tbxLocation.ToString();
                    Models.Task tEvent = new EventTask(title, description, priority, Status.Paused, due, due, location, due, due);
                    //used the due date for any dates in the constructor
                    break;
                case "Payment":
                    decimal amount = decimal.Parse(tbxAmount.ToString());
                    Models.Task tPayment = new PaymentTask(title, description, priority, Status.Paused, due, due, amount);
                    //used due date for created date time
                    break;
                default:
                break;
            }


            



        }
    }
}
