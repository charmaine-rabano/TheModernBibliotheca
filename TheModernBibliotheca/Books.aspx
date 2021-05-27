<%@ Page Title="Books" Language="C#" MasterPageFile="~/Templates/Borrower.master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="TheModernBibliotheca.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; margin-bottom:12px; flex-wrap:wrap;">
        <h2>Book Details</h2>
        <div style="margin-left: auto">
            <a href="~" runat="server" id="cancelLink" class="btn btn-secondary">
                Back
            </a>
        </div>

    </div>
    <div class="row mb-5">
        <div class="col-sm-4" style="display: flex; flex-direction: column; align-items: center; padding-right: 15px;">
            <img class="img-thumbnail" src="<%= model.BookCover %>" alt="hello" />
            <br />
            <div>
                <div class="pb-2">
                    <div>
                        <span><b>Quantity: </b>
                            <asp:Label ID="lblBookQuantity" runat="server"></asp:Label></span>
                    </div>
                    <div><span><b>Availability: </b><span runat="server" id="availableTag"></span></span></div>
                </div>
                <asp:Button CssClass="btn btn-success" ID="btnCreateReservation" runat="server" Text="Create Reservation" OnClick="btnCreateReservation_Click" />
            </div>

        </div>
        <div class="col-sm-8 mt-3 mt-sm-0">
            <h3>
                <asp:Label ID="txtTitle" runat="server"><%=model.Title%></asp:Label>
            </h3>
            <div>
                <div><span><b>Author: </b><span><%=model.Author%></span></span> </div>
                <div><span><b>ISBN: </b><span><%=model.ISBN%></span></span> </div>
                <div><span><b>Genre: </b><span><%=model.Genre%></span></span> </div>
            </div>

            <div class="my-4">
                <h5>Summary</h5>
                <asp:Label ID="txtSummary" Style="font-weight: 400;" runat="server"><%=model.Summary%></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
