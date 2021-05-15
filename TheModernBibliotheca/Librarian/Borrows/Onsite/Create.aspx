<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Onsite.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        input, select {
            max-width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="padding-top: 60px; display: flex; align-items: center;">
        <a href="../Menu.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>
        <h4 style="margin-right: 20px">Onsite Borrowing</h4>
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="Create.aspx">Create Borrower Account</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Borrow.aspx">Record Book Borrow</a>
            </li>
        </ul>   
    </div>

    <div class="row" style="padding-top: 60px">
        <div class="column col-12">
            <div id="SuccessAlert" class="alert alert-success" role="alert" runat="server">
              Successfully created borrower account for <asp:Label ID="AlertEmail" runat="server" Text=""></asp:Label>
            </div>

            <h3>Create Borrower Account</h3>

            <div style="margin-top: 40px">
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

                <div style="display: flex; align-items: center; margin-top: 40px;">
                    <asp:LinkButton ID="ResetBtn" runat="server" style="margin-left:auto; margin-right: 20px;" CausesValidation="False" OnClick="ResetBtn_Click">Reset</asp:LinkButton>
                    <asp:Button ID="CreateBtn" Text="Create Borrower Account" runat="server" CssClass="btn btn-primary" OnClick="CreateBtn_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
