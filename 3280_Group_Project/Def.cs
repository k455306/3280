using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Added to keep entegrity of the tables 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3280_Group_Project
{
    [Table("Def")]
    public class Def
    {
        [Key]
        public int ItemID { get; set; }
        
        public int InvoiceID { get; set; }

        [Required, Display(Name ="Item Name")]
        public string ItemName { get; set; }

        [Required, Display(Name ="Item Cost"), DataType(DataType.Currency)]
        public decimal ItemCost { get; set; }

        [Display(Name ="Item Description")]
        public string ItemDescription { get; set; }


        public Def()
        {
            
            InvoiceID = 0;
            ItemName = "";
            ItemCost = 0;
            ItemDescription = ""; 

        }

        public Def(int itemID, int invoiceID, string itemName, decimal itemCost, string itemDescription)
        {
            ItemID = itemID;
            InvoiceID = invoiceID;
            ItemName = ItemName;
            ItemCost = itemCost;
            ItemDescription = itemDescription; 

        }

        public override string ToString()
        {
            return ItemID.ToString() + "-" + ItemName + "-" + ItemCost.ToString(); 
        }

    }
}
