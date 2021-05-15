<%@ Page Title="Home" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div style="display: flex">
        <h1 style="font-size: 60px;">Browse Items</h1>
        <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
            <asp:TextBox class="form-control" ID="txtSearch" placeholder="Search" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="btnSearch" class="btn btn-secondary" Text="Search" runat="server" OnClick="btnSearch_Click"/>
        </div>
    </div>
    <br />
    <div class="container">
        <asp:Button class="btn btn-primary" ID="SeeAvailable" runat="server" Text="See Available Books" OnClick="SeeAvailable_Click"/>
    </div>
    <div class="row">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="card col-3 m-5" style="width: 18rem">
                    <br />
                    <img class="card-img-top" src='<%# Eval("BookCover")%>' alt="Card image cap" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Title")%></h5>
                        <a href='Books?ID=<%# Eval("ISBN")%>' class="btn btn-secondary" style="background-color: burlywood">Details</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
