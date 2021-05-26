using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        public int currentID => AuthenticationHelper.GetBorrowerAuth().GetUser().UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetBorrowerAuth().IsLoggedIn())
            {
                Response.Redirect("~/Login");
            }

            if (!Page.IsPostBack)
            {
                FirstNameTxt.Text = BorrowerRepository.GetFirstName(currentID);
                LastNameTxt.Text = BorrowerRepository.GetLastName(currentID);
            }
        }

        protected void SaveNameBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }
            var user = new LibraryUser()
            {
                FirstName = FirstNameTxt.Text,
                LastName = LastNameTxt.Text,
            };
            bool passwordChanged = false;
            BorrowerRepository.ModifyName(currentID, user, passwordChanged);
            nameChangedMessage.Visible = true;

            LoggingService.Log(AuthenticationHelper.GetBorrowerAuth().GetUser(), $"Updated name");
        }

        protected void SavePasswordBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var user = new LibraryUser()
                {
                    AccountPassword = ConfirmPasswordTb.Text
                };
                bool passwordChanged = true;
                BorrowerRepository.ModifyPassword(currentID, user, passwordChanged);
                passwordChangedMessage.Visible = true;
            }

            LoggingService.Log(AuthenticationHelper.GetBorrowerAuth().GetUser(), $"Password updated");

            ConfirmPasswordTb.Text = "";
            CurrPasswordTxt.Text = "";
            NewPasswordTxt.Text = "";
        }

        protected void DeactivateAccount_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalEdit').modal('show')", true);
        }

        protected void ConfirmDeactivate_Click(object sender, EventArgs e)
        {
            // Idea: Implement modal for lesser risk of accidental deactivation
            UsersRepository.DeleteAccount(currentID);
            LoggingService.Log(AuthenticationHelper.GetBorrowerAuth().GetUser(), $"Deactivated account");
        }

        protected void CurrentPasswordCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UsersRepository.IsCurrentPassword(currentID, CurrPasswordTxt.Text);
        }
    }
}