using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.Lib.Logging
{
    public class LoggingService
    {
        public static void Log(LibraryUser user, string remarks)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                context.UserActivities.Add(new UserActivity
                {
                    UserID = user.UserID,
                    Remarks = remarks,
                    TransactionDate = DateTime.Now
                });
                context.SaveChanges();
            }
        }
    }
}