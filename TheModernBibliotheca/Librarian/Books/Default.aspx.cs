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

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bookGenreDropDown.ClearSelection();
                bookGenreDropDown.Items.Add("ALL");
                var genres = GenreRepository.GetGenres();
                foreach (GenreViewModel genre in genres)
                {
                    bookGenreDropDown.Items.Add(genre.Genre);
                }
                viewAllBooks();
            }
            /*
            string searchKey = Request.QueryString["search"];
            string statusKey = Request.QueryString["status"];
            IEnumerable<BookInformation> books;

            if (searchKey != null)
            {
                books = BooksRepository.GetSearchedBooks(searchKey);
            }
            else if (statusKey == "True")
            {
                bool key = true;
                books = BooksRepository.GetAvailableBooks(key);
            }
            else
            {
                books = BooksRepository.GetBooks();
            }
            Repeater1.DataSource = books;
            Repeater1.DataBind();*/

        }
        private void viewAllBooks()
        {
            bookRepeater.DataSource = ManageBooksRepository.GetBooks();
            bookRepeater.DataBind();
        }
        protected void bookGenreDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookGenreDropDown.SelectedValue.ToString() == "ALL")
            {
                viewAllBooks();
            }
            else
            {
                //gridviewOnshelf.DataSource = ReportInCirculationRepository.GetSpecificGenre(onShelfDropDown.SelectedValue.ToString());
                //gridviewOnshelf.DataBind();
            }
        }
        /*protected void SeeAvailable_Click(object sender, EventArgs e)
        {
           bool statusAvailable = true;
           Response.Redirect($"~/Default.aspx?status={statusAvailable}");
        }*/

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           //Response.Redirect($"~/Default.aspx?search={HttpUtility.UrlEncode(txtSearch.Text)}");
        }
    }
}