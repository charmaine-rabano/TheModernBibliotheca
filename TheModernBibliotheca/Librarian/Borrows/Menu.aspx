<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Menu" %>

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
            <p class="menu-group-header">Offsite Borrowing</p>
            <div class="menu-container">
                <a href="Offsite/Approve.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="\Content\bootstrap-icons\check2-square.svg" alt="Approve Reservations" class="text-success" />
                        </div>
                        <span>Approve Reservations</span>
                    </div>
                </a>

                <a href="Offsite/Pending.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="\Content\bootstrap-icons\calendar-event.svg" alt="View Pending Reservations" class="text-success" />
                        </div>
                        <span>View Pending Reservations</span>
                    </div>
                </a>

            </div>
        </div>
        <div>
            <p class="menu-group-header">Onsite Borrowing</p>
            <div class="menu-container">
                <a href="Onsite/Create.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="\Content\bootstrap-icons\person.svg" alt="Create Borrower Account" class="text-success" />
                        </div>
                        <span>Create Borrower Account</span>
                    </div>
                </a>
                
                <a href="Onsite/Borrow.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="\Content\bootstrap-icons\clipboard.svg" alt="Record Book Borrow" class="text-success" />
                        </div>
                        <span>Record Book Borrow</span>
                    </div>
                </a>
            </div>
        </div>
        <div>
            <p class="menu-group-header">Book Return</p>
            <div class="menu-container">
                <a href="Return.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="\Content\bootstrap-icons\book.svg" alt="Record Book Return" class="text-success" />
                        </div>
                        <span>Record Book Return</span>
                    </div>
                </a>
            </div>
        </div>
        <div>
            <p class="menu-group-header">Borrow History</p>
            <div class="menu-container">
                <a href="History.aspx" class="menu-item-container" runat="server">
                    <div class="menu-item">
                        <div class="menu-icon-image">
                            <img src="\Content\bootstrap-icons\inboxes.svg" alt="View Borrow History" class="text-success" />
                        </div>
                        <span>View Borrow History</span>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
