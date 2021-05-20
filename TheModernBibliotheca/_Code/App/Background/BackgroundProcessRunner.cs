using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca._Code.App.Background
{

    public class BackgroundProcessRunner
    {
        // SINGLETON
        private static readonly Lazy<BackgroundProcessRunner> lazy =
            new Lazy<BackgroundProcessRunner>(() => new BackgroundProcessRunner());
        
        public static BackgroundProcessRunner Instance => lazy.Value;

        // Main Class

        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IList<IBackgroundProcess> processes;

        private BackgroundProcessRunner()
        {
            processes = new List<IBackgroundProcess>();
        }

        public void RegisterProcess(IBackgroundProcess process)
        {
            processes.Add(process);
        }

        public void Trigger()
        {
            log.Debug("Background Process Runner Triggered");
            foreach (var process in processes)
            {
                process.Run();
            }
        }

    }
}