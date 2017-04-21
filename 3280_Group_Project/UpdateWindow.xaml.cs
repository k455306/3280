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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        InvoiceRepository myItems;
        Inventory NewItem;
        DataTable dt_Results;
        List<Inventory> myInventoryList;
        /// <summary>
        /// Initialization which also poplulates the DataGrid with all the Items.
        /// </summary>
        public UpdateWindow()
        {
            InitializeComponent();
            //Call to InvoiceRepository.getAllItems() which will return a list of Invoice Items that can then be inserted into the DataGrid
            myItems = new InvoiceRepository();
            NewItem = new Inventory();
            myInventoryList = new List<Inventory>();
            dt_Results = new DataTable();
            newSearch();

        }

        private void newSearch()
        {
            dt_Results = myItems.getAllInventoryItemsDT();
            dg_UpdateDef.DataContext = dt_Results.DefaultView;
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
            decimal newItemCost = 0;
            NewItem.ItemName = tb_Name.Text;
            Decimal.TryParse(tb_Cost.Text, out newItemCost);
            NewItem.ItemCost = newItemCost;
            NewItem.ItemDescription = tb_Description.Text;

            //Call to the InvoiceRepository.AddItem method
            myItems.AddInventoryItem(NewItem);
            newSearch();
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
