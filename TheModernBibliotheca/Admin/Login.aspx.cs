using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Helper.Auth;

namespace TheModernBibliotheca.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            string email = EmailTb.Text;
            string password = PasswordTb.Text;

            bool success = AuthHelper.Login(email, password);

            if (success)
            {
                Response.Redirect("~/Admin/");
            }
            else
            {
                // Show error message
            }
        }
    }
}