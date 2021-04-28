using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.Helper;

namespace TheModernBibliotheca.Admin.Accounts
{
    public partial class Modify : System.Web.UI.Page
    {
        public int Id => int.Parse(NavigationHelper.GetRouteValue("id"));
        protected void Page_Load(object sender, EventArgs e)
        {
            AccountsRepository.GetAccount(Id);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            AccountsRepository.DeleteAccount(Id);
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            AccountsRepository.ModifyAccount(Id, new Account
            {
                DateCreated = DateTime.Now,
                EmailAddress = EmailAddressTb.Text,
                FirstName = FirstNameTb.Text,
                LastName = LastNameTb.Text,
                Password = PasswordTb.Text,
                UserType = UserTypeDdl.SelectedValue
            });
        }
    }
}