using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.Auth
{
    public class LoggedInUser
    {
        public LoggedInUser(string userId, string email, string userType)
        {
            UserId = userId;
            Email = email;
            UserType = userType;
        }

        public string UserId { get; private set; }
        public string Email { get; private set; }
        public string UserType { get; private set; }
    }
}