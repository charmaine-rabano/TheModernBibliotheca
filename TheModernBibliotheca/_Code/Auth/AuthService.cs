using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.Auth
{
    public static class AuthService
    {
        public static string Authenticate(string email, string password) {
            if (!AuthRepository.TryValidateCredentials(email, password, out int userId)) return "";

            string sessionId = Guid.NewGuid().ToString();
            AuthRepository.CreateUserSession(userId, sessionId);
            return sessionId;
        }

        public static LoggedInUser SessionInformation(string token)
        {
            return AuthRepository.GetSessionInformation(token);
        }
    }
}