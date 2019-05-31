using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Domain
{
    public class Prescription
    {
        [Display(Name = "Rx Number")]
        public string RxNumber { get; set;}
        [Display(Name = "Refills Remaining")]
        public int RefillsRemaining { get; set; }
        [Display(Name = "Last Refill Date")]
        [DataType(DataType.Date)]
        public DateTime LastRefillDate { get; set; }
        [Display(Name = "Stock Number")]
        public string StockNumber { get; set; }

        public Inventory StockNumberNavigation { get; set; }
    }
}