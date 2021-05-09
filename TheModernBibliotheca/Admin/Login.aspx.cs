using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca.App_Start.Authentication;

namespace TheModernBibliotheca.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationHelper.GetAdminAuth().IsLoggedIn())
            {
                Response.Write(AuthenticationHelper.GetAdminAuth().GetUser().Email);
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            if (AuthenticationHelper.GetAdminAuth().Authenticate(EmailTxt.Text, PasswordTxt.Text))
            {
                Response.Write("Authentication Success");
            }
            else
            {
                Response.Write("Authentication Fail");
            }
        }
    }
}