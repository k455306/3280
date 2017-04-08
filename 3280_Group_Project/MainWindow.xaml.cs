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

namespace _3280_Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //populate customer list
            //populate item list

        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            //Brings up search window.
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            //Commits invoice to the DB. 
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //Cancels current invoice and clears all fields.
        }
    }
}
