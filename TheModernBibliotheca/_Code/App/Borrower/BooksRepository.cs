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

        public static IEnumerable<BookInformation> GetSearchedBooks(string searchText)
        {
            searchText = searchText.ToLower();
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.Where(e => e.Title.ToLower().Contains(searchText)).ToList();
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