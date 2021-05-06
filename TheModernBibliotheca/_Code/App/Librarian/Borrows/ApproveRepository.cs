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
            var context = new TheModernDatabaseEntities();
            return context.Reservations.Where(r => r.ReservationStatus == "Pending").Select(r => new ApproveViewModel
            {
                ReservationDate = r.ReservationDate,
                BookName = r.Borrow.Book.BookInformation.Title,
                BorrowerName = r.Borrow.LibraryUser.FirstName + " " + r.Borrow.LibraryUser.LastName,
                BorrowID = r.BorrowID
            }).ToList();
        }

        public static void ApproveRequest(int id)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var reservation = context.Reservations.FirstOrDefault(r => r.BorrowID == id);
                reservation.ReservationStatus = "Approved";
                reservation.Borrow.BorrowState = "Reserved";
                reservation.DateProcessed = DateTime.Now;
                context.SaveChanges();
            }
        }

        public static void DisapproveRequest(int id)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var reservation = context.Reservations.FirstOrDefault(r => r.BorrowID == id);
                reservation.ReservationStatus = "Rejected";
                reservation.DateProcessed = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}