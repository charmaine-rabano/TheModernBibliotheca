<%@ Page Title="Add Book" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        .form-control {
            max-width: 100%;
            width: 65%;
        }

        .longer {
            max-width: 100%;
            width: 100%;
        }
        .responsive {
          width: 100%;
          max-width: 200px;
          height: auto;
        }
        @media screen and (max-width: 800px) {
            .form-control {
                width: 100%;
            }
            .responsive{
                max-width:120px;
            }
        }
    </style>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=previewImg.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display: flex; padding-bottom:5px; margin-top: 60px;">
             <a href="Menu.aspx" ><asp:Image ID="Image1" runat="server" ImageUrl ="/Content/bootstrap-icons/arrow-left.svg" style="width:40px; height:40px; margin-right:10px;"/></a>
            <div class="col-xs-6" >
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link" href="Default.aspx">Manage Books</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link  active" href="Add.aspx">Add New Book</a>
                    </li>
                </ul>
            </div>
        </div>
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4" style="padding-left: 0px;">
                <asp:Image ID="previewImg" runat="server" AlternateText="Image" CssClass="responsive" Style="background-color: gray;" ImageUrl="https://t4.ftcdn.net/jpg/02/07/87/79/360_F_207877921_BtG6ZKAVvtLyc5GWpBNEIlIxsffTtWkv.jpg" /><br />
                <asp:FileUpload ID="fileUploadImg" runat="server" Style="padding-top: 10px; font-size: small;" onchange="ShowImagePreview(this);" /><br />
                <asp:RequiredFieldValidator ID="rfvFile" runat="server" ControlToValidate="fileUploadImg" ErrorMessage="Please upload book cover" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <div class="form-inline">
                    <asp:Label Text="Quantity" runat="server"></asp:Label>
                    <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" min="1" step="1" Width="65px" AccessKey="Q" Height="30px" TabIndex="1" CssClass="form-control ml-2" ToolTip="No. of instances of this book.">1</asp:TextBox>
                </div>
                <br />
                <br />
            </div>
            <div class="col-sm-8">
                <%-- ISBN --%>
                <div class="form-group">
                    <asp:Label Text="ISBN" runat="server" />
                    <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" MaxLength="13" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter ISBN" ControlToValidate="txtISBN" runat="server" CssClass="validation-message" Display="Dynamic" />
                    <asp:CustomValidator ID="cvISBN" ErrorMessage="" ControlToValidate="txtISBN" runat="server" OnServerValidate="ISBNCv_ServerValidate" CssClass="validation-message" Display="Dynamic" />

                </div>

                <%-- Book Title --%>
                <div class="form-group">
                    <asp:Label Text="Book Title" runat="server" />
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control " MaxLength="256" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter Book Title" ControlToValidate="txtTitle" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Genre --%>
                <div class="form-group">
                    <asp:Label Text="Genre" runat="server" />
                    <asp:TextBox ID="txtGenre" list="genres" runat="server" CssClass="form-control " MaxLength="256" />
                    <datalist id="genres" runat="server" clientidmode="static"></datalist>
                    <asp:RequiredFieldValidator ErrorMessage="Please choose or enter Genre" ControlToValidate="txtGenre" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Author --%>
                <div class="form-group">
                    <asp:Label Text="Author" runat="server" />
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control " MaxLength="256" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter Author" ControlToValidate="txtAuthor" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Summary --%>
                <div class="form-group">
                    <asp:Label Text="Summary" runat="server" />
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control longer" MaxLength="256" TextMode="MultiLine" Height="100px" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter Summary" ControlToValidate="txtSummary" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <br />
                <br />

                <div style="display: flex; justify-content: flex-end;">
                    <asp:Button class="btn btn-success" ID="btnAddBook" runat="server" Text="SAVE" OnClick="btnAddBook_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalEdit" tabindex="-1" role="dialog" aria-labelledby="modalEd" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalEd"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Book Succesfully Added!
                </div>
            </div>
        </div>
    </div>


</asp:Content>
