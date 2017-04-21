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
        List<Invoice> Invoices;
        InvoiceRepository iR;
        decimal total;

        public MainWindow()
        {
            //Initialize the window component
            InitializeComponent();
            //Applications stop running only when the Shutdown method of the Application is called
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            // Initialize new Invoice Repository object
            iR = new InvoiceRepository();
            // Initialize new Inventory list
            Inv = new List<Inventory>();
            //Set Inventory items to list
            Inv = iR.getAllInventoryItems();
            //Initialize new customer list
            Customers = new List<Customer>();
            //Set Customers to list
            Customers = iR.GetCustomers();
            Invoices = new List<Invoice>();

            MySearchWindow = new SearchWindow();
            MyUpdateWindow = new UpdateWindow();

            //Adds each item to the combo box
            foreach (Customer Customers in Customers)
            {
                customerBox.Items.Add(Customers.ToString());
            }

             foreach (Inventory Inv in Inv)
            {
                itemBox.Items.Add(Inv.ToString());
            }
            

        }
        /// <summary>
        /// Button click to bring up the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MySearchWindow.ShowDialog();
        }
        /// <summary>
        /// Button click to commit invoice to the db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            //Commits invoice to the DB. 
            
            //iR.AddInvoice();
        }
        /// <summary>
        /// Clears invoice screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            itemListBox.Items.Clear();
            customerBox.SelectedIndex = -1;
            itemBox.SelectedIndex = -1;
            totalBox.Clear();
        }
        /// <summary>
        /// Brings up search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MySearchWindow.ShowDialog();
        }
        /// <summary>
        /// Closes program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MyUpdateWindow.ShowDialog();
        }
        /// <summary>
        /// Adds item to list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addItemBtn_Click(object sender, RoutedEventArgs e)
        {
            invTotal(itemBox.SelectedIndex,'a');
            itemListBox.Items.Add(itemBox.Text);
            totalBox.Text = total.ToString();
        }
        /// <summary>
        /// Deletes item from list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delItemBtn_Click(object sender, RoutedEventArgs e)
        {
            invTotal(itemBox.SelectedIndex,'s');
            itemListBox.Items.Remove(itemListBox.SelectedItem);
            totalBox.Text = total.ToString();
        }
        /// <summary>
        /// Calculates invoice total
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void invTotal(int x, char y)
        {
            if(y == 'a')
            {
                total += Inv[x].ItemCost;
            }
            else if (y == 's')
            {
                total -= Inv[x].ItemCost;
            }
            
        }

    }
}
