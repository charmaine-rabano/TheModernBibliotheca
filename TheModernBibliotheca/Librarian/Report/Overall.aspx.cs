using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ddlOverall.ClearSelection();
                ddlOverall.Items.Add("ALL");
                var genres = GenreRepository.GetGenres();
                foreach (GenreViewModel genre in genres)
                {
                    ddlOverall.Items.Add(genre.Genre);
                }
                viewAllBooks();
            }
        }

        private void viewAllBooks()
        {
            gridviewOverall.DataSource = ReportOverallRepository.GetBooks();
            gridviewOverall.DataBind();
        }

        protected void ddlOverall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlOverall.SelectedValue.ToString() == "ALL")
            {
                viewAllBooks();
            }
            else
            {
                gridviewOverall.DataSource = ReportOverallRepository.GetSpecificGenre(ddlOverall.SelectedValue.ToString());
                gridviewOverall.DataBind();
            }
        }


    }
}