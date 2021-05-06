<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Offsite.Approve" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>

        </div>
        
        <div class="container" style="padding-top: 60px">
            <h3>Approve Reservations</h3>
            <div style="margin-top: 20px" class="table-responsive">
                <asp:GridView ID="ApproveGV" runat="server" AutoGenerateColumns="False" OnRowCommand="ApproveGV_RowCommand" CssClass="table table-striped table-hover table-borderless" BorderWidth="0" AllowPaging="True" EmptyDataText="No Reservation Requests to Approve">
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
    </div>
</asp:Content>