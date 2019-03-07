using StudentPlanner.Interfaces;
using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ViewTask.xaml
    /// </summary>
    public partial class ViewTask : Page {

        public Task Task { get; private set; }

        public ViewTask() {
            InitializeComponent();
        }

        public ViewTask(Task task): this() {
            Task = task;
            taskGrid.DataContext = Task;
            content1.Content = Task;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Task.CompleteTask();
        }

        private void StartTask(object sender, RoutedEventArgs e) {
            ((IStartableTask)Task).StartTask();
        }

        private void PauseTask(object sender, RoutedEventArgs e) {
            ((IPausableTask)Task).PauseTask();
        }
    }
}
