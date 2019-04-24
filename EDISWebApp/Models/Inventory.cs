using System.Collections.Generic;

namespace EDISWebApp.Models
{
    public class Inventory
    {
        public string StockNumber { get; set;}
        public string Brand { get; set; }
        public string ItemType { get; set; }
        public int UnitsOnHand { get; set; }
        public int ReorderPoint { get; set; }

        public ICollection<Prescription> Prescription { get; set; }
    }
}