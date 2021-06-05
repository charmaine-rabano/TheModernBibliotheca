using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class BorrowersWithPenaltyViewModel
    {
        public string BorrowerName { get; set; }
        public string Violation { get; set; }
        public string ViolationDate { get; set; }
        public string BookTitle { get; set; }
    }
}