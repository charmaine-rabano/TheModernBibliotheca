<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="TheModernBibliotheca.AccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <h1 style="font-size: 45px;">Account Details</h1>

        <div class="row" style="margin-left: auto;">
            <div class="col-sm-6 col-12" style="margin-top: 50px;">
                <h1 style="font-size: 25px;">Name</h1>
                <br />
                <%-- First Name --%>
                <div class="form-group">
                    <asp:Label Text="First Name" runat="server" />
                    <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="form-control" type="text" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your Email" ControlToValidate="FirstNameTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Last Name --%>
                <div class="form-group">
                    <asp:Label Text="Last Name" runat="server" />
                    <asp:TextBox ID="LastNameTxt" runat="server" CssClass="form-control" type="text" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your password" ControlToValidate="LastNameTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Submit Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="SaveNameBtn" Text="Save Changes" runat="server" CssClass="submit-btn btn btn-primary" OnClick="SaveNameBtn_Click" />
                </div>
            </div>

            <div class="col-sm-6 col-12" style="margin-top: 50px;">
                <h1 style="font-size: 25px;">Change Password</h1>
                <br />
                <%-- Current Password --%>
                <div class="form-group">
                    <asp:Label Text="Current Password" runat="server" />
                    <asp:TextBox ID="CurrPasswordTxt" runat="server" CssClass="form-control" type="password" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your current password" ControlToValidate="CurrPasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- New Password --%>
                <div class="form-group">
                    <asp:Label Text="New Password" runat="server" />
                    <asp:TextBox ID="NewPasswordTxt" runat="server" CssClass="form-control" type="password" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your new password" ControlToValidate="NewPasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Confirm Password --%>
                <div class="form-group">
                    <asp:Label Text="Confirm Password" runat="server" />
                    <asp:TextBox runat="server" ID="ConfirmPasswordTb" CssClass="form-control" TextMode="Password" MaxLength="255" />
                    <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="ConfirmPasswordTb" runat="server" CssClass="validation-message" Display="Dynamic" />
                    <asp:CompareValidator ErrorMessage="Passwords need to match" ControlToValidate="ConfirmPasswordTb" runat="server" ControlToCompare="NewPasswordTxt" CssClass="validation-message" Display="Dynamic" Operator="Equal" />
                </div>

                <%-- Submit Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="SavePasswordBtn" Text="Save Changes" runat="server" CssClass="submit-btn btn btn-primary" OnClick="SavePasswordBtn_Click" />
                </div>
            </div>
        </div>

        <div class="row" style="margin-left: auto;">
            <div class="col-sm-6 col-12">
                <br />
                <br />
                <h1 style="font-size: 25px;">Deactivate Account</h1>
                <br />
                <%-- Submit Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="DeactivateAccount" Text="Deactivate Account" runat="server" CssClass="submit-btn btn btn-danger" OnClick="DeactivateAccount_Click" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
