﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Books;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            Response.Redirect($"/Librarian/Books/Book.aspx?ISBN={ISBN}");
        }

        protected void instanceButton_Click(object sender, EventArgs e)
        {
            instancePanel.Visible = true;
            notInCirculationPanel.Visible = false;
            inCirculationPanel.Visible = false;
        }

        protected void notInCirculation_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            instancePanel.Visible = false;
            notInCirculationPanel.Visible = true;
            inCirculationPanel.Visible = false;

            gvNotInCirculation.DataSource = InstancesRepository.GetNotInCirculation(ISBN);
            gvNotInCirculation.DataBind();
        }

        protected void inCirculationButton_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];

            instancePanel.Visible = false;
            notInCirculationPanel.Visible = false;
            inCirculationPanel.Visible = true;

            gvInCirculation.DataSource = InstancesRepository.GetInCirculation(ISBN);
            gvInCirculation.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            int qty = int.Parse(txtQuantity.Text);
            InstancesRepository.AddInstance(qty, new BookInstance
            {
                ISBN = ISBN,
                InCirculation = true
            });
            txtQuantity.Text = "1";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalEdit').modal('show')", true);

        }

        protected void gvInCirculation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            if (e.CommandName == "REMOVE")
            {
                InstancesRepository.RemoveInCirculation(int.Parse(e.CommandArgument.ToString()));
                gvInCirculation.DataSource =  InstancesRepository.GetInCirculation(ISBN);
                gvInCirculation.DataBind();
            }
        }

        protected void gvNotInCirculation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            if (e.CommandName == "ADD")
            {
                InstancesRepository.AddInCirculation(int.Parse(e.CommandArgument.ToString()));
                gvNotInCirculation.DataSource = InstancesRepository.GetNotInCirculation(ISBN);
                gvNotInCirculation.DataBind();
            }
        }
    }
}