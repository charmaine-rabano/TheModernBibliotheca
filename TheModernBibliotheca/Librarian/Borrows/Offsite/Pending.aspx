<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Offsite.Pending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="padding-top: 60px; display: flex; align-items: center;">
        <a href="../Menu.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>
        <h4 style="margin-right: 20px">Offsite Borrowing</h4>
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link" href="Approve.aspx">Approve Reservations</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="Pending.aspx" >View Pending Reservations</a>
            </li>
        </ul>
    </div>

    <div class="row" style="padding-top: 60px">
        <h3>View Pending Reservations</h3>
        <div style="margin-top: 20px" class="table-responsive">
            <asp:GridView ID="PendingGV" runat="server" AutoGenerateColumns="False" OnRowCommand="PendingGV_RowCommand" CssClass="table table-striped table-hover" BorderWidth="0" EmptyDataText="No Pending Reservations" GridLines="None">
                <EmptyDataRowStyle Font-Size="Large" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" DataFormatString="{0:MMM dd, yyyy}" />
                    <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                    <asp:BoundField DataField="BorrowerName" HeaderText="Borrower Name" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Claim" CommandName="Claim" CommandArgument='<%#Eval("BorrowID")%>' CssClass="btn btn-primary btn-block" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
