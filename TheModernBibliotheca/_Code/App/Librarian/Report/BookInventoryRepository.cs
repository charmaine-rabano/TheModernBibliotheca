using System;
using System.Collections.Generic;
using System.Linq;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Report
{
    internal class BookInventoryRepository
    {
        internal static IEnumerable<BookInventoryReport> GetBookInventory()
        {
            var state = new List<string> { Constants.Borrow.RETURNED_STATE, Constants.Borrow.REJECTED_STATE };
            using (var context = new TheModernDatabaseEntities()) {
                return context.BookInformations
                    .OrderBy(e => e.Title)
                    .Select(e => new BookInventoryReport {
                        Author = e.Author,
                        AvailableQuantity = e.BookInstances.Where(f =>
                            f.InCirculation &&                  // Instance must be incirculation
                            (
                                f.Borrows.Count == 0 ||         // Instance not borrowed yet
                                state.Contains(f.Borrows.OrderByDescending(g => g.DateCreated)
                                    .FirstOrDefault()
                                        .BorrowState)           // Borrow is returned or rejected
                            )).Count(),
                        Title = e.Title,
                        InCirculation = e.BookInstances.Count(f=>f.InCirculation),
                        Isbn = e.ISBN,
                        TotalQuantity = e.BookInstances.Count()

                    })
                    .ToList();
            }
        }

        internal static object GetBookInventoryByGenre(string genre)
        {
            var state = new List<string> { Constants.Borrow.RETURNED_STATE, Constants.Borrow.REJECTED_STATE };
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInformations
                    .Where(e=>e.Genre.ToLower() == genre.ToLower())
                    .OrderBy(e => e.Title)
                    .Select(e => new BookInventoryReport
                    {
                        Author = e.Author,
                        AvailableQuantity = e.BookInstances.Where(f =>
                            f.InCirculation &&                  // Instance must be incirculation
                            (
                                f.Borrows.Count == 0 ||         // Instance not borrowed yet
                                state.Contains(f.Borrows.OrderByDescending(g => g.DateCreated)
                                    .FirstOrDefault()
                                        .BorrowState)           // Borrow is returned or rejected
                            )).Count(),
                        Title = e.Title,
                        InCirculation = e.BookInstances.Count(f => f.InCirculation),
                        Isbn = e.ISBN,
                        TotalQuantity = e.BookInstances.Count()

                    })
                    .ToList();
            }
        }
    }
}