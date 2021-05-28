<%@ Page Title="Books" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
         .book-link {
            color:#222;
        }

        .book-link:hover {
            text-decoration:none;
            color:#222;
        }

        .book-cover-container:hover {
            filter:brightness(80%);
        }

        .book-cover-container {
            background:#DDD;
            height: 300px;
            overflow:hidden;
        }

        .book-cover {
            height: auto;
            width: 100%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

         <div style="display: flex; padding-bottom:10px;">
             <a href="Menu.aspx" ><asp:Image ID="Image1" runat="server" ImageUrl ="/Content/bootstrap-icons/arrow-left.svg" style="width:40px; height:40px; margin-right:10px;"/></a>
            <div class="col-xs-6" >
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link active" href="Default.aspx">Manage Books</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="Add.aspx">Add New Book</a>
                    </li>
                </ul>
            </div>
        </div>
    <hr />
    <h5>Filter</h5>
    <div style="display: flex; flex-wrap: wrap;">
        <div> Genre
            <asp:DropDownList ID="bookGenreDropDown" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="bookGenreDropDown_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="mx-1">
            Search Title
            <div style="display: flex">
                <asp:TextBox class="form-control mr-1" ID="txtSearch" placeholder="Title" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" class="btn btn-secondary" Text="Search" runat="server" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
    <hr />
    <br />
   <asp:Label ID="lblSearchResult" runat="server" Visible="false" style="font-size:medium; text-align:center; padding-top:2em;"></asp:Label>

 
        <div class="container" style="background-color:white;">
            <div class="jumbotron" style="background-color:white;">
                <div class="g-3">
                    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                    <asp:Repeater ID="bookRepeater" runat="server" >
                <ItemTemplate>
                     <div class="col-sm-6 col-md-4 col-lg-3 p-3 pt-0">
                    <a href='Book?ISBN=<%# Eval("ISBN")%>' class="book-link">
                        <div class="card h-100 book-item" style="text-align: left">
                            <div class="book-cover-container">
                                <img class="card-img-top book-cover" src='<%# Eval("BookCover")%>' alt="<Picture Object>" />
                            </div>

                            <div class="card-body" style="display: flex; flex-direction: column;">
                                <div><span style="font-weight:700; font-size:1.2rem"><%# FormatString(Eval("Title").ToString(), 13) %></span></div>

                                <div><span style="font-weight:500"><%# FormatString(Eval("Summary").ToString(), 17) %></span></div>
     
                            </div>
                        </div>
                    </a>
                </div>                   
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


