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
    public partial class Approve : System.Web.UI.Page
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
            ApproveGV.DataSource = ApproveRepository.GetRequests();
            ApproveGV.DataBind();
        }

        protected void ApproveGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                ApproveRepository.ApproveRequest(id);
                LoggingService.Log(AuthenticationHelper.GetLibrarianAuth().GetUser(), $"Approved offsite request with id {id}");
                Bind();
            }
            
            else if (e.CommandName == "Disapprove")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                ApproveRepository.DisapproveRequest(int.Parse(e.CommandArgument.ToString()));
                LoggingService.Log(AuthenticationHelper.GetLibrarianAuth().GetUser(), $"Disapproved offsite request with id {id}");
                Bind();
            }
        }
    }
}