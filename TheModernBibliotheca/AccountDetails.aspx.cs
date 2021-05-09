using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            isRepeater = true;
        }

        public bool isRepeater = true;
    }
}