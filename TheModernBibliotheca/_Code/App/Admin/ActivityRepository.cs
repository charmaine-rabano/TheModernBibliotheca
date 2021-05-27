using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Admin
{
    public static class ActivityRepository
    {
        public static IEnumerable<ActivityViewModel> GetActivities()
        {
            using (var context = new TheModernDatabaseEntities())
                return context.UserActivities.Select(e => new ActivityViewModel
                {
                    Email = e.LibraryUser.Email,
                    Description = e.Remarks,
                    TimeStamp = e.TransactionDate,
                    UserType = e.LibraryUser.UserType
                }).OrderByDescending(e=>e.TimeStamp).ToList();
        }
    }
}