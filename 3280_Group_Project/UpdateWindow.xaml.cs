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
using System.Windows.Shapes;

namespace _3280_Group_Project
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        /// <summary>
        /// Initialization which also poplulates the DataGrid with all the Items.
        /// </summary>
        public UpdateWindow()
        {
            InitializeComponent();
            //Call to InvoiceRepository.getAllItems() which will return a list of Invoice Items that can then be inserted into the DataGrid
        }

        /// <summary>
        /// When user clicks on the close window ('X') this ensures that is doesn't close the window, but rather, hides it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// Closes the Update Window, which takes the user back to MainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Adds a new item to the database with the fields the user has entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //Call to the InvoiceRepository.AddItem method
        }

        /// <summary>
        /// Updates all the textboxes with othe information found in the selected Item object 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            //Call to the InvoiceRepository.UpdateItem method
        }
    }
}
