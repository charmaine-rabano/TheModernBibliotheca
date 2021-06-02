<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/Templates/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheModernBibliotheca.Admin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .signin-form {
            display: flex;
            flex-direction: column;
            align-items: center;
            max-width: 450px;
            margin: auto;
        }

            .signin-form > * {
                max-width: 100%;
                width: 100%
            }

        .login-header {
            display: flex;
            align-items: baseline;
        }

        .form-control {
            max-width: 100%;
            width: 100%
        }

        .submit-btn {
            margin-left: auto;
            width: 14ch;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="signin-form px-2">

        <%-- Brand Logo --%>
        <asp:Image ImageUrl="~/Pictures/Logo.png" runat="server" CssClass="login-brand-logo" Style="margin-top: 100px; margin-bottom: 20px; padding: 30px;" BackColor="#D9C5A0" />

        <%-- Login Header --%>
        <div class="login-header">
            <h3 class="my-3">Admin Sign In</h3>
        </div>
        <div id="loginMessageDiv" class="alert alert-danger" role="alert" runat="server" visible="false">
            Please check your email and password
        </div>

        <%-- Email --%>
        <div class="form-group">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="EmailTxt" runat="server" CssClass="form-control" type="email" MaxLength="100" />
            <asp:RequiredFieldValidator ErrorMessage="Please enter your Email" ControlToValidate="EmailTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>

        <%-- Password --%>
        <div class="form-group">
            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="PasswordTxt" runat="server" CssClass="form-control" type="password" MaxLength="100" />
            <asp:RequiredFieldValidator ErrorMessage="Please enter your password" ControlToValidate="PasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>

        <%-- Submit Button --%>
        <div style="display: flex; flex-direction: row;">
            <asp:Button ID="SubmitBtn" Text="Sign In" runat="server" CssClass="submit-btn btn btn-primary" OnClick="SubmitBtn_Click" />
        </div>
    </div>
</asp:Content>
