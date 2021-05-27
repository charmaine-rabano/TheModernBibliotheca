using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Borrower
{
    public class CurrentBorrowViewModel
    {
        public string Image { get; set; }
        public string Isbn { get; set; }
        public string Title{ get; set; }
        public string Author{ get; set; }
        public string Summary{ get; set; }
        public string Status{ get; set; }
        public string Genre { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}