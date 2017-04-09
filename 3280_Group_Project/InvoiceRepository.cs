using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows;

/// <summary>
/// _3280_Group_Project Namespace is used to search, edit and view invoices 
/// </summary>
namespace _3280_Group_Project
{
    /// <summary>
    /// InvoiceRepository Used for Database calls
    /// </summary>
    public class InvoiceRepository
    {
        /// <summary>
        /// conn is set to the connection string of the database3
        /// </summary>
        internal string conn { get; set; } = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=../../AppData/Invoices.accdb";
        /// <summary>
        /// Declaration of a list of strings for results
        /// </summary>
        List<string> results; 
        /// <summary>
        /// Declaration for OleDBConnection
        /// </summary>
        OleDbConnection OleDB; 
        /// <summary>
        /// InvoiceRepository Constructor to initialize connection 
        /// Opens OleDB connection
        /// </summary>
        public InvoiceRepository()
        {
            ///Initialize results list for query results
            results = new List<string>(); 
            ///try opening initializing new connection 
            try
            {
                ///initialize OleDB Connection 
                OleDB = new OleDbConnection(conn);
                ///Open OleDb Connection 
                OleDB.Open(); 

            }
            catch(OleDbException ex)
            {
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
            
        }
        /// <summary>
        /// Gets all invoices from the invoice table
        /// </summary>
        /// <returns></returns>
        public List<Invoice> getAllInvoices()
        {
            ///Initialize new Invoice list 
            List<Invoice> invoices = new List<Invoice>();
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            try
            {
                ///query string to bring back all invoices from database
                string query = "SELECT * FROM [Invoices]";
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                ///New Instance of OleDBAdator to store results from accessDBCommand 
                OleDbDataAdapter accessAdaptor = new OleDbDataAdapter(accessCommand);
                ///Fill datatable with adaptor values 
                accessAdaptor.Fill(dt);
                ///Iterate through data table to find specific values 
                foreach (DataRow row in dt.Rows)
                {
                    //Iterate through the columns that were returned
                    foreach (DataColumn column in dt.Columns)
                    {
                        ///add values to String ArrayList 
                        results.Add(row[column].ToString());

                    }
                }

                ///Iterate through the list of results and create new object
                for (int i = 0; i < results.Count; i++)
                {
                    ///give me each row of values 
                    if (i % 8 == 0)
                    {
                        ///Adds new invoices to list of Invoices 
                        invoices.Add(new Invoice(Convert.ToInt32(results[i]), results[i + 1], results[i + 2], results[i + 3], results[i + 4],
                                     Convert.ToInt32(results[i + 5]), Convert.ToDecimal(results[i + 6]), Convert.ToDateTime(results[i + 7])));

                    }

                }
               
            }
            catch(OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                
            }
             return invoices; 

        }

        /// <summary>
        /// get AllInvoicesDT gets all invoices and returns a DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getAllInvoicesDT()
        {
            ///Initialize new Invoice list 
            List<Invoice> invoices = new List<Invoice>();
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            try
            {
                ///query string to bring back all invoices from database
                string query = "SELECT * FROM [Invoices]";
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                ///New Instance of OleDBAdator to store results from accessDBCommand 
                OleDbDataAdapter accessAdaptor = new OleDbDataAdapter(accessCommand);
                ///Fill datatable with adaptor values 
                accessAdaptor.Fill(dt);
                ///Iterate through data table to find specific values 
                foreach (DataRow row in dt.Rows)
                {
                    //Iterate through the columns that were returned
                    foreach (DataColumn column in dt.Columns)
                    {
                        ///add values to String ArrayList 
                        results.Add(row[column].ToString());

                    }
                }

                ///Iterate through the list of results and create new object
                for (int i = 0; i < results.Count; i++)
                {
                    ///give me each row of values 
                    if (i % 8 == 0)
                    {
                        ///Adds new invoice to list of invoices
                        invoices.Add(new Invoice(Convert.ToInt32(results[i]), results[i + 1], results[i + 2], results[i + 3], results[i + 4],
                                     Convert.ToInt32(results[i + 5]), Convert.ToDecimal(results[i + 6]), Convert.ToDateTime(results[i + 7])));

                    }

                }

            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
            return dt;

        }
        /// <summary>
        /// SelectSingleInvoice has a parameter of id and will return an invoice object 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Invoice SelectSingleInvoice(int id)
        {
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            Invoice invoice = new Invoice();
            try
            {
                ///query string to bring back all invoices from database
                string query = "SELECT * FROM [Invoices] WHERE [invoiceID] = " + id.ToString();
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                ///New Instance of OleDBAdator to store results from accessDBCommand 
                OleDbDataAdapter accessAdaptor = new OleDbDataAdapter(accessCommand);
                ///Fill datatable with adaptor values 
                accessAdaptor.Fill(dt);
                ///Iterate through data table to find specific values 
                foreach (DataRow row in dt.Rows)
                {
                    //Iterate through the columns that were returned
                    foreach (DataColumn column in dt.Columns)
                    {
                        ///add values to String ArrayList 
                        results.Add(row[column].ToString());

                    }
                }

                ///Iterate through the list of results and create new object
                for (int i = 0; i < results.Count; i++)
                {
                    ///give me each row of values 
                    if (i % 8 == 0)
                    {
                       ///Create New Invoice Object
                       invoice = new Invoice(Convert.ToInt32(results[i]), results[i + 1], results[i + 2], results[i + 3], results[i + 4],
                                     Convert.ToInt32(results[i + 5]), Convert.ToDecimal(results[i + 6]), Convert.ToDateTime(results[i + 7]));
                      
                    }

                }
                
            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
            ///Returns invoice object
            return invoice;
        }

        /// <summary>
        /// Add invoice has parameter of Invoice object and has no return type
        /// </summary>
        /// <param name="invoice"></param>
        public void AddInvoice(Invoice invoice)
        {
            ///Trys to execute insert query to the invoices table
            try
            {
                
                ///query string for insert into invoices table
                string query = "INSERT INTO [Invoices]([firstName], [lastName], [email], [address], [itemCount], [subtotal],[invoiceDate])"
                                + "Values('"+ invoice.FirstName.ToString()+"','"+ invoice.LastName.ToString()+"','"+ invoice.Email.ToString()+"','"+ invoice.Address.ToString()+"',"
                                + invoice.ItemCount +","+ invoice.SubTotal+",'"+ invoice.InvoiceDate+"')";
                ///Database command that uses OleDB object to execute the string query
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                ///Executes the query from the command
                cmd.ExecuteNonQuery();  


            }
            catch(OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }


        }
        /// <summary>
        /// Update invoice will update an invoice object in the invoice table 
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoice(Invoice invoice)
        {
            ///try to update invoice object in the database 
            try
            {
                ///update grand total 
                invoice.SubTotal = GetGrandTotal(invoice);
                ///update Item Count
                invoice.ItemCount = GetItemCount(invoice); 

                ///query to update invoice object in the invoices table
                string query = "UPDATE [Invoices]"
                                + "SET [firstName] = '" + invoice.FirstName.ToString()
                                + "', [lastName] = '" + invoice.LastName.ToString()
                                + "', [email] = '" + invoice.Email.ToString()
                                + "', [address] = '" + invoice.Address.ToString()
                                + "', [itemCount] = " + invoice.ItemCount.ToString()
                                + ", [subTotal] = " + invoice.SubTotal.ToString()
                                + ", [invoiceDate] = '" + invoice.InvoiceDate.ToString()
                                + "' WHERE invoiceID = " + invoice.InvoiceID.ToString();
                ///initialize new command to executr string query with OleDB Connection
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                ///Executes the string query against the Database
                cmd.ExecuteNonQuery();
                ///Clase OleDB Connection 
                OleDB.Close();        


            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }

        }
        /// <summary>
        /// Deletes and invoice from the invoices table. Takes and Invoice Object as the Parameter
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice(Invoice invoice)
        {
            ///Try to Delete objec if it is found. if it is found go ahead continue 
            try
            {
                ///string query is the query that will delete the invoice from invoices from invoice object
                string query = "DELETE FROM [Invoices]"
                               +"WHERE [invoiceID] = " + invoice.InvoiceID.ToString();
                ///Initialize new command object using the OleDB connection 
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                ///Execute command from the string query
                cmd.ExecuteNonQuery();
                /// Close OleDB connection 
                OleDB.Close();

            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }

        }


        //******************************************************Item Methods**********************************************************************************/


        /// <summary>
        /// Gets all items from the Def table
        /// </summary>
        /// <returns></returns>
        public List<Def> getAllItems()
        {
            ///Initialize new Invoice list 
            List<Def> items = new List<Def>();
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            try
            {
                ///query string to bring back all invoices from database
                string query = "SELECT * FROM [Def]";
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                ///New Instance of OleDBAdator to store results from accessDBCommand 
                OleDbDataAdapter accessAdaptor = new OleDbDataAdapter(accessCommand);
                ///Fill datatable with adaptor values 
                accessAdaptor.Fill(dt);
                ///Iterate through data table to find specific values 
                foreach (DataRow row in dt.Rows)
                {
                    //Iterate through the columns that were returned
                    foreach (DataColumn column in dt.Columns)
                    {
                        ///add values to String ArrayList 
                        results.Add(row[column].ToString());

                    }
                }

                ///Iterate through the list of results and create new object
                for (int i = 0; i < results.Count; i++)
                {
                    ///give me each row of values 
                    if (i % 5 == 0)
                    {
                        // MessageBox.Show("Inside and i = "+i.ToString());
                        items.Add(new Def(Convert.ToInt32(results[i]), Convert.ToInt32(results[i + 1]), results[i + 2], Convert.ToDecimal(results[i + 3]), results[i + 4]));

                    }

                }

            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
            ///Return a list of items
            return items;

        }

        /// <summary>
        /// Selects a single item from id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Def SelectSingleItem(int id)
        {
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            ///New Def item object 
            Def item = new Def();
            /// try and select all items from the Def Table
            try
            {
                ///query string to bring back all invoices from database
                string query = "SELECT * FROM [Def] WHERE [itemID] = " + id.ToString();
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                ///New Instance of OleDBAdator to store results from accessDBCommand 
                OleDbDataAdapter accessAdaptor = new OleDbDataAdapter(accessCommand);
                ///Fill datatable with adaptor values 
                accessAdaptor.Fill(dt);
                ///Iterate through data table to find specific values 
                foreach (DataRow row in dt.Rows)
                {
                    //Iterate through the columns that were returned
                    foreach (DataColumn column in dt.Columns)
                    {
                        ///add values to String ArrayList 
                        results.Add(row[column].ToString());

                    }
                }

                ///Iterate through the list of results and create new object
                for (int i = 0; i < results.Count; i++)
                {
                    ///give me each row of values 
                    if (i % 5 == 0)
                    {
                        ///Create New Invoice Object
                        item = new Def(Convert.ToInt32(results[i]), Convert.ToInt32(results[i + 1]), results[i + 2], Convert.ToDecimal(results[i + 3]), results[i + 4]);

                     }

                }

            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }

            return item;
        }

        /// <summary>
        /// SelectItemsSingleInvoice grabs all items that have the same invoice id 
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public List<Def> SelectItemsSingleInvoice(Invoice invoice)
        {
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            ///Initialize list of items of new List<Def>
            List<Def> items = new List<Def>();
            ///try and select all items with invoice id
            try
            {
                ///query string to bring back all invoices from database
                string query = "SELECT * FROM [Def] WHERE [invoiceID] = " + invoice.InvoiceID.ToString();
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                ///New Instance of OleDBAdator to store results from accessDBCommand 
                OleDbDataAdapter accessAdaptor = new OleDbDataAdapter(accessCommand);
                ///Fill datatable with adaptor values 
                accessAdaptor.Fill(dt);
                ///Iterate through data table to find specific values 
                foreach (DataRow row in dt.Rows)
                {
                    //Iterate through the columns that were returned
                    foreach (DataColumn column in dt.Columns)
                    {
                        ///add values to String ArrayList 
                        results.Add(row[column].ToString());

                    }
                }

                ///Iterate through the list of results and create new object
                for (int i = 0; i < results.Count; i++)
                {
                    ///give me each row of values 
                    if (i % 5 == 0)
                    {
                        ///Create New Invoice Object
                        items.Add(new Def(Convert.ToInt32(results[i]), Convert.ToInt32(results[i + 1]), results[i + 2], Convert.ToDecimal(results[i + 3]), results[i + 4]));

                    }

                }

            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
            ///return list of items
            return items;
        }

        /// <summary>
        /// AddItem adds a new item to the Def Table
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Def item)
        {
            ///try and inserting new item into the 
            try
            {
                
                ///Insert new items into the Def table 
                string query = "INSERT INTO [Def]([invoiceID], [itemName], [itemCost], [itemDescription])"
                                + "Values(" + item.InvoiceID + ",'" + item.ItemName + "'," + item.ItemCost + ",'" + item.ItemDescription +"')";
                ///Initialize new command to use the string query and OleDB connection
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                ///Execute command 
                cmd.ExecuteNonQuery();


            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }


        }

        /// <summary>
        /// Update Item in the Def table 
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(Def item)
        {
            ///Try and update item in the Def table
            try
            {
                ///String query is to build the update statement to update the Def table
                string query = "UPDATE [Def]"
                                + "SET [invoiceID] = " + item.InvoiceID.ToString()
                                + ", [itemName] = " + item.ItemName
                                + ", [itemCost] = " + item.ItemCost.ToString()
                                + ", [itemDescription] = " + item.ItemDescription
                                + "WHERE itemID = " + item.ItemID.ToString();
                ///Initialize the a new command to use the string query and OleDB connection 
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                ///Execute command
                cmd.ExecuteNonQuery();
                ///Close OleDB Connection 
                OleDB.Close();


            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }

        }

        /// <summary>
        /// DeleteItem from the Def table 
        /// </summary>
        /// <param name="item"></param>
        public void DeleteItem(Def item)
        {
            ///Try and Delete Item from the Def Table
            try
            {
                ///string query is the Delete statement that will delete by the id of the item
                string query = "DELETE FROM [Def]"
                               + "WHERE [itemID] = " + item.ItemID.ToString();
                ///Initialize new command to use the string query and OleDB connection 
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                ///Execute Command
                cmd.ExecuteNonQuery();
                ///Close Connection 
                OleDB.Close();

            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }

        }
        /// <summary>
        /// gets the grandTotal of the of the invoice 
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public decimal GetGrandTotal(Invoice invoice)
        {
            ///total of the sum of item costs
            decimal total = 0;

            MessageBox.Show("Before the query"+invoice.InvoiceID.ToString());
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT SUM([itemCost]) FROM [DEF] WHERE [invoiceID] = " + invoice.InvoiceID.ToString();
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
               

                /// Get total of itemCost
                total = Convert.ToDecimal(string.Format("{0:0.00}", accessCommand.ExecuteScalar()));


                ///return total 
                return total; 


            }
            catch(OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// GetItemCount
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public int GetItemCount(Invoice invoice)
        {
            ///count of items with the invoice id 
            int total = 0;
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            ///Try and get the count of items of invoice
            try
            {
                ///string query get count fo the itemID with invoice ID.
                string query = "SELECT COUNT([itemID]) FROM [DEF] WHERE [invoiceID] = " + invoice.InvoiceID.ToString();
                ///New Instance of OleDBCommand Command to database using query and connection 
                OleDbCommand accessCommand = new OleDbCommand(query, OleDB);
                /// Get total of invoiceID
                total = (int) accessCommand.ExecuteScalar();
             
                ///return total 
                return total;


            }
            catch (OleDbException ex)
            {
                ///Close Database Connection 
                OleDB.Close();
                ///throws exception to the higher level method
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }


    }
}
