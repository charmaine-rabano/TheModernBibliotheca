using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Borrows;

namespace TheModernBibliotheca.Librarian.Borrows
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { DisplayDiv.Visible = false; }
        }

        protected void EmailAddressCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (!IsEmailRegistered(BorrowerEmailTb.Text))
            {
                validator.Text = "Email is not associated with any borrower account.";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        private bool IsEmailRegistered(string email)
        {
            return HistoryRepository.IsEmailRegistered(email);
        }

        protected void ViewBtn_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            HistoryGV.DataSource = HistoryRepository.GetBorrowHistory(BorrowerEmailTb.Text);
            HistoryGV.DataBind();

            BorrowerNameLbl.Text = HistoryRepository.GetBorrowerName(BorrowerEmailTb.Text);

            DisplayDiv.Visible = true;
        }
    }
}