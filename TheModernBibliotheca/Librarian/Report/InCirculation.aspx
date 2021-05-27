<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.Master" AutoEventWireup="true" CodeBehind="InCirculation.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <a href="../Books/Menu.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="25" height="25" style="margin-right: 10px" /></a>

            <div class="col-xs-6" style="margin-right: 15px;">
                <h4>Create Report   </h4>
            </div>
            <div class="col-xs-6">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link active" href="InCirculation.aspx">In Circulation</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="Overall.aspx">Overall</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="BorrowersWithPenalty.aspx" >Borrowers with Penalty</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div style="margin-top:20px;margin-bottom:20px;">
            <asp:DropDownList ID="onShelfDropDown" runat="server" OnSelectedIndexChanged="onShelfDropDown_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="table-responsive" style="margin-bottom:20px;margin-top:20px;">
        <asp:GridView ID="gridviewOnshelf" runat="server" class="table w-100" AutoGenerateColumns="false" EmptyDataText="No Books are in Circulation" GridLines="None">
            <Columns>
                <asp:BoundField DataField="InstanceID" HeaderText="Instance ID" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:BoundField DataField="Title" HeaderText="Book Title" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
