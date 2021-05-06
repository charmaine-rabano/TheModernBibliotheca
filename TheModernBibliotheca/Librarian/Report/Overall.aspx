<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.Master" AutoEventWireup="true" CodeBehind="Overall.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-6" style="margin-right: 15px;">
                <h4>Create Report   </h4>
            </div>
            <div class="col-xs-6">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link" href="OnShelf.aspx">ON-SHELF</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link active" href="Overall.aspx">OVERALL</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="BorrowersWithPenalty.aspx" >BORROWERS WITH PENALTY</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <asp:DropDownList ID="ddlOverall" runat="server" OnSelectedIndexChanged="ddlOverall_SelectedIndexChanged"></asp:DropDownList>
</asp:Content>