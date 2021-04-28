<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Admin.Accounts.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Accounts</h4>
    <asp:GridView ID="AccountsGv" runat="server" CssClass="ArtistPaymentsTable table" AutoGenerateColumns="false" OnRowCommand="AccountsGv_RowCommand">
        <Columns>
            <asp:BoundField DataField="FullName" HeaderText="Name" />
            <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" DataFormatString="{0:MMM dd yyyy}" />
            <asp:BoundField DataField="UserType" HeaderText="Account Type" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button Text='Modify' runat="server" CommandName="Modify" CommandArgument='<%#Eval("UserId")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
