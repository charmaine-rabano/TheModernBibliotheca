using System;
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
            string ISBN = Request.QueryString["ISBN"];
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            Response.Redirect("Book?ISBN=" + ISBN);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;

            gvNotInCirculation.DataSource = InstancesRepository.GetNotInCirculation(ISBN);
            gvNotInCirculation.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ISBN"];

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;

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
            /// add saved message
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
    }
}