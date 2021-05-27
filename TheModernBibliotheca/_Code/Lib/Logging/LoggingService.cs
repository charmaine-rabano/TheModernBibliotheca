using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.Lib.Logging
{
    public class LoggingService
    {
        /*
         * Admin.Users.Add.SubmitBtn_Click [Working]
         * Admin.Users.Modify.SubmitBtn_Click [Working]
         * Admin.Users.Modify.DeleteBtn_Click [Working]
         * Librarian.Books.Book.btnSave_Click [Working]
         * Librarian.Books.Add.btnAddBook_Click [Working]
         * Librarian.Books.Instances.btnAdd_Click [Working]
         * Librarian.Books.Instances.gvInCirculation_RowCommand [Working]
         * Librarian.Books.Instances.gvNotInCirculation_RowCommand [Working]
         * Librarian.Offsite.Approve.ApproveGV_RowCommand [Working]
         * Librarian.Borrows.Offsite.Pending.PendingGV_RowCommand [Working]
         * Librarian.Borrows.Onsite.Borrow.RecordBtn_Click [Working]
         * Librarian.Borrows.Onsite.Create.CreateBtn_Click [Working]
         * Librarian.Borrows.ConfrimReturn.ConfirmBtn_Click [Working]
         * Librarian.Borrows.Return.ReturnGV_RowCommand [Working]
         * AccountDetails.SaveNameBtn_Click
         * AccountDetails.SavePasswordBtn_Click
         * AccountDetails.ConfirmDeactivate_Click
         * Books.btnCreateReservation_Click [Working]
         * CreateAccount.CreateBtn_Click
         */
        public static void Log(LibraryUser user, string remarks)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                context.UserActivities.Add(new UserActivity
                {
                    UserID = user.UserID,
                    Remarks = remarks,
                    TransactionDate = DateTime.Now
                });
                context.SaveChanges();
            }
        }
    }
}