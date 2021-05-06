using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class GenreRepository
    {
        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }

        public static IEnumerable<GenreModel> GetGenres()
        {
            var context = CreateDbContext();

            return context.BookInformations.Select(e => new GenreModel
            {
                Genre = e.Genre

            }).ToList();
        }
    }
}
