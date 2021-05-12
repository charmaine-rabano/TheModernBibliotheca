using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            // code to validate credentials
            // --
            // --
            // --
            // Response.Redirect("~/Default.aspx");
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateAccount.aspx");
        }
    }
}