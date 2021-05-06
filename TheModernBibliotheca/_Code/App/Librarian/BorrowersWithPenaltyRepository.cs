using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class BorrowersWithPenaltyRepository
    {
        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }

        public static IEnumerable<BorrowersWithPenaltyModel> GetBorrowersWithPenalty()
        {
            var context = CreateDbContext();
            return context.Violations.Select(e => new BorrowersWithPenaltyModel
            {
                BorrowerName = e.Borrow.LibraryUser.FirstName + " " + e.Borrow.LibraryUser.LastName,
                Violation = e.ViolationType,
                ViolationDate = e.Borrow.DateReturned,
                BookTitle = e.Borrow.Book.BookInformation.Title,
            }).ToList();
        }
    }
}