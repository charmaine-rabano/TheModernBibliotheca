using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class ReportOnshelfRepository
    {
        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }

        public static IEnumerable<ReportOnshelfModel> GetBooks()
        {
            var context = CreateDbContext();
            return context.Books.Where(e => e.BookStatus == "Onshelf").Select(e => new ReportOnshelfModel
            {
                InstanceID = e.InstanceID,
                ISBN = e.ISBN,
                Title = e.BookInformation.Title,
                Genre = e.BookInformation.Genre,
                Author = e.BookInformation.Author
               
            }).ToList();
        }

        public static IEnumerable<ReportOnshelfModel> GetSpecificGenre(string specificGenre)
        {
            var context = CreateDbContext();
            return context.Books.Where(e => e.BookInformation.Genre == specificGenre && e.BookStatus == "Onshelf").Select(e => new ReportOnshelfModel
            {
                InstanceID = e.InstanceID,
                ISBN = e.ISBN,
                Title = e.BookInformation.Title,
                Genre = e.BookInformation.Genre,
                Author = e.BookInformation.Author
            }).ToList();
        }
    }
}