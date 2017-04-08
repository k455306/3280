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
        /// <summary>
        /// Search window object
        /// </summary>
        SearchItemWindow sw; 

        public MainWindow()
        {
            InitializeComponent();
            ///Initialize the search Window
            
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            sw = new SearchItemWindow();
            sw.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
