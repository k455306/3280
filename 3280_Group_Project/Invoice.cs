using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// 
/// </summary>
namespace _3280_Group_Project
{
    /// <summary>
    /// Class Invoice is used to create objects of Invoice for data retrieved from the database
    /// </summary>
    ///

    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set;}

        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; } 

        [Required, Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name ="Email")]
        public string Email { get; set; }

        [Required, Display(Name ="Address")]
        public string Address { get; set;}

        [Required, Display(Name ="Item Count")]
        public int ItemCount { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }

        [Required, Display(Name ="Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Invoice Constructor 
        /// </summary>
        public Invoice()
        {
           
            FirstName = "";
            LastName = "";
            Email = "";
            Address = "";
            ItemCount = 0;
            SubTotal = 0;
            InvoiceDate = DateTime.Now; 
        }

        public Invoice(int invoiceID, string firstName, string lastName, string email, string address, int itemCount, decimal subtotal, DateTime invoiceDate )
        {
            InvoiceID = invoiceID; 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            ItemCount = itemCount;
            SubTotal = subtotal;
            InvoiceDate = invoiceDate; 
        }

        public override string ToString()
        {
            return InvoiceID.ToString() + "-" + FirstName + " " + LastName + "-" + ItemCount.ToString() + "-" + SubTotal.ToString();
        }

    }
}
