using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Background;

namespace TheModernBibliotheca.Debug
{
    public partial class DebugBackgroundProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bgprocess_Click(object sender, EventArgs e)
        {
            BackgroundProcessRunner.Instance.Trigger();
            Response.Write("Success");
        }
    }
}