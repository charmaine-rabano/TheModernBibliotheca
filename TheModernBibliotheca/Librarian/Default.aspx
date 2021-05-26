<%@ Page Title="Librarian Home" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .responsive {
          width: 100%;
          max-width: 400px;
          height: auto;
        }
    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" padding-top:3%; height: 500px;">
            <div style="align-content:center; text-align:center;" class="col"> 
                <asp:ImageButton ID="books" runat="server" CssClass="responsive" ImageUrl="/Content/bootstrap-icons/book.svg"  PostBackUrl="~/Librarian/Books/Menu.aspx" />
                <br />
                <h2>Books</h2>
 
            </div>
            <div style="align-content:center; text-align:center;" class="col" >
                <asp:ImageButton ID="borrows" runat="server" CssClass="responsive" ImageUrl="/Content/bootstrap-icons/people.svg" PostBackUrl="~/Librarian/Borrows/Menu.aspx" />
                <br />
                <h2>Borrows</h2>

            </div>
    </div>
    
</asp:Content>
