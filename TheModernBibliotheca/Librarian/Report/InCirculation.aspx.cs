using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            gridviewOnshelf.DataSource = ReportInCirculationRepository.GetBooks();
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
                gridviewOnshelf.DataSource = ReportInCirculationRepository.GetSpecificGenre(onShelfDropDown.SelectedValue.ToString());
                gridviewOnshelf.DataBind();
            }
        }

    }
}