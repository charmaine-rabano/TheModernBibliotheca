<%@ Page Title="User Activity" Language="C#" MasterPageFile="~/Templates/Admin.master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="TheModernBibliotheca.Admin.Activity" %>

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
            <h3>User Activity</h3>
            <div class="header-actions">
                <a class="" href="~/Admin/" runat="server">
                    <button type="button" class="btn btn-secondary">Back</button>
                </a>
            </div>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="UserActivityGv" runat="server" class="table w-100" AutoGenerateColumns="false" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="TimeStamp" HeaderText="Timestamp" DataFormatString="{0:MMM dd, yyyy}" />
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
                <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-Width="50%" ItemStyle-Width="50%" />

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
