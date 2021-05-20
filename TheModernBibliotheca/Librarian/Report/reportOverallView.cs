using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca.Librarian.Report
{
    public class reportOverallView
    {
        public void loadGenres(IEnumerable<reportOverallModel> model, DropDownList dropDownlist)
        {
            dropDownlist.ClearSelection();
            dropDownlist.Items.Add("ALL");
            foreach (reportOverallModel genre in model)
            {
                dropDownlist.Items.Add(genre.Genre);
            }


        }
        public void loadData(IEnumerable<reportOverallModel> model, GridView gridView)
        {
            gridView.DataSource = model;
            gridView.DataBind();
        }
    }
}