using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca.Borrower;

namespace TheModernBibliotheca
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int bookID = int.Parse(Request.QueryString["ID"]);
            //txtTitle.Text = bookID.ToString();
        
            // SQL Query (title, picURL, author, description, quantity; on-shelf specifically)
        }

        protected void btnCreateReservation_Click(object sender, EventArgs e)
        {
            // Code to Create Reservation
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}