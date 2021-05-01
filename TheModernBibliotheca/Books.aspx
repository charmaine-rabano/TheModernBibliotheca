﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="TheModernBibliotheca.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1 style="font-size: 60px;">Book Details</h1>
    <br />
    <br />
    <div class="row">
        <div class="col-3" style="display: flex; flex-direction: column; align-items: center; padding-right: 15px;">
            <img class="img-thumbnail" src="<%#Eval("ImgUrl")%>" alt="hello" />
            <br />
            <asp:Label ID="lblBookQuantity" runat="server">Quantity: 123</asp:Label>
        </div>
        <div class="col-9">
            <h2>
                <asp:Label ID="txtTitle" runat="server">Tekken 7: Frame Data Guide</asp:Label></h2>
            <h4>
                <asp:Label ID="txtAuthor" runat="server">Mark Anthony Mamauag</asp:Label></h4>
            <br />
            <h5>Summary</h5>
            <asp:Label ID="txtSummary" style="font-weight: 400;" runat="server">Lorem ipsum dolor sit amet, 
            consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat 
            cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </asp:Label>
            <br />
            <br />
            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">ISBN</th>
                        <th scope="col">Genre</th>
                        <th scope="col">Status</th>
                    </tr>
                </thead>
                <tbody style="background-color: burlywood;">
                    <tr>
                        <td>123412341234</td>
                        <td>Educational</td>
                        <td>Off-shelf</td>
                    </tr>
                </tbody>
            </table>

            <br />
            <br />

            <div style="display: flex; justify-content: flex-end;">
                <asp:Button class="btn btn-success" ID="btnCreateReservation" runat="server" Text="Create Reservation" OnClick="btnCreateReservation_Click"/>&nbsp;&nbsp;
                <asp:Button class="btn btn-secondary" ID="btnHomePage" runat="server" Text="Back To Home Page" OnClick="btnHomePage_Click"/>
            </div>    
        </div>
    </div>
</asp:Content>
