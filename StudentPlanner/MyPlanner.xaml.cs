using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentPlanner {
    /// <summary>
    /// Interaction logic for MyPlanner.xaml
    /// </summary>
    public partial class MyPlanner : Page {

        public Planner Planner { get; set; }
        private int _weekNum;
        public int WeekNum {
            get {
                return _weekNum;
            }
            private set {
                if (value > 52) value = 1;
                if (value < 1) value = 52;
                _weekNum = value;
                lblWeekNum.Text = "Week\n#" + _weekNum;
            }
        }

        public MyPlanner() {
            InitializeComponent();
        }

        public MyPlanner(Planner p): this() {
            Planner = p;

            WeekNum = Planner.Weeks[0].WeekNumber;
            DisplayThisWeeksTasks();
        }

        private void DisplayThisWeeksTasks() {
            monList.ItemsSource = null;
            tuesList.ItemsSource = null;
            wedList.ItemsSource = null;
            thurList.ItemsSource = null;
            friList.ItemsSource = null;
            satList.ItemsSource = null;
            sunList.ItemsSource = null;

            Console.WriteLine(WeekNum);
            if (WeekExists()) {
                if (DayExists(DayOfWeek.Monday)) monList.ItemsSource = GetDayTasks(DayOfWeek.Monday);
                if (DayExists(DayOfWeek.Tuesday)) tuesList.ItemsSource = GetDayTasks(DayOfWeek.Tuesday);
                if (DayExists(DayOfWeek.Wednesday)) wedList.ItemsSource = GetDayTasks(DayOfWeek.Wednesday);
                if (DayExists(DayOfWeek.Thursday)) thurList.ItemsSource = GetDayTasks(DayOfWeek.Thursday);
                if (DayExists(DayOfWeek.Friday)) friList.ItemsSource = GetDayTasks(DayOfWeek.Friday);
                if (DayExists(DayOfWeek.Saturday)) satList.ItemsSource = GetDayTasks(DayOfWeek.Saturday);
                if (DayExists(DayOfWeek.Sunday)) sunList.ItemsSource = GetDayTasks(DayOfWeek.Sunday);
            }
        }

        private bool WeekExists() {
            return (Planner.Weeks.Find(w => w.WeekNumber == WeekNum) != null);
        }

        private bool DayExists(DayOfWeek day) {
            return (Planner.Weeks.Find(w => w.WeekNumber == WeekNum).Days.Find(d => d.DayOfWeek == day) != null);
        }

        private ObservableCollection<Models.Task> GetDayTasks(DayOfWeek day) {
            ObservableCollection<Models.Task> t = (Planner.Weeks.Find(w => w.WeekNumber == WeekNum).Days.Find(d => d.DayOfWeek == day)).Tasks;
            Console.WriteLine(t);
            return t;
        }

        private void DayList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ViewTask vt = new ViewTask(((ListBox)sender).SelectedItem as Models.Task);
            NavigationService.Navigate(vt);
        }

        private void BtnWeekBack_Click(object sender, RoutedEventArgs e) {
            WeekNum--;
            DisplayThisWeeksTasks();
        }

        private void BtnWeekForward_Click(object sender, RoutedEventArgs e) {
            WeekNum++;
            DisplayThisWeeksTasks();
        }
    }
}
