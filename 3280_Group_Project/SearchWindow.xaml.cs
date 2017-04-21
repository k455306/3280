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
using System.Data;

namespace _3280_Group_Project
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        InvoiceRepository myInvoices;
        DataTable dt_Results;

        /// <summary>
        /// Initialization which also poplulates the DataGrid with all the invoices.
        /// </summary>
        public SearchWindow()
        {
            InitializeComponent();
            //Call to getAllInvoices() which will return a list of Invoice Items that can then be inserted into the DataGrid
            myInvoices = new InvoiceRepository();
            dt_Results = new DataTable();

            dt_Results = myInvoices.getAllInvoicesDT();
            dg_InvoiceSearch.DataContext = dt_Results.DefaultView;
        }

        /// <summary>
        /// When user clicks on the close window ('X') this ensures that is doesn't close the window, but rather, hides it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// Selects the currently highlighted row in the DataGrid and sends the selected Invoice object back to MainWindow. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            // Will call InvoiceRepository.SelectSingleInvoice method
            // Pass Invoice object back to MainWindow

            //Currently just closes the window
            this.Hide();
        }

        /// <summary>
        /// Closes the search window, which takes the user back to MainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// When item is selected, will filter the DataGrid to to only show the criteria selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_InvoiceSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// When DatePicker has selected a date, it calls method to filter based on date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_InvoiceDateSelect_CalendarClosed(object sender, RoutedEventArgs e)
        {
            updateDataGridDate();
        }

        /// <summary>
        /// When item is selected, will filter the DataGrid to to only show the criteria selected based on Date
        /// </summary>
        private void updateDataGridDate()
        {
            //Method call that will request a
        }
    }
}
