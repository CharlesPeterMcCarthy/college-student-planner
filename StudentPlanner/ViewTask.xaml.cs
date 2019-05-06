using StudentPlanner.Interfaces;
using StudentPlanner.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
            taskInfo.Content = Task;

            UpdateButtonVisibility();
            SetComboBoxes();
            DisableComplete();
        }

        private void SetComboBoxes() {
            cbxPriority.ItemsSource = Enum.GetNames(typeof(Priority));
            cbxPriority.SelectedValue = Task.Priority.ToString();
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
            DisableComplete();
        }

        private void DisableComplete() {
            if (Task.Status == Status.Complete || Task.Status == Status.Cancelled) {
                tbxTitle.IsEnabled = false;
                tbxDescription.IsEnabled = false;
                dpDueDate.IsEnabled = false;
                cbxPriority.IsEnabled = false;
                taskInfo.IsEnabled = false;
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new MyPlanner());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
