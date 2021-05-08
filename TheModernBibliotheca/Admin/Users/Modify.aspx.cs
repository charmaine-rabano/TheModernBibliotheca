using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Helper;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Modify : System.Web.UI.Page
    {
        public int Id => int.Parse(NavigationHelper.GetRouteValue("id"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitializeFormValues();
            }
        }

        private void InitializeFormValues()
        {
            var user = UsersRepository.GetUser(Id);
            FirstNameTb.Text = user.FirstName;
            LastNameTb.Text = user.LastName;
            EmailAddressTb.Text = user.Email;
            UserTypeDdl.SelectedValue = user.UserType;
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            UsersRepository.DeleteAccount(Id);
            Response.Redirect("/Admin/Users");
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var user = new LibraryUser()
            {
                FirstName = FirstNameTb.Text,
                LastName = LastNameTb.Text,
                Email = EmailAddressTb.Text,
                UserType = UserTypeDdl.SelectedValue,
                AccountPassword = PasswordTb.Text
            };

            bool passwordChanged = PasswordTb.Text != "";
            UsersRepository.ModifyAccount(Id, user, passwordChanged);

            Response.Redirect("/Admin/Users");
        }

        protected void EmailAddressCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (IsEmailUnique(Id, EmailAddressTb.Text))
            {
                validator.Text = "Another user has already been associated with this email";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        private bool IsEmailUnique(int id, string email)
        {
            return UsersRepository.IsEmailUniqueExceptSelf(id, email);
        }

    }
}