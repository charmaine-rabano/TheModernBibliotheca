<%@ Page Title="Home" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div style="display: flex">
        <h1 style="font-size: 60px;">Browse Items</h1>
        <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
            <asp:TextBox class="form-control" ID="txtSearch" placeholder="Search" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="btnSearch" class="btn btn-secondary" Text="Search" runat="server" OnClick="btnSearch_Click" />
        </div>
    </div>
    <br />
    <div class="container">
        <asp:Button class="btn btn-primary" ID="SeeAvailable" runat="server" Text="See Available Books" OnClick="SeeAvailable_Click" />
    </div>
    <br />
    <br />
    <div class="row" style="text-align: center;">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="col-3 p-2">
                    <div class="card" style="min-height: 250px">
                        <br />
                        <img class="card-img-top" src='<%# Eval("BookCover")%>' alt="<Picture Object>" />
                        <div class="card-body" style="display: flex; flex-direction: column;">
                            <h5 class="card-title"><%# Eval("Title")%></h5>
                            <div style="margin-top: auto;">
                                <a href='Books?ID=<%# Eval("ISBN")%>' class="btn btn-secondary" style="background-color: burlywood">Details</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <br />
    <br />
</asp:Content>
