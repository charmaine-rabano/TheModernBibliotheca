<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .item {
            padding-left: 20px;
            padding-right: 20px;
        }

        button {
            padding: 20px 30px 20px 30px;
            border: none;
            background: none;
        }
    </style>

    <div class="container" style="margin-top: 60px">
        <h3>Offsite Borrowing</h3>
        <a href="/Librarian/Borrows/Offsite/Approve.aspx"><button><img src="/Content/bootstrap-icons/check2-square.svg" width="32" height="32" />&emsp;Approve Reservations</button></a>
        <a href="/Librarian/Borrows/Offsite/Pending.aspx"><button><img src="/Content/bootstrap-icons/calendar-event.svg" width="32" height="32" />&emsp;View Pending Reservations</button></a>

        <h3 style="margin-top: 20px">Onsite Borrowing</h3>
        <a href="#"><button><img src="/Content/bootstrap-icons/person-fill.svg" width="32" height="32" />&emsp;Create Borrower Account</button></a>
        <a href="#"><button><img src="/Content/bootstrap-icons/clipboard.svg" width="32" height="32" />&emsp;Record Book Borrow</button></a>

        <h3 style="margin-top: 20px">Book Return</h3>
        <a href="#"><button><img src="/Content/bootstrap-icons/book-half.svg" width="32" height="32" />&emsp;Record Book Return</button></a>
    </div>
</asp:Content>
