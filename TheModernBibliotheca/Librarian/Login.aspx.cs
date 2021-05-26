using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Librarian
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationHelper.GetLibrarianAuth().IsLoggedIn()) { 
                Response.Redirect("~/Librarian");
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            if (AuthenticationHelper.GetLibrarianAuth().Authenticate(EmailTxt.Text, PasswordTxt.Text))
            {
                Response.Redirect("~/Librarian");
            }
            else
            {
                loginMessageDiv.Visible = true;
            }

        }
    }
}