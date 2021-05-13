using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class ReportInCirculationRepository
    {
        public static IEnumerable<ReportViewModel> GetBooks()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Where(e => e.InCirculation).Select(e => new ReportViewModel
                {
                    InstanceID = e.InstanceID,
                    ISBN = e.ISBN,
                    Title = e.BookInformation.Title,
                    Genre = e.BookInformation.Genre,
                    Author = e.BookInformation.Author

                }).ToList();
            }
        }

        public static IEnumerable<ReportViewModel> GetSpecificGenre(string specificGenre)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Where(e => e.BookInformation.Genre == specificGenre && e.InCirculation).Select(e => new ReportViewModel
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
}