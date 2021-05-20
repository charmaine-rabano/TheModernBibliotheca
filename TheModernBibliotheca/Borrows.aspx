<%@ Page Title="Borrows" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Borrows.aspx.cs" Inherits="TheModernBibliotheca.Borrows" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .borrow-container {
            margin-bottom: 30px;
        }

        .borrow-details {
            background-color: #f7f5f0;
        }

        .book-image {
            width: 100%;
            height: auto;
        }

        .borrow-status {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            padding: 0;
        }

            .borrow-status .status-container {
                margin: auto auto;
                text-align: center;
                padding: 30px 0;
            }

                .borrow-status .status-container .status-message {
                    padding: 10px 20px;
                    font-size: 1.2rem;
                    border-radius: 80px;
                    min-width: 10ch;
                    min-height: 1rem;
                }

            .borrow-status .return-date {
                margin-top: auto;
                background-color: #ede6d3;
                width: 100%;
                padding: 10px;
                text-align: center;
            }

        .empty-message {
            font-size: 1.6em;
        }

        .status-requested {
            background-color: #fcf7ca;
        }

        .status-approved {
            background-color: #cafcd0;
        }

        .status-rejected {
            background-color: #fcd9d9;
        }

        .status-borrowed {
            background-color: #aed6f5;
        }

        .status-returned {
            background-color: #e3e3e3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="borrow-container">
        <h4>Latest Borrow</h4>

        <%if (model != null) %>
        <%{%>
        <div class="row m-sm-3 m-1 borrow-details">
            <div class="col-lg-8 row m-0 p-3">
                <div class="col-sm-3 mb-sm-0 mb-3">
                    <img src='<%=model.Image %>' alt="Alternate Text" class="book-image" />
                </div>
                <div class="col-sm-9">
                    <span>ISBN:<span><%= model.Isbn %></span></span>
                    <h5 id="book-title"><%= model.Title %></h5>
                    <span><%= model.Author %></span>
                    <p><%= model.Blurb %></p>
                </div>
            </div>
            <div class="col-lg-4 col-12 borrow-status">
                <div class="status-container">
                    <span>Status</span>
                    <div class='<%=(
                            model.Status == "Requested" ? "status-message status-requested" :
                            model.Status == "Approved" ? "status-message status-approved" : 
                            model.Status == "Rejected" ? "status-message status-rejected" : 
                            model.Status == "Borrowed" ? "status-message status-borrowed": 
                            model.Status == "Returned" ? "status-message status-returned" : "status-message")%>'>
                        <span><%= model.Status %></span>
                    </div>
                </div>
                <div class="return-date">
                    <span>Return Date: <span><%= model.ReturnDate.ToString("MMM dd, yyyy") %></span></span>
                </div>
            </div>
        </div>
        <%}%>
        <% else %>
        <% {%>
        <div style="text-align: center">
            <p class="empty-message my-4">You are not currently borrowing a book</p>
        </div>
        <% }%>
    </div>

    <div>
        <h4>Borrow History</h4>
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>ISBN</th>
                        <th>Title</th>
                        <th>Author</th>
                        <th>Date Borrowed</th>
                        <th>Date Returned</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="BorrowHistoryTableRepeater">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("Isbn")%></td>
                                <td><%#Eval("Title")%></td>
                                <td><%#Eval("Author")%></td>
                                <td><%#Eval("DateBorrowed", "{0:MMM dd, yyyy}")%></td>
                                <td><%#Eval("DateReturned", "{0:MMM dd, yyyy}")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>

            </table>

        </div>
    </div>
</asp:Content>
