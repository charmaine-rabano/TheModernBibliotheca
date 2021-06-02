using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Librarian.Report
{
    public class BookInventoryReport
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int InCirculation { get; set; }

    }
}