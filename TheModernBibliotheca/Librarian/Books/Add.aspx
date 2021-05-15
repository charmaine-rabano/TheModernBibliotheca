<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">

    


    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div style="padding-top:3%; padding-bottom:3%;">
            <a href="Default.aspx">
                <img src="/Content/bootstrap-icons/arrow-left.svg" width="40" height="40"  /></a></div>
    
    <h3>Add New Book</h3>

    <br />
    <div class="row">
        <div class="col-3" style="display: flex; flex-direction: column; align-items: center; padding-right: 15px;">
           <asp:Image ID="previewImg" runat="server" width="200px" height="200px" AlternateText="Image" src="https://admissions.ncsu.edu/wp-content/uploads/sites/19/2020/08/200.jpeg"/>
            <br />
            <asp:FileUpload ID="fileUploadImg" runat="server"  />
            <br />

            <asp:Label Text="Quantity" runat="server"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" min="1" step="1" Width="65px" AccessKey="Q"  Height="30px" TabIndex="1" style="font-size:larger;" ToolTip="No. of instances of this book.">1</asp:TextBox>
         </div>
        <div class="col-9">
           
            <div class="col col-lg-4">
                <%-- ISBN --%>
                <div class="form-group">
                    <asp:Label Text="ISBN" runat="server" />
                    <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control"  MaxLength="13" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter the ISBN" ControlToValidate="txtISBN" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Book Title --%>
                <div class="form-group">
                    <asp:Label Text="Book Title" runat="server" />
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"  MaxLength="256" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter Book Title" ControlToValidate="txtTitle" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>
            </div>
            <div class="col col-lg-4">
                <%-- Genre --%>
                <div class="form-group">
                    <asp:Label Text="Genre" runat="server" />
                    <asp:DropDownList ID="ddlGenre" runat="server" CssClass="form-control"  MaxLength="128"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Please choose or enter Genre" ControlToValidate="ddlGenre" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                 <%-- Author --%>
                <div class="form-group">
                    <asp:Label Text="Author" runat="server" />
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"  MaxLength="256" />
                    <asp:RequiredFieldValidator ErrorMessage="Please enter Author" ControlToValidate="txtAuthor" runat="server" CssClass="validation-message" Display="Dynamic" />
                </div>

                <%-- Summary --%>
                <div class="form-group">
                    <asp:Label Text="Summary" runat="server" />
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control"  MaxLength="256"  TextMode="MultiLine" Height="50px" Width="200%" />
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



    
</asp:Content>
