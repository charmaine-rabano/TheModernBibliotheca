using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace TheModernBibliotheca
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            RegisterCustomRoutes(routes);
        }

        public static void RegisterCustomRoutes(RouteCollection routes) {
            routes.MapPageRoute("ModifyAccount", "Admin/Users/{id}/Modify", "~/Admin/Users/Modify.aspx");
            routes.MapPageRoute("Books", "Books/{id}", "~/Books.aspx");

        }
    }
}
