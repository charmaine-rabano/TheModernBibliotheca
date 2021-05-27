using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;
using Azure.Storage.Blobs;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class AddBookRepository
    {
        public static void AddBook(BookInformation book)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                context.BookInformations.Add(book);
                context.SaveChanges();
            }
        }

        public static void AddBookInstance(int qty, BookInstance instance)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                for (int i = 0; i < qty; i++)
                {
                    context.BookInstances.Add(instance);
                    context.SaveChanges();
                }
            }
        }
        internal static bool IsISBNUnique(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.Any(e => e.ISBN == ISBN);
        }
        
        
    }
}