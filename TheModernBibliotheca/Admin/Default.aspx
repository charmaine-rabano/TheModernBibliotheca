<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css">
    <style>
        .menu-group-container > div {
            margin-bottom: 3rem;
        }

        .menu-container {
            display: flex;
            flex-direction: row;
        }

        .menu-group-header {
            margin-bottom: 1.5rem;
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
                font-weight: 600;
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
            <h2 class="menu-group-header">Users</h2>
            <div class="menu-container">
                <a href="~/Admin/Users" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/people.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <p>View Users</p>
                    </div>
                </a>

                <a href="~/Admin/Add" class="menu-item-container" runat="server">
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
            <h2 class="menu-group-header">Monitoring</h2>
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
            <h2 class="menu-group-header">Navigate</h2>
            <div class="menu-container">
                <a href="#" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="../Content/bootstrap-icons/book.svg" alt="View Accounts" class="text-success" />
                        </div>
                        <p>Librarian Interface</p>
                    </div>
                </a>

                <a href="#" class="menu-item-container" runat="server">
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
