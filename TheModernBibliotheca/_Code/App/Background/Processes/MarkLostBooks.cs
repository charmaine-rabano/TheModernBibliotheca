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
                    lost_start >= borrow.DateBorrowed // Date now must be past 90 days since borrowed
                    )
                    .ToList();
                borrows.ForEach(e =>
                {
                    e.BookInstance.InCirculation = false;
                });

                context.SaveChanges();
                int count = borrows.Count;
                if (count > 0)
                {
                    string books = borrows.Aggregate(new StringBuilder(),
                        (builder, item) => builder
                        .AppendFormat("BorrowId: {0}, InstanceId: {1}, DateBorrowd: {2}; ",
                        item.BorrowID, item.BookInstance.InstanceID, item.DateBorrowed)).ToString();

                    log.Debug($"Marked {count} books on {lost_start} as lost: {books}");
                }
            }

        }
    }
}