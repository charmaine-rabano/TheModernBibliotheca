using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.Model
{
    public static class Constants
    {
        public static class Violation
        {
            const string DAMAGE_TYPE = "Damaged";
            const string LATE_TYPE = "Late";
            const string LOST_TYPE = "Lost";
        }

        public static class Borrow
        {
            const string ONSITE_SITE_TYPE = "Onsite";
            const string OFFSITE_SITE_TYPE = "Offsite";

            const string REQUESTED_STATE = "Requested";
            const string APPROVED_STATE = "Approved";
            const string REJECTED_STATE = "Rejected";
            const string BORROWED_STATE = "Borrowed";
        }

        public static class LibraryUser
        {
            const string LIBRARIAN_TYPE = "Librarian";
            const string ADMIN_TYPE = "Admin";
            const string BORROWER_TYPE = "Borrower";

        }


    }
}