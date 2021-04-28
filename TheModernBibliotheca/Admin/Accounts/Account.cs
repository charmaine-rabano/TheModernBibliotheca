using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheModernBibliotheca.Admin.Accounts
{
    public class Account
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}