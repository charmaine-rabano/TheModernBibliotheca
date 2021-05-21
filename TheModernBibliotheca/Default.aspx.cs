using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationHelper.GetBorrowerAuth().IsLoggedIn())
            {
                if (!Page.IsPostBack)
                {
                    Repeater1.DataSource = BooksRepository.GetBooks();
                    Repeater1.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            IEnumerable<BookInformation> books;
            string searchKey = txtSearch.Text;
            if (AvailabilityDdl.SelectedValue == "All")
            {
                books = BooksRepository.SearchBooks(searchKey);
            }
            else if (AvailabilityDdl.SelectedValue == "Available")
            {
                books = BooksRepository.SearchAvailableBooks(searchKey);
            }
            else
            {
                books = BooksRepository.SearchUnavailableBooks(searchKey);
            }
            Repeater1.DataSource = books;
            Repeater1.DataBind();
        }

        public string FormatString(string s, int len)
        {
            return s.Length > len ? s.Substring(0, len) + "..." : s;
        }

        public string GetAvailablility(string isbn)
        {
            return BooksRepository.IsBookAvailable(isbn) ? "Available" : "Unavailable";
        }

        protected void AvailabilityDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<BookInformation> books;
            if (AvailabilityDdl.SelectedValue == "All")
            {
                books = BooksRepository.GetBooks();
            }
            else if (AvailabilityDdl.SelectedValue == "Available") {
                books = BooksRepository.GetAvailableBooks();
            }
            else
            {
                books = BooksRepository.GetUnavailableBooks();
            }
            Repeater1.DataSource = books;
            Repeater1.DataBind();
        }
    }
}