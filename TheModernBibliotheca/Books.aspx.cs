﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Helper;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca
{
    public partial class Books : System.Web.UI.Page
    {
        public BookInformation model;
        // public string ISBN => NavigationHelper.GetRouteValue("ISBN");

        protected void Page_Load(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ID"];
            model = BooksRepository.GetBook(ISBN);
        }

        protected void btnCreateReservation_Click(object sender, EventArgs e)
        {
            // Code to Create Reservation
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        public string GetStatus()
        {
            return BooksRepository.GetStatus(model.ISBN);
        }
    }
}