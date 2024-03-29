﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Helper;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Modify : System.Web.UI.Page
    {
        public int Id => int.Parse(NavigationHelper.GetRouteValue("id"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetAdminAuth().IsLoggedIn())
            {
                Response.Redirect("~/Admin/Login");
            }

            if (!Page.IsPostBack)
            {
                InitializeFormValues();
            }
        }

        private void InitializeFormValues()
        {
            var user = UsersRepository.GetUser(Id);

            // Redirect to home if user does not exist
            if (user == null) {
                Response.Redirect("~/Admin/Users");
            }

            // Bind data to view
            FirstNameTb.Text = user.FirstName;
            LastNameTb.Text = user.LastName;
            EmailAddressTb.Text = user.Email;
            UserTypeDdl.SelectedValue = user.UserType;
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            UsersRepository.DeleteAccount(Id);
            LoggingService.Log(AuthenticationHelper.GetAdminAuth().GetUser(), $"Deactivated user with id {Id}");
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
            LoggingService.Log(AuthenticationHelper.GetAdminAuth().GetUser(), $"Modified information of user with id {Id}");

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

        protected void ConfirmPasswordCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = true;

            if (PasswordTb.Text == "" && ConfirmPasswordCv.Text == "")
            {
                isValid = true;
            }
            else if(PasswordTb.Text != ConfirmPasswordTb.Text)
            {
                isValid = false;
            }

            args.IsValid = isValid;
        }
    }
}