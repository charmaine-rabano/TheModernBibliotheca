using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Borrower
{
    public class BorrowerRepository
    {
        public static string GetFirstName(int userId)
        {
            string FirstName;
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.Where(e => e.UserID == userId).First();
                FirstName = user.FirstName;
            }

            return FirstName;
        }

        public static string GetLastName(int userId)
        {
            string LastName;
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.Where(e => e.UserID == userId).First();
                LastName = user.LastName;
            }

            return LastName;
        }

        public static void ModifyName(int userId, LibraryUser modifiedUser, bool passwordChanged)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.FirstOrDefault(e => e.UserID == userId && e.AccountStatus != Constants.LibraryUser.DEACTIVATED_STATUS);

                if (user == null) throw new InvalidOperationException("Invalid User ID");

                user.FirstName = modifiedUser.FirstName;
                user.LastName = modifiedUser.LastName;

                if (passwordChanged)
                {
                    user.AccountPassword = modifiedUser.AccountPassword;
                }

                context.SaveChanges();
            }
        }

        internal static void CreateReservation(string ISBN, int userID)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var states = new List<string>
                {
                    Constants.Borrow.REJECTED_STATE,
                    Constants.Borrow.RETURNED_STATE
                };

                // Select first available book
                var varInstance = context.BookInstances
                    .Where(e => e.ISBN == ISBN)
                    .Where(e =>
                        e.InCirculation &&
                        (e.Borrows.Count == 0 ||
                            states.Contains(e.Borrows.OrderByDescending(f => f.DateBorrowed)
                            .FirstOrDefault()
                            .BorrowState)))
                    .First();

                Borrow borrow = new Borrow()
                {
                    InstanceID = varInstance.InstanceID,
                    UserID = userID,
                    SiteType = Constants.Borrow.OFFSITE_SITE_TYPE,
                    BorrowState = Constants.Borrow.REQUESTED_STATE,
                    DateCreated = DateTime.Now
                };
                context.Borrows.Add(borrow);
                context.SaveChanges();

                Reservation reservation = new Reservation()
                {
                    BorrowID = borrow.BorrowID,
                    DateReserved = DateTime.Now
                };
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }

        public static void ModifyPassword(int userId, LibraryUser modifiedUser, bool passwordChanged)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.FirstOrDefault(e => e.UserID == userId && e.AccountStatus != Constants.LibraryUser.DEACTIVATED_STATUS);

                if (passwordChanged)
                {
                    user.AccountPassword = modifiedUser.AccountPassword;
                }

                context.SaveChanges();
            }
        }
    }
}