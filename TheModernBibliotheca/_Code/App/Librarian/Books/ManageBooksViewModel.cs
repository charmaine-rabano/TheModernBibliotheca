using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class ManageBooksViewModel
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string BookCover { get; set; }
        public string Summary { get; set; }
    }
}