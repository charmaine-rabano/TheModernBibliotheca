using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetAdminAuth().IsLoggedIn())
            {
                Response.Redirect("~/Admin/Login");
            }

            int loggedInUserId = AuthenticationHelper.GetAdminAuth().GetUser().UserID;
            AccountsGv.DataSource = UsersRepository.GetUsers(loggedInUserId);
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