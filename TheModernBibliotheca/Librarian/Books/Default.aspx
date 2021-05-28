<%@ Page Title="Books" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .card {
            background-color: #fff;
            border-radius: 0.5rem;
            box-shadow: 0.05rem 0.1rem 0.3rem -0.03rem rgba(0, 0, 0, 0.45);
            padding-bottom: 1rem;
        }

        .card > :last-child {
            margin-bottom: 0;
        }

        .card h3 {
            margin-top: 1rem;
            font-size: 1.25rem;
        }

        img {
            object-fit: cover;
            height: max(10rem, 30vh);
        }

        img ~ * {
            margin-left: 1rem;
            margin-right: 1rem;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

         <div style="display: flex; padding-bottom:5px;">
             <a href="Menu.aspx" ><asp:Image ID="Image1" runat="server" ImageUrl ="/Content/bootstrap-icons/arrow-left.svg" style="width:40px; height:40px; margin-right:10px;"/></a>
            <h4>Manage Books</h4>
            <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
                <a href="Add.aspx"  class="btn btn-primary btn-block">Add New Book </a>
            </div>
        </div>

        <div style="display: flex">
            <asp:DropDownList ID="bookGenreDropDown" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="bookGenreDropDown_SelectedIndexChanged"></asp:DropDownList>
            <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
                <asp:TextBox class="form-control" ID="txtSearch" placeholder="Search" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnSearch" class="btn btn-secondary" Text="Search" runat="server" OnClick="btnSearch_Click"/>
            </div>
        </div>
    <br />
   <asp:Label ID="lblSearchResult" runat="server" Visible="false" style="font-size:medium; text-align:center; padding-top:2em;"></asp:Label>

 
        <div class="container">
            <div class="jumbotron" style="background-color: #F2E2CE;">
                <div class="g-3">
                    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                    <asp:Repeater ID="bookRepeater" runat="server" >
                <ItemTemplate>
                    <ul class="card-wrapper">
                      <li class="card">
                        <img src='<%# Eval("BookCover")%>'  alt="">
                          <br />
                        <h3><%# Eval("Title")%></h3>
                        <p style="height:20%; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical;" ><%# Eval("Summary")%></p>
                          <br />
                          <div style="width:30%;">
                          <a href='Book?ISBN=<%# Eval("ISBN")%>' class="btn btn-primary" >Details</a>
                          </div>
                      </li>
                    </ul>

                   
                    </ItemTemplate>
                </asp:Repeater>

             </div>
            </div>
            </div>
        </div>


    <div id="noResultsMessage" style="font-size:xx-large; text-align:center; padding-top:2em;" runat="server" visible="false">
            No Results Found.
    </div>

</asp:Content>


