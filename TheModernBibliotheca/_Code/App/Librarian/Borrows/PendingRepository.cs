using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class PendingRepository
    {
        public static IEnumerable<PendingViewModel> GetReservations()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.Borrows.Where(b => b.BorrowState == Constants.Borrow.APPROVED_STATE).Select(b => new PendingViewModel
                {
                    ApprovalDate = b.Reservation.DateProcessed,
                    BookName = b.BookInstance.BookInformation.Title,
                    BorrowerName = b.LibraryUser.FullName + " (" + b.LibraryUser.Email + ")",
                    BorrowID = b.BorrowID
                }).ToList();
            }
        }

        public static void ClaimReservation(int id)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var borrow = context.Borrows.FirstOrDefault(b => b.BorrowID == id);
                borrow.BorrowState = Constants.Borrow.BORROWED_STATE;
                borrow.DateBorrowed = DateTime.Now;
                borrow.ReturnDate = DateTime.Today.AddDays(7) + new TimeSpan(22, 0, 0);
                context.SaveChanges();
            }
        }
    }
}