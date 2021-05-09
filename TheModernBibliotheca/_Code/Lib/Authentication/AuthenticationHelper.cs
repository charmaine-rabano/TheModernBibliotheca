using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.Lib.Authentication
{

    public class AuthenticationHelper
    {
        private static AuthenticationHelper BorrowerAuthHelper;
        private static AuthenticationHelper LibarianAuthHelper;
        private static AuthenticationHelper AdminAuthHelper;

        public static AuthenticationHelper GetBorrowerAuth()
        {
            if (BorrowerAuthHelper == null) {
                BorrowerAuthHelper = new AuthenticationHelper(Constants.LibraryUser.BORROWER_TYPE);
            }
            return BorrowerAuthHelper;
        }

        public static AuthenticationHelper GetLibrarianAuth()
        {
            if (LibarianAuthHelper == null)
            {
                LibarianAuthHelper = new AuthenticationHelper(Constants.LibraryUser.LIBRARIAN_TYPE);
            }
            return LibarianAuthHelper;
        }

        public static AuthenticationHelper GetAdminAuth()
        {
            if (AdminAuthHelper == null)
            {
                AdminAuthHelper = new AuthenticationHelper(Constants.LibraryUser.ADMIN_TYPE);
            }
            return AdminAuthHelper;
        }

        readonly string UserType;

        readonly string SESSION_ID_KEY;

        private AuthenticationHelper(string userType)
        {
            UserType = userType;
            SESSION_ID_KEY = userType + "SESSION_ID_KEY";
        }

        private string SessionId
        {
            get
            {
                object sessionId = HttpContext.Current.Session[SESSION_ID_KEY];

                return sessionId == null ? null : (string)sessionId;
            }
            set
            {
                HttpContext.Current.Session[SESSION_ID_KEY] = value;
            }
        }


        public LibraryUser GetUser()
        {
            return AuthenticationService.GetUser(SessionId);
        }

        public bool Authenticate(string email, string password)
        {
            if (!AuthenticationService.TryAuthenticateUser(email, password, UserType, out string sessionId))
            {
                return false;
            }

            SessionId = sessionId;
            return true;
        }

        public bool IsLoggedIn()
        {
            return AuthenticationService.IsValidSession(SessionId);
        }

        public void Signout()
        {
            AuthenticationService.ClearSession(GetUser().UserID);
        }
    }
}