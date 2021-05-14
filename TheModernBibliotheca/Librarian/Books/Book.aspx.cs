using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Helper;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm5 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ID"];
            Label1.Text = ISBN;
            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string ISBN = Request.QueryString["ID"];
            Response.Redirect("Instances?ISBN="+ISBN);
            
           
        }
    }
}