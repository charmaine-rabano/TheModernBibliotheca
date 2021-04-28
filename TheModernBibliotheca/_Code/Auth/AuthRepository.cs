using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.Auth
{
    public class AuthRepository
    {
        internal static bool TryValidateCredentials(string email, string password, out int userId)
        {
            string query = "SELECT UserId FROM LibraryUser WHERE Email = @Email and Password = @Password";
            object val = DbHelper.ExecuteScalar(query, ("Email", email), ("Password", password));
            if (val == DBNull.Value)
            {
                userId = -1;
                return false;
            }

            userId = (int) val;
            return true;
        }

        internal static LoggedInUser GetSessionInformation(string sessionId)
        {
            string query = "SELECT Email, UserType, UserId, SessionExpiry FROM LibraryUser WHERE SessionId = @SessionId";
            var result = DbHelper.ExecuteDataTableQuery(query, ("SessionId", sessionId));
            
            // Make sure session is found
            if(result.Rows.Count == 0) { return null; }

            // Make sure session is not expired
            var item = result.Rows[0];
            DateTime sessionExpiry = (DateTime) item["SessionExpiry"];
            if (sessionExpiry > DateTime.Now) { return null; }
            
            // Create logged in user
            return new LoggedInUser(
                (string) item["UserId"], 
                (string) item["Email"], 
                (string) item["UserType"]);
        }

        internal static void CreateUserSession(int userId, string sessionId)
        {
            string query = "UPDATE LibraryUser SET SessionId = @SessionId WHERE UserId = @UserId;";
            DbHelper.ExecuteNonQuery(query, ("SessionId", sessionId), ("UserId", userId));
        }
    }
}