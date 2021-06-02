<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        :root {
        }

        .menu-group-container > div {
            margin-bottom: 4rem;
        }

        .menu-container {
            padding: 0 20px;
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
        }

        .menu-group-header {
            background-color: #D9C5A0;
            padding: .6rem 1rem;
            font-size: 1.6rem;
            margin-bottom: 1rem;
            font-weight: 600;
        }

        .menu-item-container {
            margin-right: 3rem;
        }

        .menu-item {
            margin-top: 20px;
            display: flex;
            flex-direction: row;
            align-items: center;
        }

            .menu-item span {
                color: black;
                font-weight: 500;
                font-size: 1.4rem;
                margin: 0;
            }

        .menu-icon-image {
            width: 3.5rem;
            height: 3.5rem;
            background-color: #D9C5A0;
            margin: 0;
            margin-right: 1rem;
            border-radius: 100%;
            display: flex;
            flex-direction: column;
            flex-shrink:0;
        }


            .menu-icon-image img {
                margin: auto;
                height: 50%;
                width: auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top:2px; padding-bottom:2px; margin-bottom: 20px;">
        <a href="../Default.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="40" height="40" style="margin-right: 10px" /></a>
    </div>
    <div class="menu-group-container">
        <div>
            <p class="menu-group-header">Books</p>
            <div class="menu-container">
                <a href="Default.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="/Content/bootstrap-icons/search.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>View & Edit</span>
                    </div>
                </a>

                <a href="Add.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="/Content/bootstrap-icons/plus.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>Add Book</span>
                    </div>
                </a>

           
            </div>
        </div>
        
        <div>
            <p class="menu-group-header">Create Report</p>
            <div class="menu-container">
                <a href="~/Librarian/Report/InCirculation.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="/Content/bootstrap-icons/book.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>In Circulation</span>
                    </div>
                </a>

                <a href="~/Librarian/Report/Overall.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="/Content/bootstrap-icons/bookshelf.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>Overall</span>
                    </div>
                </a>
                <a href="~/Librarian/Report/BorrowersWithPenalty.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="/Content/bootstrap-icons/person-x.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>Borrowers With Penalty </span>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
