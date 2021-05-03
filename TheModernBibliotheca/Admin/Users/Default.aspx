<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Admin.Accounts.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        :root {
            --librarian-primary: #183BF0;
            --librarian-secondary: #DDE3FD;
            --administrator-primary: #FE2712;
            --administrator-secondary: #FFDEDB;
            --borrower-primary: #66B032;
            --borrower-secondary: #EBF7E3;
        }

        .center-header {
            text-align: center;
        }

        .user-type-pill {
            border-radius: 8px;
            font-size: .8rem;
            border: 1px solid black;
            width: 7rem;
            text-align: center;
            padding: 2px 0;
        }

        .pill-administrator {
            border-color: var(--administrator-primary);
            background-color: var(--administrator-secondary);
            color: var(--administrator-primary);
        }

        .pill-librarian {
            border-color: var(--librarian-primary);
            background-color: var(--librarian-secondary);
            color: var(--librarian-primary);
        }

        .pill-borrower {
            border-color: var(--borrower-primary);
            background-color: var(--borrower-secondary);
            color: var(--borrower-primary);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header">
        <div class="header-group">
            <h3>Accounts</h3>
            <div class="header-actions">
                <a class="" href="~/Admin/Users/Add" runat="server">
                    <button type="button" class="btn btn-success">Add A New User</button>
                </a>
                <a class="" href="~/Admin/" runat="server">
                    <button type="button" class="btn btn-secondary">Back to Home</button>
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
                            <div class='<%#(string) Eval("UserType") == "Administrator" ? "user-type-pill pill-administrator" : 
                                   (string) Eval("UserType") == "Librarian" ? "user-type-pill pill-librarian" : 
                                   (string) Eval("UserType") == "Borrower" ?  "user-type-pill pill-borrower" : ""%>'>
                                <%#Eval("UserType")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="center-header" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a class="" href='<%#$"~/Admin/Users/{Eval("UserId")}/Modify"%>' runat="server">
                            <button type="button" class="btn btn-primary">Modify</button>
                        </a>
 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
