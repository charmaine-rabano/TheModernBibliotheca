<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css">
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
        }


            .menu-icon-image img {
                margin: auto;
                height: 50%;
                width: auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menu-group-container">
        <div>
            <p class="menu-group-header">Users</p>
            <div class="menu-container">
                <a href="~/Admin/Users" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/people.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>View Users</span>
                    </div>
                </a>

                <a href="~/Admin/Users/Add?FromHome=true" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/person-plus.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>Add User</span>
                    </div>
                </a>

            </div>
        </div>
        <div>
            <p class="menu-group-header">Monitoring</p>
            <div class="menu-container">
                <a href="~/Admin/Activity" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/journal-text.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>View Activity</span>
                    </div>
                </a>
            </div>
        </div>
        <div>
            <p class="menu-group-header">Navigate</p>
            <div class="menu-container">
                <a href="~/Librarian" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/book.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>Librarian Interface</span>
                    </div>
                </a>

                <a href="~/" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/house.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <span>Website Home</span>
                    </div>
                </a>
            </div>
        </div>
    </div>

</asp:Content>
