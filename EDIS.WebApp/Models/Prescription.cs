using System;
using System.Collections.Generic;

namespace EDIS.WebApp.Models
{
    public class Prescription
    {
        public string RxNumber { get; set;}
        public int RefillsRemaining { get; set; }
        public DateTime LastRefillDate { get; set; }
        public string StockNumber { get; set; }

        public Inventory StockNumberNavigation { get; set; }
    }
}