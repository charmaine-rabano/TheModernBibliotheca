using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Librarian.Borrows;
using TheModernBibliotheca._Code.Helper;

namespace TheModernBibliotheca.Librarian.Borrows
{
    public partial class ConfirmReturn : System.Web.UI.Page
    {
        public int BorrowId => int.Parse(NavigationHelper.GetRouteValue("id"));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { GetBookInfo(); }
        }

        private void GetBookInfo()
        {
            var borrowInfo = ReturnRepository.GetBorrowInfo(BorrowId);

            BorrowDateLbl.Text = borrowInfo.BorrowDate.Value.ToString("MMM dd, yyyy");
            ReturnDateLbl.Text = borrowInfo.DeadlineDate.Value.ToString("MMM dd, yyyy");
            BookNameLbl.Text = borrowInfo.BookName;
            BorrowerNameLbl.Text = borrowInfo.BorrowerName;

            if (DateTime.Now > borrowInfo.DeadlineDate.Value)
            {
                LateLbl.Visible = true;
                NotLateCB.Visible = true;
            }
            else
            {
                LateLbl.Visible = false;
                NotLateCB.Visible = false;
            }
        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {
            bool late = false, damaged = false, lost = false;

            if (DateTime.Now > DateTime.Parse(ReturnDateLbl.Text))
            {
                if (!NotLateCB.Checked)
                    late = true;
            }

            if (ConditionDDL.SelectedValue == "Damaged")
                damaged = true;
            else if (ConditionDDL.SelectedValue == "Lost")
                lost = true;

            ReturnRepository.ReturnBook(BorrowId, late, damaged, lost);

            Response.Redirect("~/Librarian/Borrows/Return.aspx");
        }
    }
}