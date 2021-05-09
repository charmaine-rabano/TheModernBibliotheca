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
            // var context = CreateDbContext();
            return null;
        }

        internal static BookInformation GetBook(string ISBN)
        {
            var context = CreateDbContext();
            return context.BookInformations.FirstOrDefault(e => e.ISBN == ISBN);
        }

        public static IEnumerable<BookInformation> GetBooks()
        {
            var context = CreateDbContext();
            return context.BookInformations.ToList();
        }

        public static IEnumerable<BookInformation> GetSearchedBooks(string searchText)
        {
            searchText = searchText.ToLower();
            var context = CreateDbContext();
            return context.BookInformations.Where(e => e.Title.ToLower().Contains(searchText)).ToList();
        }

        public static IEnumerable<BookInformation> GetAvailableBooks(bool statusText)
        {
            var context = CreateDbContext();
            return context.BookInformations.Where(e => e.BookInstances.Any(f => f.InCirculation == statusText)).ToList();
        }

        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }
    }
}