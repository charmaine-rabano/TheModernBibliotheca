<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheModernBibliotheca.Login" %>

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
    <br />
    <br />
    <br />
    <div class="row">
        <div class="container" style="background-color: aquamarine; text-align: center; font-size: 50px;">
            <br />
            <h1 style="font-size: 50px;">The Modern Bibliotheca</h1>
            <br />
        </div>
    </div>
    <br />
    <br />

    <div class="signin-form col-sm-6 col-12">
        <%-- Error Message --%>
        <asp:CustomValidator ErrorMessage="Error Message" ControlToValidate="EmailTxt" runat="server" ID="loginCv" CssClass="validation-message" />

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

        <!-- Create Account-->
        <div class="col-sm-6 col-12">
            <asp:LinkButton ID="CreateAccount" runat="server" CausesValidation="false" OnClick="CreateAccount_Click">Create Account</asp:LinkButton>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
