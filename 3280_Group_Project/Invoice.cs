using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
///Added to keep entegrity of the tables 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// _3280_Group_Project Namespace is used to search, edit and view invoices 
/// </summary>
namespace _3280_Group_Project
{
    /// <summary>
    /// Class Invoice is used to create objects of Invoice for data retrieved from the database
    /// </summary>
    [Table("Invoice")]
    public class Invoice
    {
        /// <summary>
        /// int InvoiceID is the Key of the invoice table
        /// </summary>
        [Key]
        public int InvoiceID { get; set;}
        /// <summary>
        /// string firstName is the first name of the customer. Required
        /// </summary>
        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; } 
        /// <summary>
        /// string LastName is the last name of the customer. Required
        /// </summary>
        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }
        /// <summary>
        /// string Email is the email of the customer. Required
        /// </summary>
        [Required, Display(Name ="Email")]
        public string Email { get; set; }
        /// <summary>
        /// string Address is the address of the customer. Required
        /// </summary>
        [Required, Display(Name ="Address")]
        public string Address { get; set;}
       
        /// <summary>
        /// InvoiceDate is the Date of the Invoice
        /// </summary>
        [Required, Display(Name ="Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Invoice Constructor that initializes each property to 0 or ""
        /// </summary>
        public Invoice()
        {
            ///Set FirstName = ""
            FirstName = "";
            //Set LastName = ""
            LastName = "";
            ///Set Email = ""
            Email = "";
            ///Set Address = "" 
            Address = "";
            ///Set Property InvoiceDate to todays date 
            InvoiceDate = DateTime.Now; 
        }
        /// <summary>
        /// Overried Invoice Constructor to create and set new Invoice object 
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="itemCount"></param>
        /// <param name="subtotal"></param>
        /// <param name="invoiceDate"></param>
        public Invoice(int invoiceID, string firstName, string lastName, string email, string address, DateTime invoiceDate )
        {
            ///Set InvoiceID to invoiceID Parameter
            InvoiceID = invoiceID; 
            ///Set FirstName to firstName Parameter
            FirstName = firstName;
            ///Set LastName to lastName Parameter
            LastName = lastName;
            ///Set Email to email Parameter 
            Email = email;
            ///Set Address to address Parameter
            Address = address;
            ///Set InvoiceDate to invoiceDate Parameter
            InvoiceDate = invoiceDate; 
        }
        /// <summary>
        /// override tostring() to print Invoice Properties 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            ///Return the InvoiceID, FirstName, LastName, ItemCount,and SubTotal as strings 
            return InvoiceID.ToString() + "-" + FirstName + " " + LastName ;
        }

    }
}
