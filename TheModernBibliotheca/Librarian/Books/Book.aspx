<%@ Page Title="Book" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .form-control {
            max-width: 100%;
            width: 65%;
        }
        .longer{
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
    
        <div style="display: flex; margin-bottom:10px; margin-top:60px;">
            <a href="Default.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="40" height="40"  /></a>
            <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
                <asp:LinkButton ID="instanceLinkButton" runat="server" OnClick="instanceLinkButton_Click" CssClass="btn btn-secondary" style="background-color:	#D3D3D3 ;" >Instance <img src="/Content/bootstrap-icons/arrow-right.svg" width="40" height="40"  /> </asp:LinkButton>                  
            </div>
            </div>
       <h5>Edit</h5>
    <br />
    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-4" style="padding-left:0px;">
            <asp:Image ID="previewImg" runat="server" AlternateText="Image" CssClass="responsive" style="background-color:gray" ImageUrl="https://t4.ftcdn.net/jpg/02/07/87/79/360_F_207877921_BtG6ZKAVvtLyc5GWpBNEIlIxsffTtWkv.jpg" /><br />
            <asp:FileUpload ID="fileUploadImg" runat="server" style="padding-top:10px;font-size:small;" onchange="ShowImagePreview(this);" />
            <br />
            <br />
            <br /><br />
        </div>
        <div class="col-sm-8">
            <%-- ISBN --%>
            <div class="form-group">
                <asp:Label Text="ISBN" runat="server" />
                <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control"  MaxLength="13" Enabled="false"  />

            </div>

            <%-- Book Title --%>
            <div class="form-group">
                <asp:Label Text="Book Title" runat="server" />
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control "  MaxLength="256" />
                <asp:RequiredFieldValidator ErrorMessage="Please enter Book Title" ControlToValidate="txtTitle" runat="server" CssClass="validation-message" Display="Dynamic" />
            </div>
            
            <%-- Genre --%>
            <div class="form-group">
                <asp:Label Text="Genre" runat="server" />
                <asp:TextBox ID="txtGenre" list="genres" runat="server" CssClass="form-control "  MaxLength="256" />
                <datalist id="genres" runat="server" clientidmode="static"></datalist>
                <asp:RequiredFieldValidator ErrorMessage="Please choose or enter Genre" ControlToValidate="txtGenre" runat="server" CssClass="validation-message" Display="Dynamic" />
            </div>

                <%-- Author --%>
            <div class="form-group">
                <asp:Label Text="Author" runat="server" />
                <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control "  MaxLength="256" />
                <asp:RequiredFieldValidator ErrorMessage="Please enter Author" ControlToValidate="txtAuthor" runat="server" CssClass="validation-message" Display="Dynamic" />
            </div>

            <%-- Summary --%>
             <div class="form-group">
                <asp:Label Text="Summary" runat="server" />
                <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control longer"  MaxLength="256"  TextMode="MultiLine" Height="100px" />
                <asp:RequiredFieldValidator ErrorMessage="Please enter Summary" ControlToValidate="txtSummary" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>
 
            <br />
            <br />

            <div style="display: flex; justify-content: flex-end;">
                <asp:Button class="btn btn-success" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"  />
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
                        Succesfully Updated!
                    </div>
                </div>
            </div>
        </div>
       


</asp:Content>
