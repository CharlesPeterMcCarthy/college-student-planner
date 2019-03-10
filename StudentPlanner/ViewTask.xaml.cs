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
            btnStart.Content = Task;
            btnPause.Content = Task;

            ButtonVisibility();
        }

        private void ButtonVisibility() {
            completeButton.Visibility = Task.Status == Status.Complete ? Visibility.Hidden : Visibility.Visible;
            btnStart.Visibility = Task.Status == Status.Complete || Task.Status == Status.Started ? Visibility.Hidden : Visibility.Visible;
            btnPause.Visibility = Task.Status == Status.Complete || Task.Status == Status.Paused ? Visibility.Hidden : Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Task.CompleteTask();
            ButtonVisibility();
        }

        private void StartTask(object sender, RoutedEventArgs e) {
            if (Task is IStartableTask) ((IStartableTask) Task).StartTask();
            ButtonVisibility();
        }

        private void PauseTask(object sender, RoutedEventArgs e) {
            if (Task is IPausableTask) ((IPausableTask) Task).PauseTask();
            ButtonVisibility();
        }
    }
}
