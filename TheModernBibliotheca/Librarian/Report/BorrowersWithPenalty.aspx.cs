using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            gridviewBorrowersWithPenalty.DataSource = BorrowersWithPenaltyRepository.GetBorrowersWithPenalty();
            gridviewBorrowersWithPenalty.DataBind();
        }
    }
}