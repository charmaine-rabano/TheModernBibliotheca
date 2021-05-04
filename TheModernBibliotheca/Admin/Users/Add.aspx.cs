using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify Authentication
            string fromHome = Request.QueryString["FromHome"];
            if (fromHome != null && fromHome == "true") {
                cancelLink.HRef = "~/Admin";
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            UsersRepository.AddAccount(new LibraryUser
            {
                FirstName = FirstNameTb.Text,
                LastName = LastNameTb.Text,
                AccountPassword = PasswordTb.Text,
                DateCreated = DateTime.Now,
                Email = EmailAddressTb.Text,
                UserType = UserTypeDdl.SelectedValue,
            });
            Response.Redirect("~/Admin/Users");
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
    }
}