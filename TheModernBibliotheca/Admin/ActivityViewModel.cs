using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca.Admin
{
    public class ActivityViewModel
    {
        public string Email { get; set; }
        public string UserType { get; set; }
        public DateTime TimeStamp { get; set; }

        public string Description { get; set; }
    }
}