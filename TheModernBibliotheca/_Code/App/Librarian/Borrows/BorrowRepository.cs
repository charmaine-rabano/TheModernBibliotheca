using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Borrows
{
    public class BorrowRepository
    {
        public static bool BookExists(string isbn)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.Any(b => b.ISBN == isbn);
        }

        public static bool IsBookAvailable(string isbn)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var book = context.BookInformations.FirstOrDefault(b => b.ISBN == isbn);

                if (book.BookInstances.Any(i => i.InCirculation == true && (i.Borrows.Count == 0 || (i.Borrows.Last().BorrowState == Constants.Borrow.REJECTED_STATE || i.Borrows.Last().BorrowState == Constants.Borrow.RETURNED_STATE))))
                    return true;
                else
                    return false;
            }
        }

        public static bool IsEmailRegistered(string email)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.Any(e => e.Email.ToLower() == email.ToLower());
        }

        public static bool HasPendingBorrow(string email)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var borrower = context.LibraryUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

                if (borrower.Borrows.Count != 0)
                {
                    var lastBorrow = borrower.Borrows.OrderByDescending(b => b.BorrowID).FirstOrDefault();
                    if (lastBorrow.BorrowState != Constants.Borrow.REJECTED_STATE && lastBorrow.BorrowState != Constants.Borrow.RETURNED_STATE)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public static int GetInstance(string isbn)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var book = context.BookInformations.FirstOrDefault(b => b.ISBN == isbn);

                var instance = book.BookInstances.FirstOrDefault(i => i.InCirculation == true && (i.Borrows.Count == 0 || (i.Borrows.Last().BorrowState == Constants.Borrow.REJECTED_STATE || i.Borrows.Last().BorrowState == Constants.Borrow.RETURNED_STATE)));
                return instance.InstanceID;
            }
        }

        public static int GetBorrowerUserID(string email)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
                return user.UserID;
            }
        }

        public static void AddBorrowRecord(Borrow record)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                context.Borrows.Add(record);
                context.SaveChanges();
            }
        }
    }
}