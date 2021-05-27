using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Librarian.Borrows.Onsite
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            if (!Page.IsPostBack) { SuccessAlert.Visible = false; }
        }

        protected void EmailAddressCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (IsEmailUnique(EmailAddressTb.Text))
            {
                validator.Text = "Another user has already been associated with this email";
                args.IsValid = false;

            }
            else
            {
                args.IsValid = true;
            }
        }

        private bool IsEmailUnique(string email)
        {
            return UsersRepository.IsEmailUnique(email);
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var user = new LibraryUser
            {
                FirstName = FirstNameTb.Text,
                LastName = LastNameTb.Text,
                AccountPassword = "changeme",
                DateCreated = DateTime.Now,
                Email = EmailAddressTb.Text,
                UserType = Constants.LibraryUser.BORROWER_TYPE,
                AccountStatus = Constants.LibraryUser.ACTIVE_STATUS
            };
            UsersRepository.AddAccount(user);

            LoggingService.Log(AuthenticationHelper.GetLibrarianAuth().GetUser(), $"Created borrower with id {user.UserID}");

            AlertEmail.Text = EmailAddressTb.Text;
            SuccessAlert.Visible = true;
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            FirstNameTb.Text = "";
            LastNameTb.Text = "";
            EmailAddressTb.Text = "";
        }
    }
}