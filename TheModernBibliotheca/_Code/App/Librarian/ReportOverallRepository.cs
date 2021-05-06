using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class ReportOverallRepository
    {
        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }

        public static IEnumerable<ReportOverallModel> GetBooks()
        {
            var context = CreateDbContext();
            return context.Books.Select(e => new ReportOverallModel
            {
                InstanceID = e.InstanceID,
                ISBN = e.ISBN,
                Title = e.BookInformation.Title,
                Genre = e.BookInformation.Genre,
                Author = e.BookInformation.Author,
                Status = e.BookStatus
            }).ToList();
        }

        public static IEnumerable<ReportOverallModel> GetSpecificGenre(string specificGenre)
        {
            var context = CreateDbContext();
            return context.Books.Where(e => e.BookInformation.Genre == specificGenre).Select(e => new ReportOverallModel
            {
                InstanceID = e.InstanceID,
                ISBN = e.ISBN,
                Title = e.BookInformation.Title,
                Genre = e.BookInformation.Genre,
                Author = e.BookInformation.Author,
                Status = e.BookStatus
            }).ToList();
        }

    }
}