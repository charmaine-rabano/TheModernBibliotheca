<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        
        <div style="display: flex; margin-bottom:30px; margin-top:10px;">
            <h4>Manage Books</h4>
            <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
                <a href="Add.aspx"  class="btn btn-primary btn-block">Add New Book </a>
            </div>
        </div>

        <div style="display: flex">
            <asp:DropDownList ID="bookGenreDropDown" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="bookGenreDropDown_SelectedIndexChanged"></asp:DropDownList>
            <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
                <asp:TextBox class="form-control" ID="txtSearch" placeholder="Search" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnSearch" class="btn btn-secondary" Text="Search" runat="server" OnClick="btnSearch_Click"/>
            </div>
        </div>

    <div class="row">
        <asp:Repeater ID="bookRepeater" runat="server">
            <ItemTemplate>
                <div class="card col-3 m-5" style="width: 18rem">
                    <br />
                    <img class="card-img-top" src='<%# Eval("BookCover")%>' alt="Card image cap" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Title")%></h5>
                        <p class="card-text"><%# Eval("Summary")%></p>
                        <a href='Book?ID=<%# Eval("ISBN")%>' class="btn btn-primary" >Details</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
        </div>
    <div id="noResultsMessage" style="font-size:xx-large; text-align:center; padding-top:2em;"  runat="server" visible="false">
            No Results Found.
        </div>
</asp:Content>


