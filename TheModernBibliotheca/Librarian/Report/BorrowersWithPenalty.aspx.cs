using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridviewBorrowersWithPenalty.DataSource = BorrowersWithPenaltyRepository.GetBorrowersWithPenalty();
            gridviewBorrowersWithPenalty.DataBind();
        }
    }
}