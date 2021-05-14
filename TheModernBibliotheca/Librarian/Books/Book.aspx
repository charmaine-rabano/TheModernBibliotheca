<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     
        
        <div style="display: flex; margin-bottom:30px; margin-top:10px;">
            <a href="Default.aspx"><img src="/Content/bootstrap-icons/arrow-left.svg" width="40" height="40"  /></a>
            <div style="display: flex; margin-left: auto; justify-content: right; align-items: center;">
                
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-secondary" style="background-color:lightgray" >Instance <img src="/Content/bootstrap-icons/arrow-right.svg" width="40" height="40"  /> </asp:LinkButton>                  


                

  
            </div>
            </div>
       
       


</asp:Content>
