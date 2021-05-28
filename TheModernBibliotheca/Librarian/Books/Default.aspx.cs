using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Model;
using TheModernBibliotheca._Code.App.Librarian;
using TheModernBibliotheca._Code.App.Librarian.Books;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            if (!this.IsPostBack)
            {
                string searchKey = Request.QueryString["search"];
                if (searchKey != null)
                {
                    bookGenreDropDown.Items.Add(new ListItem("---Select---", "0"));
                    lblSearchResult.Text = "Search Result for: " + searchKey;
                    lblSearchResult.Visible = true;
                    var content = BooksRepository.SearchBooks(searchKey);

                    if (content != null && content.Any())
                    {
                        bookRepeater.DataSource = BooksRepository.SearchBooks(searchKey);
                        bookRepeater.DataBind();
                    }
                    else noResultsMessage.Visible = true;
                }
                else { viewAllBooks(); }
                bookGenreDropDown.ClearSelection();
                bookGenreDropDown.Items.Add("ALL");
                var genres = GenreRepository.GetGenres();
                foreach (GenreViewModel genre in genres)
                {
                    bookGenreDropDown.Items.Add(genre.Genre);
                }
                
            }
        }
        public string FormatString(string value, int length)
        {
            return value.Length > length ? value.Substring(0, length) + "..." : value;
        }
        private void viewAllBooks()
        {
            bookRepeater.DataSource = ManageBooksRepository.GetBooks();
            bookRepeater.DataBind();
        }

        protected void bookGenreDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSearchResult.Visible = false;
            noResultsMessage.Visible = false;
            if (bookGenreDropDown.SelectedValue.ToString() == "ALL")
            {
                viewAllBooks();
            }
            else
            {
                bookRepeater.DataSource = ManageBooksRepository.GetSpecificGenre(bookGenreDropDown.SelectedValue.ToString());
                bookRepeater.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            noResultsMessage.Visible = false;
            Response.Redirect($"/Librarian/Books/Default.aspx?search={HttpUtility.UrlEncode(txtSearch.Text)}");
        }
    }
}