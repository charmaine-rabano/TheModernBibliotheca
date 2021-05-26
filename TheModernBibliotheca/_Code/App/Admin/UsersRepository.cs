using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Lib.Logging;
using TheModernBibliotheca._Code.Model;
namespace TheModernBibliotheca._Code.App.Admin
{
    public static class UsersRepository
    {

        public static IEnumerable<LibraryUser> GetUsers(int loggedInUserId)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers
                    .Where(e => 
                        e.AccountStatus == Constants.LibraryUser.ACTIVE_STATUS &&
                        e.UserID != loggedInUserId)
                    .OrderByDescending(e=>e.DateCreated)
                    .ToList();
        }

        public static LibraryUser GetUser(int id)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.FirstOrDefault(e => e.UserID == id && e.AccountStatus != Constants.LibraryUser.DEACTIVATED_STATUS);
        }

        public static void AddAccount(LibraryUser account)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                context.LibraryUsers.Add(account);
                context.SaveChanges();
            }
        }

        public static void ModifyAccount(int userId, LibraryUser modifiedUser, bool passwordChanged)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context.LibraryUsers.FirstOrDefault(e => e.UserID == userId && e.AccountStatus != Constants.LibraryUser.DEACTIVATED_STATUS);

                if (user == null) throw new InvalidOperationException("Invalid user id");

                user.FirstName = modifiedUser.FirstName;
                user.LastName = modifiedUser.LastName;
                user.Email = modifiedUser.Email;
                user.UserType = modifiedUser.UserType;

                if (passwordChanged)
                {
                    user.AccountPassword = modifiedUser.AccountPassword;
                }

                context.SaveChanges();
            }
        }

        public static void DeleteAccount(int userId)
        {
            using (var context = new TheModernDatabaseEntities())
            {

                LibraryUser libraryUser = context.LibraryUsers.Find(userId);

                if (libraryUser == null) throw new Exception("Invalid user id");

                libraryUser.AccountStatus = Constants.LibraryUser.DEACTIVATED_STATUS;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Will still check if email has been used in deactivated accounts
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        internal static bool IsEmailUnique(string email)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.Any(e => e.Email.ToLower() == email.ToLower());
        }

        internal static bool IsEmailUniqueExceptSelf(int id, string email)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.Any(e => e.Email.ToLower() == email.ToLower() && e.UserID != id);
        }

        public static bool IsCurrentPassword(int id, string password)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.Where(e => e.UserID == id).FirstOrDefault().AccountPassword == password;
        }
    }
}