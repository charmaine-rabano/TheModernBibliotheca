﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetAdminAuth().IsLoggedIn())
            {
                Response.Redirect("~/Admin/Login");
            }
        }
    }
}