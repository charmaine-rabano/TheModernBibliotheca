﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian;
using TheModernBibliotheca._Code.App.Librarian.Books;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var builder = new System.Text.StringBuilder();
            var gnrs = GenreRepository.GetGenres();
            foreach (GenreViewModel genre in gnrs)
                builder.Append(String.Format("<option value='{0}'>", (genre.Genre).ToString()));
            genres.InnerHtml = builder.ToString();
        }
        
        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var linkName = AddBookRepository.UploadFile(txtISBN.Text, "book-cover", fileUploadImg.PostedFile, true);
            AddBookRepository.AddBook(new BookInformation
            {
                ISBN = txtISBN.Text,
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                Author = txtAuthor.Text,
                Summary = txtSummary.Text,
                BookCover = linkName
            });
            int qty = int.Parse(txtQuantity.Text);
            AddBookRepository.AddBookInstance(qty, new BookInstance
            {
                ISBN = txtISBN.Text,
                InCirculation = true
            });

            txtISBN.Text = "";
            txtTitle.Text = "";
            txtGenre.Text = "";
            txtAuthor.Text = "";
            txtSummary.Text = "";
            txtQuantity.Text = "1";
            previewImg.ImageUrl = "https://t4.ftcdn.net/jpg/02/07/87/79/360_F_207877921_BtG6ZKAVvtLyc5GWpBNEIlIxsffTtWkv.jpg";
            
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalEdit').modal('show')", true);
        }

        protected void ISBNCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (IsISBNUnique(txtISBN.Text))
            {
                validator.Text = "Another book has already been associated with this ISBN";
                args.IsValid = false;

            }
            else
            {
                args.IsValid = true;
            }

        }

        private bool IsISBNUnique(string ISBN)
        {
            return AddBookRepository.IsISBNUnique(ISBN);
        }

        
    }
}