using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Borrower
{
    public class BooksRepository
    {
        internal static string GetStatus(string ISBN)
        {
            return null;
        }

        internal static BookInformation GetBook(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.FirstOrDefault(e => e.ISBN == ISBN);
        }

        public static IEnumerable<BookInformation> GetBooks()
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.ToList();
        }

        public static IEnumerable<BookInformation> SearchBooks(string searchText)
        {
            searchText = searchText.ToLower();
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.Where(e => e.Title.ToLower().Contains(searchText)).ToList();
        }

        internal static bool CanUserBorrow(int userID)
        {
            var state = new List<string> { Constants.Borrow.RETURNED_STATE, Constants.Borrow.REJECTED_STATE };

            using (var context = new TheModernDatabaseEntities())
            {
                var borrows = context.LibraryUsers.First(e => e.UserID == userID).Borrows.OrderByDescending(e => e.DateCreated);

                if (borrows.Count() == 0) { return true; }

                return state.Contains(borrows.First().BorrowState);
            }
        }

        public static IEnumerable<BookInformation> GetAvailableBooks()
        {
            var state = new List<string> { Constants.Borrow.RETURNED_STATE, Constants.Borrow.REJECTED_STATE };

            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations
                    .Where(e =>
                        e.BookInstances.Count > 0 &&                // Must have instance
                        e.BookInstances
                            .Any(f =>
                                f.InCirculation &&                  // Instance must be incirculation
                                (
                                    f.Borrows.Count == 0 ||         // Instance not borrowed yet
                                    state.Contains(f.Borrows.OrderByDescending(g => g.DateCreated)
                                        .FirstOrDefault()
                                            .BorrowState)           // Borrow is returned or rejected
                                )))
                    .ToList();
        }

        internal static IEnumerable<BookInformation> SearchUnavailableBooks(string searchKey)
        {
            searchKey = searchKey.ToLower();
            return GetUnavailableBooks().Where(e => e.Title.ToLower().Contains(searchKey));
        }

        internal static IEnumerable<BookInformation> SearchAvailableBooks(string searchKey)
        {
            searchKey = searchKey.ToLower();
            return GetAvailableBooks().Where(e => e.Title.ToLower().Contains(searchKey));
        }

        public static IEnumerable<BookInformation> GetUnavailableBooks()
        {
            var state = new List<string> { Constants.Borrow.RETURNED_STATE, Constants.Borrow.REJECTED_STATE };

            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations
                    .Where(e =>
                        !(e.BookInstances.Count > 0 &&                // Must have instance
                        e.BookInstances
                            .Any(f =>
                                f.InCirculation &&                  // Instance must be incirculation
                                (
                                    f.Borrows.Count == 0 ||         // Instance not borrowed yet
                                    state.Contains(f.Borrows.OrderByDescending(g => g.DateCreated)
                                        .FirstOrDefault()
                                            .BorrowState)           // Borrow is returned or rejected
                                ))))
                    .ToList();
        }

        public static bool IsBookAvailable(string ISBN)
        {
            return GetQuantity(ISBN) > 0;
        }

        public static int GetQuantity(string ISBN)
        {
            var state = new List<string> { Constants.Borrow.RETURNED_STATE, Constants.Borrow.REJECTED_STATE };
            using (var context = new TheModernDatabaseEntities())
                return context.BookInstances
                    .Where(e => e.ISBN == ISBN)
                    .Where(e =>
                            e.InCirculation &&                  // Instance must be incirculation
                            (
                                e.Borrows.Count == 0 ||         // Instance not borrowed yet
                                state.Contains(e.Borrows.OrderByDescending(f => f.DateCreated)
                                    .FirstOrDefault()
                                        .BorrowState)           // Borrow is returned or rejected
                            ))
                    .Count();
        }

    }
}