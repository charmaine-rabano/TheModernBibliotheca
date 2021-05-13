using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Templates
{
    public partial class Borrower : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignoutLb_Click(object sender, EventArgs e)
        {
            AuthenticationHelper.GetBorrowerAuth().Signout();
            Response.Redirect("~");
        }
    }
}