﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationHelper.GetBorrowerAuth().IsLoggedIn())
            {
                Response.Redirect("~");
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            if (AuthenticationHelper.GetBorrowerAuth().Authenticate(EmailTxt.Text, PasswordTxt.Text))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                loginMessageDiv.Visible = true;
            }
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateAccount.aspx");
        }
    }
}