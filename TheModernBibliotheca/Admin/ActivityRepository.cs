using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Admin
{
    public static class ActivityRepository
    {
        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }
        public static IEnumerable<ActivityViewModel> GetActivities()
        {
            var context = CreateDbContext();
            return context.UserActivities.Select( e => new ActivityViewModel {
                Email = e.LibraryUser.Email,
                Description = e.Remarks,
                TimeStamp = e.TransactionDate,
                UserType = e.LibraryUser.UserType
            }).ToList();
        }
    }
}