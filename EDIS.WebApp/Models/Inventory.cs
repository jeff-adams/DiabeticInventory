using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.WebApp.Models
{
    public class Inventory
    {
        [Display(Name = "Stock Number")]
        public string StockNumber { get; set;}
        public string Brand { get; set; }
        [Display(Name = "Item Type")]
        public string ItemType { get; set; }
        [Display(Name = "Units On Hand")]
        public int UnitsOnHand { get; set; }
        [Display(Name = "Reorder Point")]
        public int ReorderPoint { get; set; }

        public ICollection<Prescription> Prescription { get; set; }
    }
}