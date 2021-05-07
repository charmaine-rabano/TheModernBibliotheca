using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;
namespace TheModernBibliotheca._Code.App.Admin
{
    public static class UsersRepository
    {

        public static IEnumerable<LibraryUser> GetUsers()
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.ToList();
        }

        public static LibraryUser GetUser(int id)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.LibraryUsers.FirstOrDefault(e => e.UserID == id); ;
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
                var user = context.LibraryUsers.FirstOrDefault(e => e.UserID == userId);

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

                context.LibraryUsers.Remove(libraryUser);
                context.SaveChanges();
            }
        }

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
    }
}