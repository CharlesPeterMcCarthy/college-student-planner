using StudentPlanner.Interfaces;
using StudentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            SetComboBoxes();
        }

        public ViewTask(Task task): this() {
            Task = task;
            taskGrid.DataContext = Task;
            btnStart.Content = Task;
            btnPause.Content = Task;
            taskInfo.Content = Task;

            UpdateButtonVisibility();
        }

        private void SetComboBoxes() {
            cbxPriority.ItemsSource = Enum.GetNames(typeof(Priority));
        }

        private void UpdateButtonVisibility() {
            completeButton.Visibility = Task.Status == Status.Complete ? Visibility.Hidden : Visibility.Visible;
            btnStart.Visibility = Task.Status == Status.Complete || Task.Status == Status.Started ? Visibility.Hidden : Visibility.Visible;
            btnPause.Visibility = Task.Status == Status.Started ? Visibility.Visible : Visibility.Hidden;
        }

        private void StartTask(object sender, RoutedEventArgs e) {
            if (Task is IStartableTask) {
                ((IStartableTask) Task).StartTask();
                UpdateButtonVisibility();
            }
        }

        private void PauseTask(object sender, RoutedEventArgs e) {
            if (Task is IPausableTask) {
                ((IPausableTask) Task).PauseTask();
                UpdateButtonVisibility();
            }
        }

        private void CompleteTask(object sender, RoutedEventArgs e) {
            Task.CompleteTask();
            UpdateButtonVisibility();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new MyPlanner());
        }
    }
}
