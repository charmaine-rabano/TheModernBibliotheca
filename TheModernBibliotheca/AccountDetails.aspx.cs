using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Admin;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Lib.Authentication;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        public int currentID => AuthenticationHelper.GetBorrowerAuth().GetUser().UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SaveNameBtn_Click(object sender, EventArgs e)
        {
            var user = new LibraryUser()
            {
                FirstName = FirstNameTxt.Text,
                LastName = LastNameTxt.Text,
            };
            bool passwordChanged = false;
            BorrowerRepository.ModifyName(currentID, user, passwordChanged);
        }

        protected void SavePasswordBtn_Click(object sender, EventArgs e)
        {
            var user = new LibraryUser()
            {
                AccountPassword = ConfirmPasswordTb.Text
            };
            bool passwordChanged = true;
            BorrowerRepository.ModifyPassword(currentID, user, passwordChanged);
        }

        protected void DeactivateAccount_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalEdit').modal('show')", true);
        }

        protected void ConfirmDeactivate_Click(object sender, EventArgs e)
        {
            // Idea: Implement modal for lesser risk of accidental deactivation
            UsersRepository.DeleteAccount(currentID);
        }
    }
}