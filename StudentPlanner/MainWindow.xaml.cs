using StudentPlanner.Models;
using System.ComponentModel;
using System.Windows;

namespace StudentPlanner {
    public partial class MainWindow : Window {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) {
            Database.GetDatabaseConent();

            Toastr.TurnOnNotifications();
            Database.TurnOnSaving();

            MyPlanner mp = new MyPlanner();

            SetheadingText("My Planner");
            mainFrame.NavigationService.Navigate(mp);
        }

        private void TblkPlanner_MouseDown(object sender, RoutedEventArgs e) {
            MyPlanner mp = new MyPlanner();

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
