using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.Lib.Authentication
{
    public class AuthenticationService
    {
        public static bool IsValidSession(string sessionId)
        {
            return GetUser(sessionId) != null;
        }

        public static LibraryUser GetUser(string sessionId)
        {
            using (var context = new TheModernDatabaseEntities())
                return context
                    .LibraryUsers
                    .Where(e => e.SessionId == sessionId && e.SessionExpiry > DateTime.Now)
                    .FirstOrDefault();
        }

        public static bool TryAuthenticateUser(string email, string password, string userType, out string sessionId)
        {
            sessionId = null;
            email = email.ToLower();
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context
                        .LibraryUsers
                        .Where(e => e.Email.ToLower() == email && e.AccountPassword == password && e.UserType == userType)
                        .FirstOrDefault();

                // If user didn't find user, then user is invalid, 
                if (user == null) { return false; }

                sessionId = CreateSessionId();
                var expiryDate = DateTime.Now.AddHours(5);

                user.SessionId = sessionId;
                user.SessionExpiry = expiryDate;

                context.SaveChanges();

                return true;
            }
        }

        public static void ClearSession(int userId)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var user = context
                        .LibraryUsers
                        .Where(e => e.UserID == userId)
                        .FirstOrDefault();
                user.SessionExpiry = null;
                user.SessionId = null;
                context.SaveChanges();
            }
        }

        private static string CreateSessionId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}