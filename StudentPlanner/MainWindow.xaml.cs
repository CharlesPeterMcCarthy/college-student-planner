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
            Database db = new Database();
            User = db.GetUser();

            MyPlanner mp = new MyPlanner(User.Planner);

            SetheadingText("My Planner");
            mainFrame.NavigationService.Navigate(mp);
        }

        private void TblkPlanner_MouseDown(object sender, MouseButtonEventArgs e) {
            MyPlanner mp = new MyPlanner(User.Planner);

            SetheadingText("My Planner");
            mainFrame.NavigationService.Navigate(mp);
        }

        private void TblkAdd_MouseDown(object sender, MouseButtonEventArgs e) {
            AddTask at = new AddTask(User.Planner);

            SetheadingText("Add Task");
            mainFrame.NavigationService.Navigate(at);
        }

        private void SetheadingText(string heading) {
            tblkHeading.Text = heading;
        }
    }
}
