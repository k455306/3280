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
    /// Inventory class is to hold all items for any invoice. 
    /// </summary>
    [Table("Inventory")]
    public class Inventory
    {
        /// <summary>
        /// Property ID is to get the id from the table 
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// property itemname is to hold the name of the item
        /// </summary>
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }
        /// <summary>
        /// property itemCost is to hold the cost of the item
        /// </summary>
        [Display(Name ="Item Cost"), DataType(DataType.Currency)]
        public decimal ItemCost { get; set; }
        /// <summary>
        /// property itemDescription is to hold the description of the item
        /// </summary>
        [Display(Name ="Item Description")]
        public string ItemDescription { get; set; }


        /// <summary>
        /// Inventory is to create new Inventory object 
        /// </summary>
        public Inventory()
        {
            ///initialize ID to 0 
            ID = 0;
            ///initialize itemName to ""
            ItemName = "";
            ///initialize itemCost to 0
            ItemCost = 0; 
            ///initialize itemDescription to ""
            ItemDescription = ""; 

        }

        /// <summary>
        /// Constructory Inventory to create inventory object with values from the database 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemCost"></param>
        /// <param name="itemDescription"></param>
        public Inventory(int id, string itemName, decimal itemCost, string itemDescription)
        {
            ///initialize ItemID to ID
            ID = id;
            ///initialize ItemName to itemName
            ItemName = itemName;
            ///initialize ItemCost to itemCost
            ItemCost = itemCost;
            ///initialize ItemDescription to itemDescription
            ItemDescription = itemDescription; 
        }


        public override string ToString()
        {
            return ID + " " + ItemName + " " + ItemCost; 
        }

    }
}
