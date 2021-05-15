<%@ Page Title="Users" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Admin.Accounts.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .center-header {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="header">
        <div class="header-group">
            <h3>Users</h3>
            <div class="header-actions">
                <a class="btn btn-success" href="~/Admin/Users/Add" runat="server">
                    Add A New User
                </a>
                <a class="btn btn-secondary" href="~/Admin/" runat="server">
                    Back
                </a>
            </div>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="AccountsGv" runat="server" class="table w-100" AutoGenerateColumns="false" OnRowCommand="AccountsGv_RowCommand" GridLines="None">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="DateCreated" HeaderText="Date Created" DataFormatString="{0:MMM dd, yyyy}" />
                <asp:TemplateField HeaderText="User Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="center-header">
                    <ItemTemplate>
                        <div>
                            <div class='<%#(string) Eval("UserType") == "Admin" ? "user-type-pill pill-administrator" : 
                                   (string) Eval("UserType") == "Librarian" ? "user-type-pill pill-librarian" : 
                                   (string) Eval("UserType") == "Borrower" ?  "user-type-pill pill-borrower" : ""%>'>
                                <%#Eval("UserType")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="center-header" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a class="btn btn-primary" href='<%#$"~/Admin/Users/{Eval("UserId")}/Modify"%>' runat="server">
                            Modify
                        </a>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
