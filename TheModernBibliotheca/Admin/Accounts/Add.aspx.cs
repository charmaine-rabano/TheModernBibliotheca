using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Helper.Auth;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify Authentication
            if (!AuthHelper.IsLoggedIn()) { Response.Redirect("/Admin/Login"); }
            if (AuthHelper.GetUser().UserType != AuthHelper.ADMIN_USER_TYPE) { Response.Redirect("/"); }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            AccountsRepository.AddAccount(new Account
            {
                DateCreated = DateTime.Now,
                EmailAddress = EmailAddressTb.Text,
                FirstName = FirstNameTb.Text,
                LastName = LastNameTb.Text,
                Password = PasswordTb.Text,
                UserType = UserTypeDdl.SelectedValue
            });
        }
    }
}