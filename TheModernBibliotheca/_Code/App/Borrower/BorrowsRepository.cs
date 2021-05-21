using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Borrower
{
    public class BorrowsRepository
    {
        public static CurrentBorrowViewModel GetCurrentlyBorrowedModel(int userId)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.Borrows
                    .Where(e => e.UserID == userId)
                    .OrderByDescending(e => e.DateCreated).
                    Select(e => new CurrentBorrowViewModel()
                    {
                        Author = e.BookInstance.BookInformation.Author,
                        Summary = e.BookInstance.BookInformation.Summary,
                        Title = e.BookInstance.BookInformation.Title,
                        Isbn = e.BookInstance.BookInformation.ISBN,
                        Image = e.BookInstance.BookInformation.BookCover,
                        ReturnDate = (DateTime)e.ReturnDate,
                        Status = e.BorrowState,
                        Genre = e.BookInstance.BookInformation.Genre
                    })
                    .FirstOrDefault();

        }



        internal static IEnumerable<BorrowHistoryItemModel> GetBorrowsHistory(int userId)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.Borrows
                   .Where(e => e.UserID == userId && (
                        e.BorrowState == Constants.Borrow.RETURNED_STATE))
                    .OrderByDescending(e => e.DateBorrowed)
                    .Select(e => new BorrowHistoryItemModel()
                    {
                        Author = e.BookInstance.BookInformation.Author,
                        DateBorrowed = (DateTime) e.DateBorrowed,
                        DateReturned = (DateTime) e.DateReturned,
                        Isbn = e.BookInstance.BookInformation.ISBN,
                        Title = e.BookInstance.BookInformation.Title
                    })
                    .ToList();

        }

        /*
         * DUMMY DATA
         *  {
                    Author = "Job Lipat",
                    Blurb = "Hello World",
                    Title = "Lord of the Rings",
                    Isbn = "ABCDE",
                    Image = @"https://vignette.wikia.nocookie.net/lotr/images/d/db/51eq24cRtRL._SX331_BO1%2C204%2C203%2C200_.jpg/revision/latest?cb=20190723164240",
                    ReturnDate = DateTime.Now,
                    Status = "Borrowed",
                    StatusDate = DateTime.Now
                };

          return new List<BorrowHistoryItemModel>()
        {
            new BorrowHistoryItemModel(){
                Author ="",
                DateBorrowed = DateTime.Now,
                DateReturned = DateTime.Now,
                Isbn = "",
                Title = ""
            }
        };
         */
    }
}