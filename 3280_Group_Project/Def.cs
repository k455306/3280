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
    /// Define Def Table
    /// Def class is used to create objects from the database 
    /// </summary>
    [Table("Def")]
    public class Def
    {
        /// <summary>
        /// int ItemID is the key of the Def Table 
        /// </summary>
        [Key]
        public int ItemID { get; set; }
        /// <summary>
        /// int InvoiceID is used to pull items for invoice. Foreign key
        /// </summary>
        public int InvoiceID { get; set; }
        /// <summary>
        /// string ItemName is the title of the item. Required
        /// </summary>
        [Required, Display(Name ="Item Name")]
        public string ItemName { get; set; }
        /// <summary>
        /// decimal ItemCost is currency for how much the item costs. Required
        /// </summary>
        [Required, Display(Name ="Item Cost"), DataType(DataType.Currency)]
        public decimal ItemCost { get; set; }
        /// <summary>
        /// string ItemDescription is the description of the item
        /// </summary>
        [Display(Name ="Item Description")]
        public string ItemDescription { get; set; }

        /// <summary>
        /// Def Constructor to initialize item properties
        /// </summary>
        public Def()
        {
            ///int IvoiceID  = 0
            InvoiceID = 0;
            ///string item name empty
            ItemName = "";
            ///int ItemCost = 0
            ItemCost = 0;
            ///string ItemDescirption empty
            ItemDescription = ""; 

        }
        /// <summary>
        /// Overloaded Def Constructor to create new item object and set them from the items in the form
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="invoiceID"></param>
        /// <param name="itemName"></param>
        /// <param name="itemCost"></param>
        /// <param name="itemDescription"></param>
        public Def(int itemID, int invoiceID, string itemName, decimal itemCost, string itemDescription)
        {
            ///set ItemID to itemID parameter
            ItemID = itemID;
            ///set InvoiceID to invoiceID parameter
            InvoiceID = invoiceID;
            ///set ItemName to itemName parameter
            ItemName = itemName;
            ///set ItemCost to itemCost parameter
            ItemCost = itemCost;
            ///set ItemDescription to itemDescription
            ItemDescription = itemDescription; 

        }
        /// <summary>
        /// override ToString() to display objects of type string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            ///returns the itemID, ItemName and ItemCost as strings 
            return ItemID.ToString() + "-" + ItemName + "-" + ItemCost.ToString(); 
        }

    }
}
