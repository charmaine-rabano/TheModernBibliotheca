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
                
                    <p>hello</p>
                
                <%}%>
            <%else {%> 

                    <p>goodbye</p>
                
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
                
                    <p>hello</p>
                
                <%}%>
            <%else {%> 

                    <p>goodbye</p>
                
                <%} %>
        </div>
    </div>
</asp:Content>
