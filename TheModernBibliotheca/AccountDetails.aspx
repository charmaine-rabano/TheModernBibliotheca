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
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your Email" ControlToValidate="FirstNameTxt" ValidationGroup="FirstLast" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Last Name --%>
                <div class="form-group">
                    <asp:Label Text="Last Name" runat="server" />
                    <asp:TextBox ID="LastNameTxt" runat="server" CssClass="form-control" type="text" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your password" ControlToValidate="LastNameTxt" ValidationGroup="FirstLast" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Submit Button --%>
                <div style="display: flex; flex-direction: row;">
                    <asp:Button ID="SaveNameBtn" Text="Save Changes" ValidationGroup="FirstLast" runat="server" CssClass="submit-btn btn btn-primary" OnClick="SaveNameBtn_Click" />
                </div>
            </div>

            <div class="col-sm-6 col-12" style="margin-top: 50px;">
                <h1 style="font-size: 25px;">Change Password</h1>
                <br />
                <%-- Current Password --%>
                <div class="form-group">
                    <asp:Label Text="Current Password" runat="server" />
                    <asp:TextBox ID="CurrPasswordTxt" runat="server" CssClass="form-control" type="password" MaxLength="100" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter your current password" ValidationGroup="PasswordGroup" ControlToValidate="CurrPasswordTxt" runat="server" CssClass="validation-message" Display="Dynamic" />
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
                    <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="ConfirmPasswordTb" runat="server" CssClass="validation-message" Display="Dynamic" />
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
                <br />
                <br />
                <h1 style="font-size: 25px;">Deactivate Account</h1>
                <br />
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
                        <asp:Button type="button" id="ConfirmDeactivate" class="btn btn-primary" CausesValidation="false" runat="server" Text="Yes" OnClick="ConfirmDeactivate_Click"/>
                        <asp:Button type="button" ID="no_editlatestevent" class="btn btn-secondary" CausesValidation="false" runat="server" data-dismiss="modal" Text="No"/>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
