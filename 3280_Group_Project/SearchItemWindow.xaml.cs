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
    /// Interaction logic for SearchItemWindow.xaml
    /// </summary>
    public partial class SearchItemWindow : Window
    {
        InvoiceRepository db; 

        public SearchItemWindow()
        {
            InitializeComponent();
            db = new InvoiceRepository();
            DataTable dt = new DataTable();
            dt = db.getAllInvoicesDT();
            dg_search_item.ItemsSource = dt.DefaultView;

            Invoice invoice = new Invoice(2, "Adam", "Barnett", "JamesPainter@mail.weber.edu", "2753", 5, (decimal)20.00, DateTime.Now);

            db.AddInvoice(invoice); 


        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
