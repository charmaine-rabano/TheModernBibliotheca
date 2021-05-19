using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class ReturnViewModel
    {
        public DateTime? BorrowDate { get; set; }

        public string BookName { get; set; }

        public string BorrowerName { get; set; }

        public DateTime? DeadlineDate { get; set; }

        public int BorrowID { get; set; }
    }
}