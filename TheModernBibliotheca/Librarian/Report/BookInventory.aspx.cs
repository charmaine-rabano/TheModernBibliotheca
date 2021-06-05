using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;
using TheModernBibliotheca._Code.App.Librarian.Report;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Librarian.Report
{
    public partial class BookInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            

            if (!this.IsPostBack)
            {
                onShelfDropDown.ClearSelection();
                onShelfDropDown.Items.Add("ALL");
                var genres = GenreRepository.GetGenres();
                foreach (GenreViewModel genre in genres)
                {
                    onShelfDropDown.Items.Add(genre.Genre);
                }
                viewAllBooks();
            }
        }

        private void viewAllBooks()
        {
            gridviewOnshelf.DataSource = BookInventoryRepository.GetBookInventory();
            gridviewOnshelf.DataBind();
        }

        protected void onShelfDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onShelfDropDown.SelectedValue.ToString() == "ALL")
            {
                viewAllBooks();
            }
            else
            {
                gridviewOnshelf.DataSource = BookInventoryRepository.GetBookInventoryByGenre(onShelfDropDown.SelectedValue.ToString());
                gridviewOnshelf.DataBind();
            }
        }
    }
}