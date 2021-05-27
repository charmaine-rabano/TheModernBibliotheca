using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Helper;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;
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

            int quantity = BooksRepository.GetQuantity(ISBN);
            lblBookQuantity.Text = quantity.ToString();
            availableTag.InnerHtml = quantity > 0 ? "Available" : "Unavailable";
            bool userCanBorrow = BooksRepository.CanUserBorrow(AuthenticationHelper.GetBorrowerAuth().GetUser().UserID);
            if (quantity == 0 || !userCanBorrow)
            {
                btnCreateReservation.Enabled = false;
            }
        }

        protected void btnCreateReservation_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ID"];
            BorrowerRepository.CreateReservation(ISBN, AuthenticationHelper.GetBorrowerAuth().GetUser().UserID);

            LoggingService.Log(AuthenticationHelper.GetBorrowerAuth().GetUser(), $"Created borrow for book with isbn {ISBN}");

            Response.Write("<script>alert('Reservation Request Placed!');</script>");
            Response.Redirect("~/Borrows.aspx");
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