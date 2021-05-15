﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Borrower
{
    public class BorrowerRepository
    {
        public static void ModifyName(int userId, LibraryUser modifiedUser, bool passwordChanged)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.FirstOrDefault(e => e.UserID == userId && e.AccountStatus != Constants.LibraryUser.DEACTIVATED_STATUS);

                if (user == null) throw new InvalidOperationException("Invalid User ID");

                user.FirstName = modifiedUser.FirstName;
                user.LastName = modifiedUser.LastName;

                if (passwordChanged)
                {
                    user.AccountPassword = modifiedUser.AccountPassword;
                }

                context.SaveChanges();
            }
        }

        public static void ModifyPassword(int userId, LibraryUser modifiedUser, bool passwordChanged)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.FirstOrDefault(e => e.UserID == userId && e.AccountStatus != Constants.LibraryUser.DEACTIVATED_STATUS);

                if (passwordChanged)
                {
                    user.AccountPassword = modifiedUser.AccountPassword;
                }

                context.SaveChanges();
            }
        }
    }
}