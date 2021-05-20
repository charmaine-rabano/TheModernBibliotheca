<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm8" %>
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
    <div style="width: 100%; display: table; padding-top:3%;">
        <div style="display: table-row; height: 500px;">
            <div style="width: 50%; display: table-cell;  align-content:center;text-align:center;" >
                <asp:ImageButton ID="librarian" runat="server" CssClass="responsive" ImageUrl="/Content/bootstrap-icons/person.svg" OnClick="librarian_Click" />
                <br />
                Librarian

            </div>
            <div style="display: table-cell;  align-content:center; text-align:center;"> 
                <asp:ImageButton ID="books" runat="server" CssClass="responsive" ImageUrl="/Content/bootstrap-icons/book.svg" OnClick="books_Click"  />
                <br />
                Books
 
            </div>
        </div>
    </div>
    
</asp:Content>
