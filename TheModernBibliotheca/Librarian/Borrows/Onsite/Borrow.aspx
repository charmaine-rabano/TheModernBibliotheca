<%@ Page Title="Borrow Onsite" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Borrow.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Onsite.Borrow" %>

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
                <a class="nav-link" href="Create.aspx">Create Borrower Account</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="Borrow.aspx">Record Book Borrow</a>
            </li>
        </ul>   
    </div>

    <div class="row" style="padding-top: 60px">
        <div class="column col-12">
            <div id="SuccessAlert" class="alert alert-success" role="alert" runat="server">
              Successfully recorded borrow of book ISBN <asp:Label ID="AlertISBN" runat="server" Text=""></asp:Label> for <asp:Label ID="AlertEmail" runat="server" Text=""></asp:Label>
            </div>

            <h3>Record Book Borrow</h3>

            <div style="margin-top: 40px">
                <%-- Borrow Date --%>
                <div class="form-group row">
                    <asp:Label CssClass="col-sm-3 col-12" Text="Borrow Date" runat="server" />
                    <div class="col-sm-9 col-12">
                        <asp:TextBox runat="server" ID="BorrowDateTb" CssClass="form-control" type="date" />
                        <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="BorrowDateTb" runat="server" CssClass="validation-message" Display="Dynamic"/>
                    </div>
                </div>

                <%-- Book ISBN --%>
                <div class="form-group row">
                    <asp:Label CssClass="col-sm-3 col-12" Text="Book ISBN" runat="server" />
                    <div class="col-sm-9 col-12">
                        <asp:TextBox runat="server" ID="BookISBNTb" CssClass="form-control"  MaxLength="127"/>
                        <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="BookISBNTb" runat="server" CssClass="validation-message" Display="Dynamic" />
                        <asp:CustomValidator ID="BookISBNCv" ErrorMessage="" ControlToValidate="BookISBNTb" runat="server" CssClass="validation-message" Display="Dynamic" OnServerValidate="BookISBNCv_ServerValidate" />
                    </div>
                </div>

                <%-- Borrower Email --%>
                <div class="form-group row">
                    <asp:Label CssClass="col-sm-3 col-12" Text="Borrower Email" runat="server" />
                    <div class="col-sm-9 col-12">
                        <asp:TextBox runat="server" ID="BorrowerEmailTb" CssClass="form-control" TextMode="Email"  MaxLength="127"/>
                        <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="BorrowerEmailTb" runat="server" CssClass="validation-message" Display="Dynamic" />
                        <asp:RegularExpressionValidator ErrorMessage="Please enter a valid email address" ControlToValidate="BorrowerEmailTb" runat="server" CssClass="validation-message" Display="Dynamic" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                        <asp:CustomValidator ID="EmailAddressCv" ErrorMessage="" ControlToValidate="BorrowerEmailTb" runat="server" CssClass="validation-message" Display="Dynamic" OnServerValidate="EmailAddressCv_ServerValidate" />
                    </div>
                </div>

                <div style="display: flex; align-items: center; margin-top: 40px;">
                    <asp:LinkButton ID="ResetBtn" runat="server" style="margin-left:auto; margin-right: 20px;" CausesValidation="False" OnClick="ResetBtn_Click">Reset</asp:LinkButton>
                    <asp:Button ID="RecordBtn" Text="Record Book Borrow" runat="server" CssClass="btn btn-primary" OnClick="RecordBtn_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
