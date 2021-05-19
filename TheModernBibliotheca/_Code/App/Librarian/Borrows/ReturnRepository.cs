using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class ReturnRepository
    {
        public static IEnumerable<ReturnViewModel> GetBooksToReturn()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.Borrows.Where(b => b.BorrowState == Constants.Borrow.BORROWED_STATE).Select(b => new ReturnViewModel
                {
                    BorrowDate = b.DateBorrowed,
                    BookName = b.BookInstance.BookInformation.Title,
                    BorrowerName = b.LibraryUser.FullName + " (" + b.LibraryUser.Email + ")",
                    DeadlineDate = b.ReturnDate,
                    BorrowID = b.BorrowID
                }).ToList();
            }
        }

        public static void ReturnBook(int id)
        {

        }
    }
}