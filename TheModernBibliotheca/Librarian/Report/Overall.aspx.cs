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
            ddlOverall.Items.Add("ALL");

            var genres = GenreRepository.GetGenres();
            foreach (GenreModel genre in genres)
            {
                ddlOverall.Items.Add(genre.Genre);
            }
            gridviewOverall.DataSource = ReportOverallRepository.GetBooks();
            gridviewOverall.DataBind();

        }

        protected void ddlOverall_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change what is shown if filter is changed
        }
    }
}