using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void librarian_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Librarian/Borrows/Menu.aspx");
        }

        protected void books_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Librarian/Books/Menu.aspx");
        }

    }
}