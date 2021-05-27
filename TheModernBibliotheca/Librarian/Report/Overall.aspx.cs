using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;
using TheModernBibliotheca._Code.Model;
using TheModernBibliotheca.Librarian.Report;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
                {
                    Response.Redirect("~/Librarian/Login");
                }

                IEnumerable<reportOverallModel> model = GetGenres();
                reportOverallView view = new reportOverallView();
                reportOverallController controller = new reportOverallController(model, view, ddlOverall);
                controller.loadView();
                viewAllBooks();
            }
        }
        private static IEnumerable<reportOverallModel> GetGenres()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInformations.Select(e => new reportOverallModel
                {
                    Genre = e.Genre
                }).Distinct().ToList();
            }
        }
        private void viewAllBooks()
        {
            IEnumerable<reportOverallModel> model = GetBooks();
            reportOverallView view = new reportOverallView();
            gridViewController controller = new gridViewController(model, view, gridviewOverall);
            controller.loadGridView();

        }

        private static IEnumerable<reportOverallModel> GetBooks()
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Select(e => new reportOverallModel
                {
                    InstanceID = e.InstanceID,
                    ISBN = e.ISBN,
                    Title = e.BookInformation.Title,
                    Genre = e.BookInformation.Genre,
                    Author = e.BookInformation.Author,
                    Status = e.InCirculation ? "In Circulation" : "Not In Circulation"
                }).ToList();
            }
        }

        protected void ddlOverall_SelectedIndexChanged(object sender, EventArgs e)
        {
            string specifiedGenre = ddlOverall.SelectedValue.ToString();
            if (specifiedGenre == "ALL")
            {
                viewAllBooks();
            }
            else
            {
                IEnumerable<reportOverallModel> model = GetBookSpecificGenre(specifiedGenre);
                reportOverallView view = new reportOverallView();
                gridViewController controller = new gridViewController(model, view, gridviewOverall);
                controller.loadGridView();
            }

        }
        public static IEnumerable<reportOverallModel> GetBookSpecificGenre(string specificGenre)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Where(e => e.BookInformation.Genre == specificGenre).Select(e => new reportOverallModel
                {
                    InstanceID = e.InstanceID,
                    ISBN = e.ISBN,
                    Title = e.BookInformation.Title,
                    Genre = e.BookInformation.Genre,
                    Author = e.BookInformation.Author,
                    Status = e.InCirculation ? "In Circulation" : "Not In Circulation"
                }).ToList();
            }

        }


    }
}