<%@ Page Title="Account" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="TheModernBibliotheca.AccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Account Details</h2>

        <div class="row" style="margin-left: auto; margin-top: 20px;">
            <div class="col-sm-6 col-12">
                <h4>Name</h4>
                <%-- Status message --%>
                <div>
                    <div id="nameChangedMessage" class="alert alert-success" role="alert" runat="server" visible="false">
                        Successfully updated name
                    </div>
                </div>

                <%-- First Name --%>
                <div class="form-group">
                    <asp:Label Text="First Name" runat="server" />
                    <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="form-control" type="text" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your first name" ControlToValidate="FirstNameTxt" ValidationGroup="FirstLast" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Last Name --%>
                <div class="form-group">
                    <asp:Label Text="Last Name" runat="server" />
                    <asp:TextBox ID="LastNameTxt" runat="server" CssClass="form-control" type="text" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your last name" ControlToValidate="LastNameTxt" ValidationGroup="FirstLast" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Submit Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="SaveNameBtn" Text="Save Changes" ValidationGroup="FirstLast" runat="server" CssClass="submit-btn btn btn-primary" OnClick="SaveNameBtn_Click" />
                </div>
            </div>

            <div class="col-sm-6 col-12">
                <h4>Change Password</h4>

                <%-- Status message --%>
                <div id="passwordChangedMessage" class="alert alert-success" role="alert" runat="server" visible="false">
                    Successfully updated password
                </div>
                <%-- Current Password --%>
                <div class="form-group">
                    <asp:Label Text="Current Password" runat="server" />
                    <asp:TextBox ID="CurrPasswordTxt" runat="server" CssClass="form-control" type="password" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your current password" ValidationGroup="PasswordGroup" ControlToValidate="CurrPasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
                    <asp:CustomValidator ErrorMessage="Please check your current password" ControlToValidate="CurrPasswordTxt" runat="server" id="CurrentPasswordCv" OnServerValidate="CurrentPasswordCv_ServerValidate" CssClass="validation-message" Display="Dynamic"/>
                </div>

                <%-- New Password --%>
                <div class="form-group">
                    <asp:Label Text="New Password" runat="server" />
                    <asp:TextBox ID="NewPasswordTxt" runat="server" CssClass="form-control" type="password" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your new password" ValidationGroup="PasswordGroup" ControlToValidate="NewPasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Confirm Password --%>
                <div class="form-group">
                    <asp:Label Text="Confirm Password" runat="server" />
                    <asp:TextBox runat="server" ID="ConfirmPasswordTb" CssClass="form-control" TextMode="Password" MaxLength="255" />
                    <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="ConfirmPasswordTb" ValidationGroup="PasswordGroup" runat="server" CssClass="validation-message" Display="Dynamic" />
                    <asp:CompareValidator ErrorMessage="Passwords need to match" ControlToValidate="ConfirmPasswordTb" ValidationGroup="PasswordGroup" runat="server" ControlToCompare="NewPasswordTxt" CssClass="validation-message" Display="Dynamic" Operator="Equal" />
                </div>

                <%-- Submit Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="SavePasswordBtn" Text="Save Changes" ValidationGroup="PasswordGroup" runat="server" CssClass="submit-btn btn btn-primary" OnClick="SavePasswordBtn_Click" />
                </div>
            </div>
        </div>

        <div class="row" style="margin-left: auto;">
            <div class="col-sm-6 col-12">
                <h4>Deactivate Account</h4>
                <%-- Deactivate Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="DeactivateAccount" Text="Deactivate Account" runat="server" CausesValidation="false" CssClass="submit-btn btn btn-danger" OnClick="DeactivateAccount_Click" />
                </div>
            </div>
        </div>

        <!-- Modal for Editing Event -->
        <div class="modal fade" id="modalEdit" tabindex="-1" role="dialog" aria-labelledby="modalEd" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalEd">Confirmation</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        You are about to deactivate your account. Continue?
                    </div>
                    <div class="modal-footer">
                        <asp:Button type="button" ID="ConfirmDeactivate" class="btn btn-primary" CausesValidation="false" runat="server" Text="Yes" OnClick="ConfirmDeactivate_Click" />
                        <asp:Button type="button" ID="no_editlatestevent" class="btn btn-secondary" CausesValidation="false" runat="server" data-dismiss="modal" Text="No" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
