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
            onShelfDropDown.Items.Add("ALL");

            var genres = GenreRepository.GetGenres();
            foreach (GenreModel genre in genres)
            {
                onShelfDropDown.Items.Add(genre.Genre);
            }
        }

        protected void onShelfDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change what is shown if filter is changed
        }

    }
}