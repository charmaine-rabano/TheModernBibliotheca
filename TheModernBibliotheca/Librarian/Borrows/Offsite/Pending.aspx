<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Offsite.Pending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>

        </div>

        <div class="container" style="padding-top: 60px">
            <h3>View Pending Reservations</h3>
            <div style="margin-top: 20px" class="table-responsive">
                <asp:GridView ID="PendingGV" runat="server" AutoGenerateColumns="False" OnRowCommand="PendingGV_RowCommand" CssClass="table table-striped table-hover table-borderless" BorderWidth="0" AllowPaging="True" EmptyDataText="No Pending Reservations">
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
    </div>
</asp:Content>
