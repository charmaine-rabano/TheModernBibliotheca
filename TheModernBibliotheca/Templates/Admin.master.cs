using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Templates
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignoutLb_Click(object sender, EventArgs e)
        {
            AuthenticationHelper.GetAdminAuth().Signout();
            Response.Redirect("~/Admin/Login");
        }
    }
}