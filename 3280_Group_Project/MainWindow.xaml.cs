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
        SearchWindow MySearchWindow;
        UpdateWindow MyUpdateWindow;
        List<Inventory> Inv;
        List<Customer> Customers;
        InvoiceRepository iR;

        public MainWindow()
        {
            InitializeComponent();
            //populate customer list
            //populate item list
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            iR = new InvoiceRepository();
            Inv = new List<Inventory>();
            Inv = iR.getAllInventoryItems(); //Look at this line here
            Customers = new List<Customer>();
            Customers = iR.GetCustomers();
            MySearchWindow = new SearchWindow();
            MyUpdateWindow = new UpdateWindow();

            foreach (Customer Customers in Customers)
            {
                customerBox.Items.Add(Customers.ToString());
            }

           foreach (Inventory Inv in Inv)
           {
                itemBox.Items.Add(Inv.ToString());
           }
            

        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            //Brings up search window.
            MySearchWindow.ShowDialog();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            //Commits invoice to the DB. 
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //Cancels current invoice and clears all fields.
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Brings up search window.
            MySearchWindow.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //Closes program
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MyUpdateWindow.ShowDialog();
        }

        private void addItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
