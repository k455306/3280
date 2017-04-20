using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Added to keep entegrity of the tables 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// _3280_Group_Project Namespace is used to search, edit and view invoices 
/// </summary>
namespace _3280_Group_Project
{
    /// <summary>
    /// Class customer is to create customer objects from the database
    /// </summary>
    public class Customer
    {

        /// <summary>
        /// property CustomerID is to hold the id for each customer from the database
        /// </summary>
        [Key]
        public int CustomerID { get; set; }
        /// <summary>
        /// property CustFirstName is to hold the first name of the customer from the database
        /// </summary>
        [Display(Name = "Customer Firstname")]
        public string CustFirstName { get; set; }

        /// <summary>
        /// property CustLastName is to hold the last name of the customer lastname from the database
        /// </summary>
        [Display(Name = "Customer Lastname")]
        public string CustLastName { get; set; }
        /// <summary>
        /// property CustAddress is to the hold the address of the customer from the database
        /// </summary>
        [Display(Name = "Customer Address")]
        public string CustAddress { get; set; }
        /// <summary>
        /// property CustEmail is to the hold the email of the customer from the database
        /// </summary>
        [Display(Name = "Customer Email")]
        public string CustEmail {get; set;}

        /// <summary>
        /// Customer Constructor to initialize new customer object 
        /// </summary>
        public Customer()
        {
            ///Initialize CustomerID to 0 
            CustomerID = 0;
            ///Initialize CustFirstName to ""
            CustFirstName = "";
            ///Initialize CustLastName to ""
            CustLastName = "";
            ///Initialize CustAddress to ""
            CustAddress = "";
            ///Initialize CustEmail
            CustEmail = ""; 
        }

        /// <summary>
        /// Constructor Customer is to initlize properties from parameters passed in
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="custFirstName"></param>
        /// <param name="custLastName"></param>
        /// <param name="custAddress"></param>
        /// <param name="email"></param>
        public Customer(int customerID, string custFirstName, string custLastName, string custAddress, string custEmail)
        {
            ///CustomerID = customerID
            CustomerID = customerID;
            ///CustFirstName = custFirstName
            CustFirstName = custFirstName;
            ///CustLastName = custLastName; 
            CustLastName = custLastName;
            ///CustAddress = custAddress
            CustAddress = custAddress;
            ///CustEmail = custEmail
            CustEmail = custEmail;
        }

        /// <summary>
        /// Overried toString method to print values of the customer object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            ///Return CustomerID, CustomerFirstName, CustomerLastName
            return CustomerID + " " + CustFirstName + " " + CustLastName;
        }
    }
}
