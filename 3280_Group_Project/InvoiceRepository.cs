using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Reflection; 

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
        internal string conn { get; set; } = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Invoices.accdb";
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
                        // MessageBox.Show("Inside and i = "+i.ToString());
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
                        // MessageBox.Show("Inside and i = "+i.ToString());
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

            return invoice;
        }


        public void AddInvoice(Invoice invoice)
        {

            try
            {
                //string query = "INSERT INTO [Invoices]([itemID],[invoiceID], [firstName], [lastName], [email], [address], [itemCount], [subtotal],[invoiceDate])"
                //                + "Values([itemID] = ?, [invoiceID] = ?, [firstName] = ?, [lastName] = ?, [email] = ?, [address] = ?, [itemCount] = ?, [subtotal] = ?,"
                //                + "[invoiceDate] = ?)";
                //OleDbCommand cmd = new OleDbCommand(query, OleDB);
                //cmd.Parameters.AddWithValue("@[invoiceID]", invoice.InvoiceID.ToString());
                //cmd.Parameters.AddWithValue("@[firstName]", invoice.FirstName.ToString());
                //cmd.Parameters.AddWithValue("@[lastName]", invoice.LastName.ToString());
                //cmd.Parameters.AddWithValue("@[email]", invoice.Email.ToString());
                //cmd.Parameters.AddWithValue("@[address]", invoice.Address.ToString());
                //cmd.Parameters.AddWithValue("@[itemCount]", invoice.ItemCount.ToString());
                //cmd.Parameters.AddWithValue("@[subtotal]", invoice.SubTotal.ToString());
                //cmd.Parameters.AddWithValue("@[invoiceDate]", invoice.InvoiceDate.ToString()); 

                string query = "INSERT INTO [Invoices]([firstName], [lastName], [email], [address], [itemCount], [subtotal],[invoiceDate])"
                                + "Values('"+ invoice.FirstName.ToString()+"','"+ invoice.LastName.ToString()+"','"+ invoice.Email.ToString()+"','"+ invoice.Address.ToString()+"',"
                                + invoice.ItemCount +","+ invoice.SubTotal+",'"+ invoice.InvoiceDate+"')";
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
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

        public void UpdateInvoice(Invoice invoice)
        {
            try
            {

                string query = "UPDATE [Invoices]"
                                + "SET [firstName] = " + invoice.FirstName
                                + ", [lastName] = " + invoice.LastName
                                + ", [email] = " + invoice.Email
                                + ", [address] = " + invoice.Address
                                + ", [itemCount] = " + invoice.ItemCount.ToString()
                                + ", [subTotal] = " + invoice.SubTotal.ToString()
                                + ", [invoiceDate] = " + invoice.InvoiceDate.ToString()
                                + "WHERE invoiceID = " + invoice.InvoiceID.ToString();

                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                cmd.ExecuteNonQuery();
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

        public void DeleteInvoice(Invoice invoice)
        {
            try
            {

                string query = "DELETE FROM [Invoices]"
                               +"WHERE [invoiceID] = " + invoice.InvoiceID.ToString();

                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                cmd.ExecuteNonQuery();
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
            return items;

        }


        public Def SelectSingleItem(int id)
        {
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            Def item = new Def();
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


        public List<Def> SelectItemsSingleInvoice(Invoice invoice)
        {
            ///DataTable to store Adaptor values 
            DataTable dt = new DataTable();
            List<Def> items = new List<Def>();
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

            return items;
        }


        public void AddItem(Def item)
        {

            try
            {
                //string query = "INSERT INTO [Invoices]([invoiceID], [itemName], [itemCost], [itemDescription])"
                //                + "Values([invoiceID] = ?, [itemName] = ?, [itemCost] = ?, [itemDescription] = ?)";
                //OleDbCommand cmd = new OleDbCommand(query, OleDB);
                //// cmd.Parameters.AddWithValue("invoiceID", invoice.InvoiceID);
                //cmd.Parameters.AddWithValue("@[invoiceID]", item.InvoiceID);
                //cmd.Parameters.AddWithValue("@[itemName]", item.ItemName);
                //cmd.Parameters.AddWithValue("@[itemCost]", item.ItemCost);
                //cmd.Parameters.AddWithValue("@[itemDescription]", item.ItemDescription);

                string query = "INSERT INTO [Invoices]([invoiceID], [itemName], [itemCost], [address], [itemCount], [itemDescription])"
                                + "Values(" + item.InvoiceID + ",'" + item.ItemName + "'," + item.ItemCost + ",'" + item.ItemDescription +"')";
                OleDbCommand cmd = new OleDbCommand(query, OleDB);
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


        public void UpdateItem(Def item)
        {
            try
            {

                string query = "UPDATE [Def]"
                                + "SET [invoiceID] = " + item.InvoiceID.ToString()
                                + ", [itemName] = " + item.ItemName
                                + ", [itemCost] = " + item.ItemCost.ToString()
                                + ", [itemDescription] = " + item.ItemDescription
                                + "WHERE itemID = " + item.ItemID.ToString();

                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                cmd.ExecuteNonQuery();
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


        public void DeleteItem(Def item)
        {
            try
            {

                string query = "DELETE FROM [Def]"
                               + "WHERE [itemID] = " + item.ItemID.ToString();

                OleDbCommand cmd = new OleDbCommand(query, OleDB);
                cmd.ExecuteNonQuery();
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

    }
}
