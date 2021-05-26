<%@ Page Title="Approve Offsite" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Offsite.Approve" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="padding-top: 60px; display: flex; align-items: center;">
        <a href="../Menu.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>
        <h4 style="margin-right: 20px">Offsite Borrowing</h4>
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="Approve.aspx">Approve Reservations</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Pending.aspx" >View Pending Reservations</a>
            </li>
        </ul>
    </div>
        
    <div class="row" style="padding-top: 60px">
        <h3>Approve Reservations</h3>
        <div style="margin-top: 20px" class="table-responsive">
            <asp:GridView ID="ApproveGV" runat="server" AutoGenerateColumns="False" OnRowCommand="ApproveGV_RowCommand" CssClass="table table-striped table-hover" BorderWidth="0" EmptyDataText="No Reservation Requests to Approve" GridLines="None">
                <EmptyDataRowStyle Font-Size="Large" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="ReservationDate" HeaderText="Reservation Date" DataFormatString="{0:MMM dd, yyyy}" />
                    <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                    <asp:BoundField DataField="BorrowerName" HeaderText="Borrower Name" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%#Eval("BorrowID")%>' CssClass="btn btn-primary btn-block" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Disapprove" CommandName="Disapprove" CommandArgument='<%#Eval("BorrowID")%>' CssClass="btn btn-block btn-outline-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>