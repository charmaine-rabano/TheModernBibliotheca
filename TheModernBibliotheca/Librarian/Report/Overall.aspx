﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.Master" AutoEventWireup="true" CodeBehind="Overall.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 60px;">
        <div class="row">
            <a href="../Books/Menu.aspx">
                <img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>

            <div class="col-xs-6" style="margin-right: 15px;">
                <h4>Create Report   </h4>
            </div>
            <div class="col-xs-6">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link" href="InCirculation.aspx">In Circulation</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="Overall.aspx">Overall</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="BorrowersWithPenalty.aspx">Borrowers with Penalty</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="BookInventory.aspx">Book Inventory</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div style="margin-top: 20px; margin-bottom: 20px;">
        <asp:DropDownList ID="ddlOverall" runat="server" OnSelectedIndexChanged="ddlOverall_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="table-responsive" style="margin-bottom: 20px; margin-top: 20px;">
        <asp:GridView ID="gridviewOverall" runat="server" class="table w-100" AutoGenerateColumns="false" EmptyDataText="No Recorded Books" GridLines="None">
            <Columns>
                <asp:BoundField DataField="InstanceID" HeaderText="Instance ID" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:BoundField DataField="Title" HeaderText="Book Title" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="center-header">
                    <ItemTemplate>
                        <div>
                            <div class='<%#(string) Eval("Status") == "Not In Circulation" ? "user-type-pill pill-offshelf" : 
                                   (string) Eval("Status") == "In Circulation" ?  "user-type-pill pill-onshelf" : ""%>'>
                                <%#Eval("Status")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
