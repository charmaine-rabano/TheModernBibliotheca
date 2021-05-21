using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca.Librarian.Report
{
    public class reportOverallController : Controller
    {
        private IEnumerable<reportOverallModel> model;
        private reportOverallView view;
        private DropDownList dropDownlist;
        public reportOverallController(IEnumerable<reportOverallModel> model, reportOverallView view, DropDownList dropDownlist)
        {
            this.model = model;
            this.view = view;
            this.dropDownlist = dropDownlist;
        }
        public void loadView()
        {
            view.loadGenres(model, dropDownlist);
        }
    }
    public class gridViewController : Controller
    {
        private IEnumerable<reportOverallModel> model;
        private reportOverallView view;
        private GridView gridView;
        public gridViewController(IEnumerable<reportOverallModel> model, reportOverallView view, GridView gridView)
        {
            this.model = model;
            this.view = view;
            this.gridView = gridView;
        }

        public void loadGridView()
        {
            view.loadData(model, gridView);
        }
    }
}