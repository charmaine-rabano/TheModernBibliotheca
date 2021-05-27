using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Lib.Logging;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            LibraryUser account = new LibraryUser
            {
                FirstName = FirstNameTb.Text,
                LastName = LastNameTb.Text,
                AccountPassword = PasswordTb.Text,
                DateCreated = DateTime.Now,
                Email = EmailAddressTb.Text,
                UserType = Constants.LibraryUser.BORROWER_TYPE,
                AccountStatus = Constants.LibraryUser.ACTIVE_STATUS,
            };
            UsersRepository.AddAccount(account);

            LoggingService.Log(account, $"Created account");

            Response.Redirect("~/Login.aspx");
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

        protected void loginLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}