using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class ManageBooksRepository
    {
        public static IEnumerable<ManageBooksViewModel> GetBooks()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInformations.Select(e => new ManageBooksViewModel
                {
                    ISBN = e.ISBN,
                    Title = e.Title,
                    BookCover = e.BookCover,
                    Summary = e.BookCover,
                }).ToList();
            }

           
        }
    }
}