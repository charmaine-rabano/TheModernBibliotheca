<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.Master" AutoEventWireup="true" CodeBehind="BorrowersWithPenalty.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm3" %>
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
                        <a class="nav-link" href="InCirculation.aspx">In Circulation</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="Overall.aspx">Overall</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link active" href="BorrowersWithPenalty.aspx" >Borrowers with Penalty</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="table-responsive" style="margin-bottom:20px;margin-top:50px;">
        <asp:GridView ID="gridviewBorrowersWithPenalty" runat="server" class="table w-100" AutoGenerateColumns="false" EmptyDataText="No Borrowers with Penalty" GridLines="None">
            <Columns>
                <asp:BoundField DataField="BorrowerName" HeaderText="Borrower Name" />
                <asp:BoundField DataField="Violation" HeaderText="Violation" />
                <asp:BoundField DataField="ViolationDate" HeaderText="Violation Date" DataFormatString="{0:MMM dd, yyyy}" />
                <asp:BoundField DataField="BookTitle" HeaderText="Book Title" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
