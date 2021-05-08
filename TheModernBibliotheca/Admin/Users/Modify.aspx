<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="TheModernBibliotheca.Admin.Accounts.Modify" %>

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
            <a href="~/Admin/Users" runat="server">
                <button type="button" class="btn btn-secondary">Back</button>
            </a>
        </div>
    </div>

    <div class="form-group row">
        <asp:Label CssClass="col-3" Text="First Name" runat="server" />
        <div class="col-9">
            <asp:TextBox runat="server" ID="FirstNameTb" CssClass="form-control" />
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="FirstNameTb" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <div class="form-group row">
        <asp:Label CssClass="col-3" Text="Last Name" runat="server" />
        <div class="col-9">
            <asp:TextBox runat="server" ID="LastNameTb" CssClass="form-control" />
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="FirstNameTb" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <div class="form-group row">
        <asp:Label CssClass="col-3" Text="Email Address" runat="server" />
        <div class="col-9">
            <asp:TextBox runat="server" ID="EmailAddressTb" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="FirstNameTb" runat="server" CssClass="validation-message" Display="Dynamic" />
            <asp:CustomValidator ID="EmailAddressCv" ErrorMessage="" ControlToValidate="EmailAddressTb" runat="server" OnServerValidate="EmailAddressCv_ServerValidate" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <div class="form-group row">
        <asp:Label CssClass="col-3" Text="User Type" runat="server" />
        <div class="col-9">
            <asp:DropDownList runat="server" ID="UserTypeDdl" CssClass="form-control">
                <asp:ListItem Text="Borrower" />
                <asp:ListItem Text="Librarian" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="FirstNameTb" runat="server" CssClass="validation-message" Display="Dynamic" />
        </div>
    </div>

    <div class="form-group row">
        <asp:Label CssClass="col-3" Text="Password" runat="server" />
        <div class="col-9">
            <asp:TextBox runat="server" ID="PasswordTb" CssClass="form-control" TextMode="Password" />
        </div>
    </div>
    <div class="form-group row">
        <asp:Label CssClass="col-3" Text="Confirm Password" runat="server" />
        <div class="col-9">
            <asp:TextBox runat="server" ID="ConfirmPasswordTb" CssClass="form-control" TextMode="Password" />
            <asp:CompareValidator ErrorMessage="Passwords need to match" ControlToValidate="ConfirmPasswordTb" runat="server" ControlToCompare="PasswordTb" CssClass="validation-message" Display="Dynamic" Operator="Equal" />
        </div>
    </div>
    <div class="form-action">
        <asp:Button Text="Delete" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" CssClass="btn btn-danger alternative-action" />

        <asp:Button Text="Submit" runat="server" ID="SubmitBtn" OnClick="SubmitBtn_Click" CssClass="btn btn-primary primary-action" />
    </div>
</asp:Content>
