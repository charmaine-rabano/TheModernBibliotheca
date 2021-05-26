using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Borrows;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Librarian.Borrows.Onsite
{
    public partial class Borrow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            if (!Page.IsPostBack)
            {
                SuccessAlert.Visible = false;
                BorrowDateTb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BookISBNCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (!BookExists(BookISBNTb.Text))
            {
                validator.Text = "Book ISBN in invalid.";
                args.IsValid = false;
            }
            else if (!IsBookAvailable(BookISBNTb.Text))
            {
                validator.Text = "Book is not available for borrowing.";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        private bool BookExists(string isbn)
        {
            return BorrowRepository.BookExists(isbn);
        }

        private bool IsBookAvailable(string isbn)
        {
            return BorrowRepository.IsBookAvailable(isbn);
        }

        protected void EmailAddressCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (!IsEmailRegistered(BorrowerEmailTb.Text))
            {
                validator.Text = "Email is not associated with any borrower account.";
                args.IsValid = false;
            }
            else if (HasPendingBorrow(BorrowerEmailTb.Text))
            {
                validator.Text = "Borrower has a pending borrow.";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        private bool IsEmailRegistered(string email)
        {
            return BorrowRepository.IsEmailRegistered(email);
        }

        private bool HasPendingBorrow(string email)
        {
            return BorrowRepository.HasPendingBorrow(email);
        }

        protected void RecordBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            int bookInstance = BorrowRepository.GetInstance(BookISBNTb.Text);
            int borrowerUserID = BorrowRepository.GetBorrowerUserID(BorrowerEmailTb.Text);

            var borrow = new _Code.Model.Borrow
            {
                InstanceID = bookInstance,
                UserID = borrowerUserID,
                DateBorrowed = DateTime.Now,
                SiteType = Constants.Borrow.ONSITE_SITE_TYPE,
                BorrowState = Constants.Borrow.BORROWED_STATE,
                ReturnDate = DateTime.Now.AddDays(7)
            };
            BorrowRepository.AddBorrowRecord(borrow);
            LoggingService.Log(AuthenticationHelper.GetLibrarianAuth().GetUser(), $"Recorded onsite borrow with id {borrow.BorrowID}");

            AlertISBN.Text = BookISBNTb.Text;
            AlertEmail.Text = BorrowerEmailTb.Text;
            SuccessAlert.Visible = true;
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            BorrowDateTb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BookISBNTb.Text = "";
            BorrowerEmailTb.Text = "";
        }
    }
}