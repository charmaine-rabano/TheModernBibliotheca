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
            public const string DAMAGE_TYPE = "Damaged";
            public const string LATE_TYPE = "Late";
            public const string LOST_TYPE = "Lost";
        }

        public static class Borrow
        {
            public const string ONSITE_SITE_TYPE = "Onsite";
            public const string OFFSITE_SITE_TYPE = "Offsite";

            public const string REQUESTED_STATE = "Requested";
            public const string APPROVED_STATE = "Approved";
            public const string REJECTED_STATE = "Rejected";
            public const string BORROWED_STATE = "Borrowed";
        }

        public static class LibraryUser
        {
            public const string LIBRARIAN_TYPE = "Librarian";
            public const string ADMIN_TYPE = "Admin";
            public const string BORROWER_TYPE = "Borrower";

            public const string ACTIVE_STATUS = "Active";
            public const string DEACTIVATED_STATUS = "Deactivated";


        }


    }
}