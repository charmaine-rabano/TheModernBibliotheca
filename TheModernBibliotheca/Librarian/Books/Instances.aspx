<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Instances.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-6" style="margin-right: 15px;">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  ><img src="/Content/bootstrap-icons/arrow-left.svg" width="40" height="40"  /></asp:LinkButton>


            </div>
            <div class="col-xs-6">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton2" runat="server" class="nav-link" OnClick="LinkButton2_Click" >Add New Instance</asp:LinkButton>
                        
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton3" runat="server" class="nav-link" OnClick="LinkButton3_Click">Not In Circulation</asp:LinkButton>
                        
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton4" runat="server" class="nav-link" OnClick="LinkButton4_Click">In Circulation</asp:LinkButton>
                        
                    </li>
                </ul>
            </div>
        </div>
        
            <asp:Panel ID="Panel1" runat="server" Visible="true"><asp:Label Text="Quantity" runat="server"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" min="1" step="1" Width="65px" AccessKey="Q"  Height="30px" TabIndex="1" style="font-size:larger;" ToolTip="No. of instances of this book.">1</asp:TextBox>
           <asp:Button class="btn btn-success" ID="btnAdd" runat="server" Text="SAVE" OnClick="btnAdd_Click"   />

            </asp:Panel>
         <asp:Panel ID="Panel2" runat="server"  Visible="false">
             <asp:GridView ID="gvNotInCirculation" runat="server" EmptyDataText="No Data To Show"></asp:GridView>
         </asp:Panel>
         <asp:Panel ID="Panel3" runat="server"  Visible="false">
                          <asp:GridView ID="gvInCirculation" runat="server" EmptyDataText="No Data To Show" OnRowCommand="gvInCirculation_RowCommand"  >
                              <Columns>
                                  <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="REMOVE FROM BOOKSHELF" CommandName="REMOVE" CommandArgument='<%#Eval("InstanceID")%>' CssClass="btn btn-block btn-outline-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                              </Columns>
                               
                          </asp:GridView>

         </asp:Panel>
        
    </>
</asp:Content>
