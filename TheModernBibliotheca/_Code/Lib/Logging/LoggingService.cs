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
         * Admin.Users.Add.SubmitBtn_Click
         * Admin.Users.Modify.SubmitBtn_Click
         * Admin.Users.Modify.DeleteBtn_Click
         * Librarian.Books.Book.btnSave_Click
         * Librarian.Books.Add.btnAddBook_Click
         * Librarian.Books.Instances.btnAdd_Click
         * Librarian.Books.Instances.gvInCirculation_RowCommand
         * Librarian.Books.Instances.gvNotInCirculation_RowCommand
         * Librarian.Offsite.Approve.ApproveGV_RowCommand
         * Librarian.Borrows.Offsite.Pending.PendingGV_RowCommand
         * Librarian.Borrows.Onsite.Borrow.RecordBtn_Click
         * Librarian.Borrows.Onsite.Create.CreateBtn_Click
         * Librarian.Borrows.ConfrimReturn.ConfirmBtn_Click
         * Librarian.Borrows.Return.ReturnGV_RowCommand
         * AccountDetails.SaveNameBtn_Click
         * AccountDetails.SavePasswordBtn_Click
         * AccountDetails.ConfirmDeactivate_Click
         * Books.btnCreateReservation_Click
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