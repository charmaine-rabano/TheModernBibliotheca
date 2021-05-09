<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="TheModernBibliotheca.AccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <h1 style="font-size: 60px;">Account Details</h1>
        <br />
        <br />
        <div class="col-6">
            <div style="display: flex;">
                <div class="col-6" style="font-size: 21px;">
                    <asp:Label runat="server">Complete Name</asp:Label>
                </div>
                <div class="col-6">
                    <asp:TextBox class="form-control" ID="txtCompleteName" ReadOnly="true" runat="server" Width="250"></asp:TextBox>
                </div>
            </div>
            <br />
            <div style="display: flex;">
                <div class="col-6" style="font-size: 21px;">
                    <asp:Label runat="server">E-mail</asp:Label>
                </div>
                <div class="col-6">
                    <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" runat="server" Width="250"></asp:TextBox>
                </div>
            </div>
            <br />
            <div style="display: flex;">
                <div class="col-6" style="font-size: 21px;">
                    <asp:Label runat="server">Password</asp:Label>
                </div>
                <div class="col-6">
                    <asp:TextBox class="form-control" ID="txtPassword" ReadOnly="true" type="password" runat="server" Width="250"></asp:TextBox>
                </div>
            </div>
        </div>

        <br />
        <br />

        <div>
            <h1 style="font-size: 60px;">Reservation Details</h1>
            <br />
            <br />
            <% if (isRepeater)
                {%>

            <div style="background-color: #E1D9D9">
                <br />
                <p style="font-style: italic; text-align: center;">You have not made any reservations.</p>
                <br />
            </div>

            <%}%>
            <%else
                {%>

            

            <%} %>
        </div>

        <br />
        <br />

        <div>
            <h1 style="font-size: 60px;">Borrowed Books</h1>
            <br />
            <br />
            <% if (isRepeater)
                {%>

            <div style="background-color: #E1D9D9">
                <br />
                <p style="font-style: italic; text-align: center;">You have not borrowed any books.</p>
                <br />
            </div>

            <%}%>
            <%else
                {%>

            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">ISBN</th>
                        <th scope="col">Date Reserved</th>
                        <th scope="col">Status</th>
                    </tr>
                </thead>
                <tbody style="background-color: #E1D9D9;">
                    <tr>
                        <td>123412341234</td>
                        <td>Educational</td>
                        <td>Off-shelf</td>
                    </tr>
                </tbody>
            </table>

            <%} %>
        </div>
    </div>
</asp:Content>
