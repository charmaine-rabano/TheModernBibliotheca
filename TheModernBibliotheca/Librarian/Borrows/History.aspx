<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        div {
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row" style="padding-top: 60px; display: flex; align-items: center;">
            <a href="Menu.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>
        </div>

        <div class="row" style="padding-top: 60px">
            <h3>View Borrow History</h3>

            <div class="form-group row" style="margin-top: 40px;">
                <asp:Label CssClass="col-sm-2 col-12" Text="Borrower's Email" runat="server" />
                <div class="col-sm-4 col-12">
                    <asp:TextBox runat="server" ID="BorrowerEmailTb" CssClass="form-control" TextMode="Email"  MaxLength="127"/>
                    <asp:RequiredFieldValidator ErrorMessage="This is a required field" ControlToValidate="BorrowerEmailTb" runat="server" CssClass="validation-message" Display="Dynamic" />
                    <asp:RegularExpressionValidator ErrorMessage="Please enter a valid email address" ControlToValidate="BorrowerEmailTb" runat="server" CssClass="validation-message" Display="Dynamic" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                    <asp:CustomValidator ID="EmailAddressCv" ErrorMessage="" ControlToValidate="BorrowerEmailTb" runat="server" CssClass="validation-message" Display="Dynamic" OnServerValidate="EmailAddressCv_ServerValidate" />
                </div>
                <div class="col-sm-2 col-12">
                    <asp:Button ID="ViewBtn" runat="server" Text="View Borrow History" CssClass="btn btn-primary" OnClick="ViewBtn_Click" />
                </div>
                
            </div>

            <div ID="DisplayDiv" runat="server" display="dynamic" style="margin-top: 40px;">
                <p>Borrower's Name: <asp:Label ID="BorrowerNameLbl" runat="server" Text=""></asp:Label></p>
                <div style="margin-top: 20px" class="table-responsive">
                    <asp:GridView ID="HistoryGV" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" BorderWidth="0" EmptyDataText="Borrower has no borrow history yet." GridLines="None">
                        <EmptyDataRowStyle Font-Size="Large" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                            <asp:BoundField DataField="SiteType" HeaderText="Site Type" />
                            <asp:BoundField DataField="DateReserved" HeaderText="Date Reserved" DataFormatString="{0:MMM dd, yyyy}" />
                            <asp:BoundField DataField="DateBorrowed" HeaderText="Date Borrowed" DataFormatString="{0:MMM dd, yyyy}" />
                            <asp:BoundField DataField="DateReturned" HeaderText="Date Returned" DataFormatString="{0:MMM dd, yyyy}" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Violation" HeaderText="Violation" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
