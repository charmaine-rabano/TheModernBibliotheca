using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class BorrowersWithPenaltyRepository
    {
        public static IEnumerable<BorrowersWithPenaltyViewModel> GetBorrowersWithPenalty()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.Violations.Select(e => new BorrowersWithPenaltyViewModel
                {
                    BorrowerName = e.Borrow.LibraryUser.FirstName + " " + e.Borrow.LibraryUser.LastName,
                    Violation = e.ViolationType,
                    ViolationDate = (DateTime)e.Borrow.DateReturned,
                    BookTitle = e.Borrow.BookInstance.BookInformation.Title,
                }).ToList();
            }
        }
    }
}