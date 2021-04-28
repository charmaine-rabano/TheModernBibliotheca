﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Helper.Auth;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify Authentication
            if (!AuthHelper.IsLoggedIn()) { Response.Redirect("/Admin/Login"); }
            if (AuthHelper.GetUser().UserType != AuthHelper.ADMIN_USER_TYPE) { Response.Redirect("/"); }

            // Bind Data
            AccountsGv.DataSource = AccountsRepository.GetAccounts();
            AccountsGv.DataBind();
        }

        protected void AccountsGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify") {
                int userId = (int)e.CommandArgument;
                Response.Redirect($"Admin/Accounts/{userId}/Modify");
            }
        }
    }
}