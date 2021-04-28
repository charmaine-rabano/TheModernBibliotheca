using System.Web;
using TheModernBibliotheca._Code.Auth;

namespace TheModernBibliotheca._Code.Helper.Auth
{
    public static class AuthHelper
    {
        public const string ADMIN_USER_TYPE = "Admin";
        public const string LIBRARIAN_USER_TYPE = "Admin";
        public const string BORROWER_USER_TYPE = "Admin";
        public const string GUEST_USER_TYPE = "Admin";



        private const string SESSION_ID = "UserSession";
        public static bool Login(string email, string password) {
            string sessionId = AuthService.Authenticate(email, password);
            if (sessionId == "") { return false; }

            HttpContext.Current.Session[SESSION_ID] = sessionId;
            return true;
        }

        public static LoggedInUser GetUser()
        {
            string sessionId = (string) HttpContext.Current.Session[SESSION_ID];
            if (sessionId == null) { return null; }

            return AuthService.SessionInformation(sessionId);
        }

        public static bool IsLoggedIn()
        {
            return GetUser() != null;
        }

        public static void Logout()
        {
            HttpContext.Current.Session[SESSION_ID] = "";
        }
    }

}