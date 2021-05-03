using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;
namespace TheModernBibliotheca.Admin.Accounts
{
    public static class UsersRepository
    {
        private static TheModernDatabaseEntities CreateDbContext()
        {
            return new TheModernDatabaseEntities();
        }

        public static IEnumerable<LibraryUser> GetUsers()
        {
            IEnumerable<LibraryUser> users = null;
            var context = CreateDbContext();
            users = context.LibraryUsers;
            return users.ToList();

        }

        public static LibraryUser GetUser(int id)
        {
            LibraryUser user = null;
            var context = CreateDbContext();
            user = context.LibraryUsers.FirstOrDefault(e => e.UserID == id);
            return user;
        }

        public static void AddAccount(LibraryUser account)
        {
            var context = CreateDbContext();
            context.LibraryUsers.Add(account);
            context.SaveChanges();
        }


        public static void ModifyAccount(int userId, LibraryUser modifiedUser, bool passwordChanged)
        {
            var context = CreateDbContext();
            var user = context.LibraryUsers.FirstOrDefault(e=>e.UserID == userId);

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

        public static void DeleteAccount(int userId)
        {
            var context = CreateDbContext();
            
            LibraryUser libraryUser = context.LibraryUsers.Find(userId);
            
            if (libraryUser == null) throw new Exception("Invalid user id");

            context.LibraryUsers.Remove(libraryUser);
            context.SaveChanges();
        }

        internal static bool IsEmailUnique(string email)
        {
            var context = CreateDbContext();
            return context.LibraryUsers.Any(e => e.Email.ToLower() == email.ToLower());
        }

        internal static bool IsEmailUniqueExceptSelf(int id, string email)
        {
            var context = CreateDbContext();
            return context.LibraryUsers.Any(e => e.Email.ToLower() == email.ToLower() && e.UserID != id);
        }
    }
}