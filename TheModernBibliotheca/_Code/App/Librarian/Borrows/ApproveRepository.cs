using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class ApproveRepository
    {
        public static IEnumerable<ApproveViewModel> GetRequests()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.Reservations.Where(r => r.Borrow.BorrowState == Constants.Borrow.REQUESTED_STATE).Select(r => new ApproveViewModel
                {
                    ReservationDate = r.DateReserved,
                    BookName = r.Borrow.BookInstance.BookInformation.Title,
                    BorrowerName = r.Borrow.LibraryUser.FullName + " (" + r.Borrow.LibraryUser.Email + ")",
                    BorrowID = r.BorrowID
                }).ToList();
            }
        }

        public static void ApproveRequest(int id)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var reservation = context.Reservations.FirstOrDefault(r => r.BorrowID == id);
                reservation.Borrow.BorrowState = Constants.Borrow.APPROVED_STATE;
                reservation.DateProcessed = DateTime.Now;
                context.SaveChanges();
            }
        }

        public static void DisapproveRequest(int id)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var reservation = context.Reservations.FirstOrDefault(r => r.BorrowID == id);
                reservation.Borrow.BorrowState = Constants.Borrow.REJECTED_STATE;
                reservation.DateProcessed = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}