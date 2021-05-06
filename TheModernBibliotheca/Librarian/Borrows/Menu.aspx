<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .item{
            padding-left: 20px;
            padding-right: 20px;
        }
    </style>

    <div class="container" style="margin-top: 60px">
        <h3>Offsite Borrowing</h3>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Librarian/Borrows/Offsite/Approve.aspx" CssClass="item"><img src="/Content/bootstrap-icons/check2-square.svg" width="32" height="32"> Approve Reservations</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Librarian/Borrows/Offsite/Pending.aspx" CssClass="item"><img src="/Content/bootstrap-icons/calendar-event.svg" width="32" height="32"> View Pending Reservations</asp:HyperLink>

        <h3 style="margin-top: 20px">Onsite Borrowing</h3>
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="item"><img src="/Content/bootstrap-icons/person-fill.svg" width="32" height="32"> Create Borrower Account</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="item"><img src="/Content/bootstrap-icons/clipboard.svg" width="32" height="32"> Record Book Borrow</asp:HyperLink>
        
        <h3 style="margin-top: 20px">Book Return</h3>
        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="item"><img src="/Content/bootstrap-icons/book-half.svg" width="32" height="32"> Record Book Return</asp:HyperLink>
    </div>
</asp:Content>
