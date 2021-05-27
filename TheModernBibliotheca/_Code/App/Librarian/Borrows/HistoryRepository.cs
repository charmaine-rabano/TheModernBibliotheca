using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class HistoryRepository
    {
        public static bool IsEmailRegistered(string email)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.Any(e => e.Email.ToLower() == email.ToLower());
        }

        public static IEnumerable<HistoryViewModel> GetBorrowHistory(string email)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.Borrows.Where(b => b.LibraryUser.Email == email).OrderByDescending(b => b.BorrowID).Select(b => new 
                {
                    BookName = b.BookInstance.BookInformation.Title,
                    SiteType = b.SiteType,
                    DateReserved = b.Reservation.DateReserved,
                    DateBorrowed = b.DateBorrowed,
                    DateReturned = b.DateReturned,
                    Status = b.BorrowState,
                    Data = b.Violations.AsEnumerable()
                }).ToList().Select(n => new HistoryViewModel
                {
                    BookName = n.BookName,
                    SiteType = n.SiteType,
                    DateReserved = n.DateReserved,
                    DateBorrowed = n.DateBorrowed,
                    DateReturned = n.DateReturned,
                    Status = n.Status,
                    Violation = n.Data.Aggregate("", (a, b) => (a == "" ? "" : a + ", ") + b.ViolationType)
                });
            }
        }

        public static string GetBorrowerName(string email)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.LibraryUsers.FirstOrDefault(u => u.Email == email).FullName;
            }
        }
    }
}