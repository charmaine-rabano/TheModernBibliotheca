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

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitializeFormValues();
            }

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
                var linkName = FileSystemHelper.UploadFile(txtISBN.Text, "bookcovers", fileUploadImg.PostedFile, true);

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
            InitializeFormValues();
        }
    }
}