using StudentPlanner.Models;
using StudentPlanner.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
                lblWeekNum2.Text = "Week\n#" + _weekNum;
            }
        }

        public MyPlanner() {
            InitializeComponent();

            Planner = User.Planner;

            WeekNum = DateService.GetWeekNumber(DateTime.Now);
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

        private ObservableCollection<Task> GetDayTasks(DayOfWeek day) {
            ObservableCollection<Task> t = (Planner.Weeks.Find(w => w.WeekNumber == WeekNum).Days.Find(d => d.DayOfWeek == day)).Tasks;
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

        private void AddTask_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new AddTask(Planner));
        }

        private void CompleteTask(object sender, RoutedEventArgs e) {
            GetClickedTask(sender).CompleteTask();
        }

        private void EditTask(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new ViewTask(GetClickedTask(sender)));
        }

        private void CancelTask(object sender, RoutedEventArgs e) {
            GetClickedTask(sender).CancelTask();
        }

        private Task GetClickedTask(object elem) {
            ListBox listBox = Dependencies.GetParentOfType<ListBox>(elem as UIElement);
            Task t = ((ListBoxItem)listBox.ContainerFromElement((Button)elem)).Content as Task;
            return t;
        }

    }
}
