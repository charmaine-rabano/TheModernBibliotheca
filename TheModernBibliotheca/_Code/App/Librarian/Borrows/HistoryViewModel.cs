using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class HistoryViewModel
    {
        public string BookName { get; set; }

        public string SiteType { get; set; }

        public DateTime? DateReserved { get; set; }

        public DateTime? DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }

        public string Status { get; set; }

        public string Violation { get; set; }
    }
}