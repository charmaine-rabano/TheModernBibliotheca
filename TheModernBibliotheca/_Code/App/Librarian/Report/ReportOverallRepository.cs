using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class ReportOverallRepository
    {
     
        public static IEnumerable<ReportViewModel> GetBooks()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Select(e => new ReportViewModel
                {
                    InstanceID = e.InstanceID,
                    ISBN = e.ISBN,
                    Title = e.BookInformation.Title,
                    Genre = e.BookInformation.Genre,
                    Author = e.BookInformation.Author,
                    Status = e.InCirculation ? "In Circulation" : "Not In Circulation"
                }).ToList();
            }
        }

        public static IEnumerable<ReportViewModel> GetSpecificGenre(string specificGenre)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Where(e => e.BookInformation.Genre == specificGenre).Select(e => new ReportViewModel
                {
                    InstanceID = e.InstanceID,
                    ISBN = e.ISBN,
                    Title = e.BookInformation.Title,
                    Genre = e.BookInformation.Genre,
                    Author = e.BookInformation.Author,
                    Status = e.InCirculation ? "In Circulation" : "Not In Circulation"
                }).ToList();
            }
            
        }

    }
}