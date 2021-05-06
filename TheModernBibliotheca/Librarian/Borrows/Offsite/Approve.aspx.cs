using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Borrows;

namespace TheModernBibliotheca.Librarian.Borrows.Offsite
{
    public partial class Approve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                ApproveGV.DataSource = ApproveRepository.GetRequests();
                ApproveGV.DataBind();
            }
        }

        protected void ApproveGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                ApproveRepository.ApproveRequest(int.Parse(e.CommandArgument.ToString()));
                ApproveGV.DataSource = ApproveRepository.GetRequests();
                ApproveGV.DataBind();
            }
            
            else if (e.CommandName == "Disapprove")
            {
                ApproveRepository.DisapproveRequest(int.Parse(e.CommandArgument.ToString()));
                ApproveGV.DataSource = ApproveRepository.GetRequests();
                ApproveGV.DataBind();
            }
        }
    }
}