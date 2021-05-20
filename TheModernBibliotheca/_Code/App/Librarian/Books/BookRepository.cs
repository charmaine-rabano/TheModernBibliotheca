using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;
using Azure.Storage.Blobs;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class BookRepository
    {
        public static BookInformation GetBook(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.FirstOrDefault(e => e.ISBN == ISBN);
        }


        public static void ModifyBook(string ISBN, BookInformation modifiedBook)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var book = context.BookInformations.FirstOrDefault(e => e.ISBN == ISBN);

                if (book == null) throw new InvalidOperationException("Invalid ISBN");

                book.Title = modifiedBook.Title;
                book.Genre = modifiedBook.Genre;
                book.Author = modifiedBook.Author;
                book.Summary = modifiedBook.Summary;
                book.BookCover = modifiedBook.BookCover;
                
                context.SaveChanges();
            }
        }

    }
}