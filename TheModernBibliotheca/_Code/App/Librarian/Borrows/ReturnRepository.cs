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

        public static ReturnViewModel GetBorrowInfo(int id)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var borrowInfo = context.Borrows.FirstOrDefault(b => b.BorrowID == id);

                return new ReturnViewModel
                {
                    BorrowDate = borrowInfo.DateBorrowed,
                    BookName = borrowInfo.BookInstance.BookInformation.Title,
                    BorrowerName = borrowInfo.LibraryUser.FullName + " (" + borrowInfo.LibraryUser.Email + ")",
                    DeadlineDate = borrowInfo.ReturnDate
                };
            }
        }

        public static void ReturnBook(int id, bool late, bool damaged, bool lost)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var borrow = context.Borrows.FirstOrDefault(b => b.BorrowID == id);
                borrow.BorrowState = Constants.Borrow.RETURNED_STATE;
                borrow.DateReturned = DateTime.Now;

                if (late)
                {
                    context.Violations.Add(new Violation
                    {
                        BorrowID = id,
                        ViolationType = Constants.Violation.LATE_TYPE
                    });
                }

                if (damaged)
                {
                    context.Violations.Add(new Violation
                    {
                        BorrowID = id,
                        ViolationType = Constants.Violation.DAMAGE_TYPE
                    });
                }

                if (lost)
                {
                    context.Violations.Add(new Violation
                    {
                        BorrowID = id,
                        ViolationType = Constants.Violation.LOST_TYPE
                    });
                }

                context.SaveChanges();
            }
        }
    }
}