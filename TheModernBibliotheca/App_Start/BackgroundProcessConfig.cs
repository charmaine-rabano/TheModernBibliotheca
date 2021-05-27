using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.App.Background;

namespace TheModernBibliotheca.App_Start
{
    public class BackgroundProcessConfig
    {
        public static void Config() {
            log4net.Config.XmlConfigurator.Configure();
            BackgroundProcessRunner.Instance.RegisterProcess(new MarkLostBooks());
            BackgroundProcessRunner.Instance.RegisterProcess(new ClearExpiredReservations());
        }
    }
}