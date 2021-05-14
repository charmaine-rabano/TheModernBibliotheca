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
        public static IEnumerable<ManageBooksViewModel> GetSpecificGenre(string specificGenre)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInformations.Where(e => e.Genre == specificGenre).Select(e => new ManageBooksViewModel
                {
                    ISBN = e.ISBN,
                    Title = e.Title,
                    BookCover = e.BookCover,
                    Summary = e.BookCover
                }).ToList();
            }
        }
        public static IEnumerable<ManageBooksViewModel> GetSearchedBooks(string searchText)
        {
            searchText = searchText.ToLower();
            using (var context = new TheModernDatabaseEntities())
            {
                
                return (IEnumerable<ManageBooksViewModel>)context.BookInformations.Where(e => e.Title.ToLower().Contains(searchText)).ToList();
            }   
        }
    }
}