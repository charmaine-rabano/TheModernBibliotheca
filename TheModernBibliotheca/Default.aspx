<%@ Page Title="Home" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex">
        <h2>Browse Books</h2>
    </div>
    <hr />
    <h5>Filter</h5>
    <div style="display: flex; flex-wrap: wrap;">
        <div>
            Availability
            <asp:DropDownList runat="server" CssClass="form-control" OnSelectedIndexChanged="AvailabilityDdl_SelectedIndexChanged" ID="AvailabilityDdl" AutoPostBack="True">
                <asp:ListItem Text="All" />
                <asp:ListItem Text="Available" />
                <asp:ListItem Text="Unavailable" />
            </asp:DropDownList>
        </div>

        <div class="mx-1">
            Search Title
            <div style="display: flex">
                <asp:TextBox class="form-control mr-1" ID="txtSearch" placeholder="Title" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" class="btn btn-secondary" Text="Search" runat="server" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
    <hr />
    <div class="row" style="text-align: center;">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="col-sm-6 col-md-4 col-lg-3 p-3">
                    <div class="card h-100" style="text-align: left">
                        <br />
                        <img class="card-img-top" src='<%# Eval("BookCover")%>' alt="<Picture Object>" />
                        <div class="card-body" style="display: flex; flex-direction: column; height: ">
                            <h5 class="card-title">
                                <%# FormatString(Eval("Title").ToString(), 15) %>
                            </h5>
                            <b>
                                <%# FormatString(Eval("Author").ToString(), 20) %>
                            </b>
                            <p class="">
                                <%# FormatString(Eval("Summary").ToString(), 70) %>
                            </p>
                            <div style="margin-top: auto; display: flex;">
                                <a href='Books?ID=<%# Eval("ISBN")%>' class="btn btn-secondary" style="">Details</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
