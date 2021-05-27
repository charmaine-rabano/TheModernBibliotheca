<%@ Page Title="Add User" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="TheModernBibliotheca.Admin.Accounts.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        input, select {
            max-width: 100%;
        }

        .form-action {
            display: flex;
        }

        .primary-action {
            margin-left: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-group">
        <h3>Add User</h3>
        <div class="header-actions">
            <a href="~/Admin/Users" runat="server" id="cancelLink" class="btn btn-secondary">
                Back
            </a>
        </div>
    </div>

    <%-- First Name --%>
    <div class="form-group row">
        <asp:Label CssClass="col-sm-3 col-12" Text="First Name" runat="server" />
        <div class="col-sm-9 col-12">
            <asp:TextBox runat="server" ID="FirstNameTb" CssClass="form-control" MaxLength="127"/>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="FirstNameTb" runat="server" CssClass="validation-message" Display="Dynamic"/>
        </div>
    </div>

    <%-- Last Name --%>
    <div class="form-group row">
        <asp:Label CssClass="col-sm-3 col-12" Text="Last Name" runat="server" />
        <div class="col-sm-9 col-12">
            <asp:TextBox runat="server" ID="LastNameTb" CssClass="form-control"  MaxLength="127"/>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="LastNameTb" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <%-- Email Address --%>
    <div class="form-group row">
        <asp:Label CssClass="col-sm-3 col-12" Text="Email Address" runat="server" />
        <div class="col-sm-9 col-12">
            <asp:TextBox runat="server" ID="EmailAddressTb" CssClass="form-control" TextMode="Email"  MaxLength="127"/>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="EmailAddressTb" runat="server" CssClass="validation-message" Display="Dynamic" />
            <asp:RegularExpressionValidator ErrorMessage="Please enter a valid email address" ControlToValidate="EmailAddressTb" runat="server" CssClass="validation-message" Display="Dynamic" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
            <asp:CustomValidator ID="EmailAddressCv" ErrorMessage="" ControlToValidate="EmailAddressTb" runat="server" OnServerValidate="EmailAddressCv_ServerValidate" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <%-- User Type --%>
    <div class="form-group row">
        <asp:Label CssClass="col-sm-3 col-12" Text="User Type" runat="server" />
        <div class="col-sm-9 col-12">
            <asp:DropDownList runat="server" ID="UserTypeDdl" CssClass="form-control">
                <asp:ListItem Text="Borrower" />
                <asp:ListItem Text="Librarian" />
                <asp:ListItem Text="Admin" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="UserTypeDdl" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <%-- Password --%>
    <div class="form-group row">
        <asp:Label CssClass="col-sm-3 col-12" Text="Password" runat="server" />
        <div class="col-sm-9 col-12">
            <asp:TextBox runat="server" ID="PasswordTb" CssClass="form-control" TextMode="Password"  MaxLength="255"/>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="PasswordTb" runat="server" CssClass="validation-message" Display="Dynamic" />
            <asp:RegularExpressionValidator ErrorMessage="Password must have at least 5 characters" ControlToValidate="PasswordTb" runat="server" ValidationExpression="^.{5,}$" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <%-- Confirm Password --%>
    <div class="form-group row">
        <asp:Label CssClass="col-sm-3 col-12" Text="Confirm Password" runat="server" />
        <div class="col-sm-9 col-12">
            <asp:TextBox runat="server" ID="ConfirmPasswordTb" CssClass="form-control" TextMode="Password"  MaxLength="255"/>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="ConfirmPasswordTb" runat="server" CssClass="validation-message" Display="Dynamic" />
            <asp:CompareValidator ErrorMessage="Passwords need to match" ControlToValidate="ConfirmPasswordTb" runat="server" ControlToCompare="PasswordTb" CssClass="validation-message" Display="Dynamic" Operator="Equal" />
        </div>
    </div>

    <div class="form-action">
        <asp:Button Text="Submit" runat="server" ID="SubmitBtn" OnClick="SubmitBtn_Click" CssClass="btn btn-primary primary-action" />
    </div>
</asp:Content>
