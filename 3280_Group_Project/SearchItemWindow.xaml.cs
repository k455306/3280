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
/// <summary>
/// _3280_Group_Project Namespace is used to search, edit and view invoices 
/// </summary>
namespace _3280_Group_Project
{
    /// <summary>
    /// Interaction logic for SearchItemWindow.xaml
    /// Testing purposes only 
    /// </summary>
    public partial class SearchItemWindow : Window
    {
        /// <summary>
        /// Declare new db object 
        /// </summary>
        InvoiceRepository db; 

        /// <summary>
        /// SearchItemWindow Construction to initialize and Test
        /// </summary>
        public SearchItemWindow()
        {
            ///initialize window
            InitializeComponent();
            ///initialize new db invoiceRepository object
            db = new InvoiceRepository();
            ///initialize new DataTable object 
            DataTable dt = new DataTable();
            ///Set class object dt to data table from the database 
            dt = db.getAllInvoicesDT();
            ///Set datagrid to datatable returned from the database 
            dg_search_item.ItemsSource = dt.DefaultView;
            ///Declare and initialize new invoice object 
            Invoice invoice = new Invoice(2, "Adam", "Barnett", "JamesPainter@mail.weber.edu","3575 SOUTH iowA", DateTime.Now);
            ///Inserts new invoice into the database 
            db.AddInvoice(invoice);
          
           //Update Invoice 
           invoice = db.SelectSingleInvoice(1);
          
           decimal total = db.GetGrandTotal(invoice);
           decimal count = db.GetItemCount(invoice);
           
           

        }

        /// <summary>
        /// MenuItem Click to edit or add 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ///Do something here 
        }
        /// <summary>
        /// MenuItem to Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ///Do something here 
        }
    }
}
