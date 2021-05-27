using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Borrows;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;

namespace TheModernBibliotheca.Librarian.Borrows.Offsite
{
    public partial class Pending : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            if (!Page.IsPostBack) { Bind(); }
        }

        private void Bind()
        {
            PendingGV.DataSource = PendingRepository.GetReservations();
            PendingGV.DataBind();
        }

        protected void PendingGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Claim")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                PendingRepository.ClaimReservation(id);
                LoggingService.Log(AuthenticationHelper.GetLibrarianAuth().GetUser(), $"Processed borrow claim with id {id}");
                Bind();
            }
        }
    }
}