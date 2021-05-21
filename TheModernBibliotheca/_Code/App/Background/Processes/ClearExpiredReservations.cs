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
    public class ClearExpiredReservations : IBackgroundProcess
    {
        const int DAYS_FOR_EXPIRED = 7;

        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Run()
        {
            DateTime expiry_start = DateTime.Now.AddDays(-DAYS_FOR_EXPIRED);
            using (var context = new TheModernDatabaseEntities())
            {
                var borrows = context.Borrows.Where(borrow =>
                    borrow.BorrowState == Constants.Borrow.REQUESTED_STATE &&
                    expiry_start >= borrow.DateBorrowed)
                    .ToList();
                borrows.ForEach(e =>
                {
                    e.BorrowState = Constants.Borrow.REJECTED_STATE;
                });
                context.SaveChanges();

                LogChanges(borrows);
            }
        }

        private void LogChanges(List<Borrow> borrows)
        {
            int count = borrows.Count;
            if (count > 0)
            {
                string books = borrows.Aggregate(new StringBuilder(),
                    (builder, item) => builder
                    .AppendFormat("BorrowId: {0}, InstanceId: {1}, DateReserved: {2}; ",
                    item.BorrowID, item.BookInstance.InstanceID, item.Reservation.DateReserved)).ToString();
                string message = $"Cleared {count} reservations that were expired: {books}";
                log.Debug(message);
            }
        }
    }
}