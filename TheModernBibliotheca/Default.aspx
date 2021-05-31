<%@ Page Title="Home" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .book-link {
            color:#222;
        }

        .book-link:hover {
            text-decoration:none;
            color:#222;
        }

        .book-cover-container:hover {
            filter:brightness(80%);
        }

        .book-cover-container {
            background:#DDD;
            height: 300px;
            overflow:hidden;
        }

        .book-cover {
            height: auto;
            width: 100%;
        }

    </style>
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
                <div class="col-sm-6 col-md-4 col-lg-3 p-3 pt-0">
                    <a href='Books?ID=<%# Eval("ISBN")%>' class="book-link">
                        <div class="card h-100 book-item" style="text-align: left">
                            <div class="book-cover-container">
                                <img class="card-img-top book-cover" src='<%# Eval("BookCover")%>' alt="<Picture Object>" />
                            </div>

                            <div class="card-body" style="display: flex; flex-direction: column;">
                                <div><span style="font-weight:700; font-size:1.2rem"><%# FormatString(Eval("Title").ToString(), 15) %></span></div>

                                <div><span style="font-weight:500"><%# "By " + FormatString(Eval("Author").ToString(), 20) %></span></div>
                                <div><span><%# GetAvailablility(Eval("ISBN").ToString()) %></span></div>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="Label1" runat="server" Text="No Results Found." style="font-size:xx-large; align-content:center;" Visible="false"></asp:Label>

    </div>
</asp:Content>
