using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            // code to validate credentials
            // --
            // --
            // --
            Response.Redirect("~/Login.aspx");
        }

        protected void EmailAddressCv_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void loginLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}