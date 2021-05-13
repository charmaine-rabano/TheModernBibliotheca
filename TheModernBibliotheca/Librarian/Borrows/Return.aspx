<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Return.aspx.cs" Inherits="TheModernBibliotheca.Librarian.Borrows.Return" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row" style="padding-top: 60px; display: flex; align-items: center;">
            <a href="../Menu.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>
            <h4 style="margin-right: 20px">Book Return</h4>
        </div>

        <div class="row" style="padding-top: 60px">
            <h3>Record Book Return</h3>
            <div style="margin-top: 20px" class="table-responsive">
                <asp:GridView ID="ReturnGV" runat="server" AutoGenerateColumns="False" OnRowCommand="ReturnGV_RowCommand" CssClass="table table-striped table-hover" BorderWidth="0" EmptyDataText="No Books to Return" GridLines="None">
                    <EmptyDataRowStyle Font-Size="Large" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField DataField="BorrowDate" HeaderText="Borrow Date" DataFormatString="{0:MMM dd, yyyy}" />
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="BorrowerName" HeaderText="Borrower Name" />
                        <asp:BoundField DataField="DeadlineDate" HeaderText="Return Deadline Date" DataFormatString="{0:MMM dd, yyyy}" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Return" CommandName="Return" CommandArgument='<%#Eval("BorrowID")%>' CssClass="btn btn-primary btn-block" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
