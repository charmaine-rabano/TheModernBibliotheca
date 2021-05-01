using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca.Borrower
{
    public class BookInformation
    {
        public string Title { get; set; }
        public string PictureURL { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }

    }
}