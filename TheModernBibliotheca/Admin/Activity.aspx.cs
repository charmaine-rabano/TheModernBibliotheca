using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca.Admin
{
    public partial class Activity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthenticationHelper.GetAdminAuth().IsLoggedIn())
            {
                Response.Redirect("~/Admin/Login");
            }

            UserActivityGv.DataSource = ActivityRepository.GetActivities();
            UserActivityGv.DataBind();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static IEnumerable<ActivityViewModel> Json()
        {
            return ActivityRepository.GetActivities();
        }
    }
}