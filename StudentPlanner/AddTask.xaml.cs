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
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Page {
        public AddTask() {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check what has been selected 
            Console.WriteLine("Changed Selection");
            string selected = ComboBox.SelectedValueProperty.ToString();

            if (selected == "Assignment")
            {
                Assignment.Visibility = Visibility.Visible;
                Event.Visibility = Visibility.Hidden;
                Exam.Visibility = Visibility.Hidden;
                Payment.Visibility = Visibility.Hidden;
            }
            else if (selected == "Event")
            {
                Event.Visibility = Visibility.Visible;
                Assignment.Visibility = Visibility.Hidden;
                Exam.Visibility = Visibility.Hidden;
                Payment.Visibility = Visibility.Hidden;
            }
            else if (selected == "Exam")
            {
                Exam.Visibility = Visibility.Visible;
                Assignment.Visibility = Visibility.Hidden;
                Event.Visibility = Visibility.Hidden;
                Payment.Visibility = Visibility.Hidden;
            }
            else if (selected == "Payment")
            {
                Payment.Visibility = Visibility.Visible;
                Event.Visibility = Visibility.Hidden;
                Exam.Visibility = Visibility.Hidden;
                Assignment.Visibility = Visibility.Hidden;
            }
            else
            {

            }
        }
    }
}
