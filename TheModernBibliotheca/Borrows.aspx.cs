using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheModernBibliotheca._Code.App.Borrower;
using TheModernBibliotheca._Code.Lib.Authentication;

namespace TheModernBibliotheca
{
    public partial class Borrows : System.Web.UI.Page
    {
        public CurrentBorrowViewModel model;
        public IEnumerable<BorrowHistoryItemModel> itemModels;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int userId = AuthenticationHelper.GetBorrowerAuth().GetUser().UserID;
            int userId = 20;

            model = BorrowsRepository.GetCurrentlyBorrowedModel(userId);
            itemModels = BorrowsRepository.GetBorrowsHistory(userId);

            BorrowHistoryTableRepeater.DataSource = itemModels;
            BorrowHistoryTableRepeater.DataBind();
        }
    }
}