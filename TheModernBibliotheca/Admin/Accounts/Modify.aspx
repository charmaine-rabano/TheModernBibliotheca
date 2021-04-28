<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="TheModernBibliotheca.Admin.Accounts.Modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox runat="server" ID="FirstNameTb" />
    <asp:TextBox runat="server" ID="LastNameTb" />
    <asp:TextBox runat="server" ID="EmailAddressTb" />
    <asp:TextBox runat="server" ID="PasswordTb" />

    <asp:DropDownList runat="server" ID="UserTypeDdl">
        <asp:ListItem Text="Borrower" />
        <asp:ListItem Text="Librarian" />
    </asp:DropDownList>

    <asp:TextBox runat="server" ID="ConfirmPasswordTb" />
    <asp:Button Text="Submit" runat="server" ID="SubmitBtn" OnClick="SubmitBtn_Click" />
    <asp:Button Text="Delete" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />

</asp:Content>
