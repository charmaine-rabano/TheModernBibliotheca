using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Helper;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca
{
    public partial class Books : System.Web.UI.Page
    {
        public BookInformation model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetBorrowerAuth().IsLoggedIn())
            {
                Response.Redirect("~/Login.aspx");
            }
            string ISBN = Request.QueryString["ID"];
            model = BooksRepository.GetBook(ISBN);
        }

        protected void btnCreateReservation_Click(object sender, EventArgs e)
        {
            int instanceID = int.Parse(Request.QueryString["ID"]);
            BorrowerRepository.CreateReservation(instanceID, AuthenticationHelper.GetBorrowerAuth().GetUser().UserID);
            Response.Write("<script>alert('Reservation Request Placed!');</script>");
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        public string GetStatus()
        {
            return BooksRepository.GetStatus(model.ISBN);
        }
    }
}