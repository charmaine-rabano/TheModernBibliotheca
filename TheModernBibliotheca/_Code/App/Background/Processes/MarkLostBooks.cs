using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Background
{
    public class MarkLostBooks : IBackgroundProcess
    {
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        const int DAYS_FOR_LOST = 10;
        public void Run()
        {
            DateTime lost_start = DateTime.Now.AddDays(-DAYS_FOR_LOST);
            using (var context = new TheModernDatabaseEntities())
            {
                var borrows = context.Borrows.Where(borrow =>
                    borrow.BorrowState == Constants.Borrow.BORROWED_STATE &&         // Book must be borrowed
                    lost_start >= borrow.ReturnDate &&             // Date now must be past 90 days since borrowed
                    borrow.BookInstance.InCirculation
                    )
                    .ToList();
                borrows.ForEach(e =>
                {
                    e.BookInstance.InCirculation = false;
                    context.Violations.Add(new Violation() { 
                        BorrowID = e.BorrowID,
                        ViolationType = Constants.Violation.LOST_TYPE,
                    });
                });

                context.SaveChanges();
                LogChanges(lost_start, borrows);
            }
        }

        private void LogChanges(DateTime lost_start, List<Borrow> borrows)
        {
            int count = borrows.Count;
            if (count > 0)
            {
                string books = borrows.Aggregate(new StringBuilder(),
                    (builder, item) => builder
                    .AppendFormat(
                        "BorrowId: {0}, InstanceId: {1}, DateBorrowed: {2}; ", item.BorrowID,
                        item.BookInstance.InstanceID, item.DateBorrowed)).ToString();

                string message = $"Marked {count} books on {lost_start} as lost: {books}";
                log.Debug(message);
            }
        }
    }
}