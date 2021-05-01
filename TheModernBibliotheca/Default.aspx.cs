using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheModernBibliotheca
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = new List<object> {
                new
                {
                    ID = 1,
                    Cover = "cover1.png",
                    Title = "title1"
                },
                new
                {
                    ID = 2,
                    Cover = "cover2.png",
                    Title = "title2"
                },
                new
                {
                    ID = 3,
                    Cover = "cover3.png",
                    Title = "title3"
                },
                new
                {
                    ID = 4,
                    Cover = "cover4.png",
                    Title = "title4"
                },
                new
                {
                    ID = 5,
                    Cover = "cover5.png",
                    Title = "title5"
                },
                new
                {
                    ID = 6,
                    Cover = "cover6.png",
                    Title = "title6"
                }

            };

            Repeater1.DataBind();
        }

        protected void SeeAvailable_Click(object sender, EventArgs e)
        {
            // SQL Query (SELECT Available Books)
        }
    }
}