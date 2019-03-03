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
        }
    }
}
