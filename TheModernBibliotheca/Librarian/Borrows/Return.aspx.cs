using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Borrows;

namespace TheModernBibliotheca.Librarian.Borrows
{
    public partial class Return : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { Bind(); }
        }

        private void Bind()
        {
            ReturnGV.DataSource = ReturnRepository.GetBooksToReturn();
            ReturnGV.DataBind();
        }

        protected void ReturnGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Return")
            {
                int borrowId = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("~/Librarian/Borrows/" + borrowId + "/ConfirmReturn");
            }
        }
    }
}