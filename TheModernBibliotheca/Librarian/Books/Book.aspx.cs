using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Helper;
using TheModernBibliotheca._Code.App.Librarian.Books;
using TheModernBibliotheca._Code.Model;
using TheModernBibliotheca._Code.App.Librarian;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Lib.Logging;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetLibrarianAuth().IsLoggedIn())
            {
                Response.Redirect("~/Librarian/Login");
            }

            if (!Page.IsPostBack)
            {
                InitializeFormValues();
            }
            var builder = new System.Text.StringBuilder();
            var gnrs = GenreRepository.GetGenres();
            foreach (GenreViewModel genre in gnrs)
                builder.Append(String.Format("<option value='{0}'>", (genre.Genre).ToString()));
            genres.InnerHtml = builder.ToString();
        }

        private void InitializeFormValues()
        {
            string ISBN = Request.QueryString["ISBN"];
            var book = BookRepository.GetBook(ISBN);

            if (book == null)
            {
                Response.Redirect("/Librarian/Books/Default.aspx");
            }

            txtISBN.Text = book.ISBN;
            txtTitle.Text = book.Title;
            txtGenre.Text = book.Genre;
            txtAuthor.Text = book.Author; 
            txtSummary.Text = book.Summary;
            previewImg.ImageUrl = book.BookCover;
        }
        protected void instanceLinkButton_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            Response.Redirect("Instances?ISBN="+ISBN);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            var book = new BookInformation();
            if (fileUploadImg.HasFile)
            {
                string cacheBust = DateTime.Now.Second.ToString();
                var linkName = FileSystemHelper.UploadFile(txtISBN.Text + cacheBust, "bookcovers", fileUploadImg.PostedFile, true);

                book = new BookInformation()
                {
                    ISBN = txtISBN.Text,
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Author = txtAuthor.Text,
                    Summary = txtSummary.Text,
                    BookCover = linkName
                };
            }
            else
            {
                book = new BookInformation()
                {
                    ISBN = txtISBN.Text,
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Author = txtAuthor.Text,
                    Summary = txtSummary.Text,
                    BookCover = previewImg.ImageUrl
                };

            }
            
            BookRepository.ModifyBook(txtISBN.Text, book);
                        
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalEdit').modal('show')", true);

            LoggingService.Log(AuthenticationHelper.GetLibrarianAuth().GetUser(), $"Modified book with isbn {book.ISBN}");

            InitializeFormValues();
        }
    }
}