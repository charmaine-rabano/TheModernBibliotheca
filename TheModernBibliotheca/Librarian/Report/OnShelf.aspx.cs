using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca.Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onShelfDropDown.Items.Add("ALL");
            //ADD OTHER genre
            //add data
        }

        protected void onShelfDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change what is shown if filter is changed
        }

    }
}