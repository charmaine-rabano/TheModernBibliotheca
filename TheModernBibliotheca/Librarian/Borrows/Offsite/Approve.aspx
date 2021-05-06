<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Offsite.Approve" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>

        </div>
        
        <div>
            <h3>Approve Reservations</h3>
            <div>
                <asp:GridView ID="ApproveGV" runat="server" AutoGenerateColumns="False" OnRowCommand="ApproveGV_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ReservationDate" HeaderText="Reservation Date" DataFormatString="{0:MMM dd, yyyy}" />
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="BorrowerName" HeaderText="Borrower Name" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%#Eval("BorrowID")%>' />
                                <asp:LinkButton runat="server" Text="Disapprove" CommandName="Disapprove" CommandArgument='<%#Eval("BorrowID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>