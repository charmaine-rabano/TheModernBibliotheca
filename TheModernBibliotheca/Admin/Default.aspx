<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Admin.Default" %>

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
        }

        .menu-group-header {
            background-color:lightgray;
            padding:.4rem .6rem;
            font-size: 1.7rem;
            margin-bottom: 1.8rem;
            font-weight: 600;
        }

        .menu-item-container {
            margin-right: 5rem;
        }

        .menu-item {
            display: flex;
            flex-direction: row;
            align-items: center;
        }

            .menu-item p {
                color: black;
                font-weight: 500;
                font-size: 1.4rem;
                margin: 0;
            }

        .menu-icon-image {
            width: 3.5rem;
            height: 3.5rem;
            background-color: lightgray;
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
                        <p>View Users</p>
                    </div>
                </a>

                <a href="~/Admin/Users/Add?FromHome=true" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/person-plus.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <p>Add User</p>
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
                        <p>View Activity</p>
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
                        <p>Librarian Interface</p>
                    </div>
                </a>

                <a href="~/" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/house.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <p>Website Home</p>
                    </div>
                </a>
            </div>
        </div>
    </div>

</asp:Content>
