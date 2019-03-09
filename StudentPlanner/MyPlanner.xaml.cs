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

namespace StudentPlanner {
    /// <summary>
    /// Interaction logic for MyPlanner.xaml
    /// </summary>
    public partial class MyPlanner : Page {

        public Planner Planner { get; set; }

        public MyPlanner() {
            InitializeComponent();
        }

        public MyPlanner(Planner p): this() {
            Planner = p;

            DisplayThisWeeksTasks();
        }

        private void DisplayThisWeeksTasks() {
            monList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Monday).Tasks;
            tuesList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Tuesday).Tasks;
            wedList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Wednesday).Tasks;
            thurList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Thursday).Tasks;
            friList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Friday).Tasks;
            satList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Saturday).Tasks;
            sunList.ItemsSource = Planner.Weeks[0].Days.Find(d => d.DayOfWeek == DayOfWeek.Sunday).Tasks;
        }

        private void DayList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ViewTask vt = new ViewTask(((ListBox)sender).SelectedItem as Models.Task);
            NavigationService.Navigate(vt);
        }
    }
}
