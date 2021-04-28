<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheModernBibliotheca.Admin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="EmailTb"/>
    <asp:TextBox runat="server" ID="PasswordTb"/>
    <asp:Button Text="Submit" runat="server"  ID="SubmitBtn" OnClick="SubmitBtn_Click"/>
</asp:Content>
