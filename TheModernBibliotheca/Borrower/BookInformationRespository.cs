using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca.Borrower
{
    public class BookInformationRespository
    {
        public BookInformation GetBookInformation(int bookID)
        {
            string query = "SELECT * FROM BookInformation WHERE ID = @BookID";
            var result = DbHelper.ExecuteDataTableQuery(query, ("BookID", bookID)).Rows[0];
            return new BookInformation();
        }
    }
}