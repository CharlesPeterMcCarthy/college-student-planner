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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TblkPlanner_MouseDown(object sender, MouseButtonEventArgs e) {
            mainFrame.NavigationService.Navigate(new Uri("MyPLanner.xaml", UriKind.Relative));
        }

        private void TblkAdd_MouseDown(object sender, MouseButtonEventArgs e) {
            mainFrame.NavigationService.Navigate(new Uri("AddTask.xaml", UriKind.Relative));
        }
    }
}
