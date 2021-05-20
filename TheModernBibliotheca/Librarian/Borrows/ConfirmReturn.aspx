<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="ConfirmReturn.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.ConfirmReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="padding-top: 60px">
        <div class="col col-md-6 offset-md-3">
            <div><h3>Return Book<asp:Label ID="LateLbl" runat="server" Text=" (Late)" ForeColor="Red" Visible="false" ></asp:Label></h3></div>
        
            <div style="margin-top: 40px; width: 100%">
                <p>Borrow Date: <asp:Label ID="BorrowDateLbl" runat="server" Text=""></asp:Label></p>
                <p>Return Date: <asp:Label ID="ReturnDateLbl" runat="server" Text=""></asp:Label></p>
                <p>Book Name: <asp:Label ID="BookNameLbl" runat="server" Text=""></asp:Label></p>
                <p>Borrower Name: <asp:Label ID="BorrowerNameLbl" runat="server" Text=""></asp:Label></p>
                <p>
                    Condition: 
                    <asp:DropDownList ID="ConditionDDL" runat="server" CssClass="btn btn-primary dropdown-toggle" style="margin-left: 20px;">
                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                        <asp:ListItem Text="Damaged" Value="Damaged"></asp:ListItem>
                        <asp:ListItem Text="Lost" Value="Lost"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p><asp:CheckBox ID="NotLateCB" runat="server" Text="&emsp;Not Late" Visible="false" /></p>
            </div>

            <div style="display: flex; margin-top: 40px;">
                <asp:Button ID="CancelBtn" runat="server" Text="Cancel" CssClass="btn btn-secondary" style="margin-left:auto; margin-right: 20px;" PostBackUrl="~/Librarian/Borrows/Return.aspx" />
                <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" CssClass="btn btn-primary" OnClick="ConfirmBtn_Click" />
            </div>
        </div>
    </div>
</asp:Content>
