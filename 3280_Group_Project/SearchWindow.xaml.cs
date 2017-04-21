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
        List<Invoice> invoiceList;
        Invoice selectedInvoice;
        static int TempSelect = 0;
        MainWindow MainAccess;

        /// <summary>
        /// Initialization which also poplulates the DataGrid with all the invoices.
        /// </summary>
        public SearchWindow()
        {
            InitializeComponent();
            //Call to getAllInvoices() which will return a list of Invoice Items that can then be inserted into the DataGrid
            myInvoices = new InvoiceRepository();
            dt_Results = new DataTable();
            invoiceList = new List<Invoice>();
            selectedInvoice = new Invoice();
           
            newSearch();
        }

        private void newSearch()
        {
            dt_Results = myInvoices.getAllInvoicesDT();
            dg_InvoiceSearch.DataContext = dt_Results.DefaultView;
            invoiceList = myInvoices.getAllInvoices();
            updateCombos();
        }

        private void updateCombos()
        {
            UpdateInvoiceCombo();
            UpdateInvoiceTotals();
        }



        private void UpdateInvoiceCombo()
        {
            cb_InvoiceSelect.Items.Clear();

                for (int i = 0; i < invoiceList.Count; i++)
                {
                    cb_InvoiceSelect.Items.Add(invoiceList[i].InvoiceID);
                }
        }

        private void UpdateInvoiceTotals()
        {
            cb_ChargeSelect.Items.Clear();

            foreach (Invoice X in invoiceList)
            {
                if (myInvoices.GetItemCount(X) > 0)
                {
                    decimal y = myInvoices.GetGrandTotal(X);
                    cb_ChargeSelect.Items.Add(string.Format("{0:0.00}", y.ToString()));
                }
            }
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
            //MainAccess = new MainWindow();
            //MainAccess.searchInvoice(TempSelect);

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
            int myID;

            if(cb_InvoiceSelect.SelectedIndex != -1 && Int32.TryParse(cb_InvoiceSelect.SelectedValue.ToString(), out myID))
            {
                selectedInvoice =  myInvoices.SelectSingleInvoice(myID);
                dt_Results = myInvoices.getAllInvoicesByID(myID);
                dg_InvoiceSearch.DataContext = dt_Results.DefaultView;
            }
        }

        /// <summary>
        /// When DatePicker has selected a date, it calls method to filter based on date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_InvoiceDateSelect_CalendarClosed(object sender, RoutedEventArgs e)
        {
            updateDataGridDate(dp_InvoiceDateSelect.SelectedDate.Value);
        }

        /// <summary>
        /// When item is selected, will filter the DataGrid to to only show the criteria selected based on Date
        /// </summary>
        private void updateDataGridDate(DateTime myDate)
        {
            dt_Results = myInvoices.getAllInvoicesByDate(myDate);
            dg_InvoiceSearch.DataContext = dt_Results.DefaultView;
        }

        /// <summary>
        /// When user selects a value from the Total Cost drop down, this method will find the invoices that match that total and update the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_ChargeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            decimal selCost;

            if (cb_ChargeSelect.SelectedIndex != -1 && Decimal.TryParse(cb_ChargeSelect.SelectedValue.ToString(), out selCost))
            {
                dt_Results = myInvoices.GetInvoicesByCost(selCost);
                dg_InvoiceSearch.DataContext = dt_Results.DefaultView;
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            newSearch();
        }


        /*
        private void dg_InvoiceSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            Invoice invoice = new Invoice();
            DataRowView dataRow = (DataRowView)grid.SelectedItem;
            int index = grid.CurrentCell.Column.DisplayIndex;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            MainWindow.searchInv = Convert.ToInt32(cellValue);
        }
        */
    }
}
