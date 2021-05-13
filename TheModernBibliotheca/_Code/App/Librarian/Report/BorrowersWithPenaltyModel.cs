using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class BorrowersWithPenaltyModel
    {
        public string BorrowerName { get; set; }
        public string Violation { get; set; }
        public DateTime? ViolationDate { get; set; }

        public string BookTitle { get; set; }
    }
}