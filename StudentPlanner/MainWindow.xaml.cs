using StudentPlanner.Models;
using System.Windows;

namespace StudentPlanner
{
    public partial class MainWindow : Window
    {
        private User User { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) {
            User = Database.GetUser();

            Toastr.TurnOnNotifications();

            MyPlanner mp = new MyPlanner(User.Planner);

            SetheadingText("My Planner");
            mainFrame.NavigationService.Navigate(mp);
        }

        private void TblkPlanner_MouseDown(object sender, RoutedEventArgs e) {
            MyPlanner mp = new MyPlanner(User.Planner);

            SetheadingText("My Planner");
            mainFrame.NavigationService.Navigate(mp);
        }

        private void TblkAdd_MouseDown(object sender, RoutedEventArgs e) {
            AddTask at = new AddTask(User.Planner);

            SetheadingText("Add Task");
            mainFrame.NavigationService.Navigate(at);
        }

        private void SetheadingText(string heading) {
            tblkHeading.Text = heading;
        }
    }
}
