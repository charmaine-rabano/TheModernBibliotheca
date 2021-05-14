using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian
{
    public class GenreRepository
    {
        public static IEnumerable<GenreViewModel> GetGenres()
        {             
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInformations.Select(e => new GenreViewModel
                {
                    Genre = e.Genre
                }).Distinct().ToList();
            }
        }
    }
}
