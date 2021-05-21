<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Librarian.master" AutoEventWireup="true" CodeBehind="Instances.aspx.cs" Inherits="TheModernBibliotheca.Templates.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container" style="padding-top:1%;padding-bottom:3%;">
        <div class="row">
            <div class="col-xs-6" style="margin-right: 15px;">
                <asp:LinkButton ID="backButton" runat="server" OnClick="backButton_Click"  ><img src="/Content/bootstrap-icons/arrow-left.svg" width="40" height="40"  /></asp:LinkButton>
            </div>
            <div class="col-xs-6">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <asp:LinkButton ID="instanceButton" runat="server" class="nav-link" OnClick="instanceButton_Click" >Add New Instance</asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="notInCirculation" runat="server" class="nav-link" OnClick="notInCirculation_Click">Not In Circulation</asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="inCirculationButton" runat="server" class="nav-link" OnClick="inCirculationButton_Click">In Circulation</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
    </div>



  

    
             <asp:Panel ID="instancePanel" runat="server" Visible="true">
                 <div style="padding:0px;">
        <div style="padding-left:43%;padding-top:10%;">
                <asp:Label Text="Quantity" runat="server" ></asp:Label>
            <br />
            <div style="padding-top:2%;padding-bottom:2%;" >
                <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" min="1" step="1" Width="65px" AccessKey="Q"  Height="30px" TabIndex="1" style="font-size:larger;" ToolTip="No. of instances of this book.">1</asp:TextBox>

            </div>
               <br />
            <asp:Button class="btn btn-success" ID="btnAdd" runat="server" Text="SAVE" OnClick="btnAdd_Click"   />
                    </div>
       
                </div>
            </asp:Panel>

            

    
        <asp:Panel ID="notInCirculationPanel" runat="server"  Visible="false">
            <div  class="table-responsive" style="width:70%;padding-left:20%;"> 
            <asp:GridView ID="gvNotInCirculation" class="table w-100"  AutoGenerateColumns="false" runat="server" EmptyDataText="No Data To Show" GridLines="None" OnRowCommand="gvNotInCirculation_RowCommand"  >
                 <Columns>
                <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="ADD BACK TO CIRCULATION" CommandName="ADD" CommandArgument='<%#Eval("InstanceID")%>' CssClass="btn btn-success" />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="InstanceID" HeaderText="Instance ID" />
                
            </Columns>
             </asp:GridView>
                    </div>
         </asp:Panel>


        <asp:Panel ID="inCirculationPanel" runat="server"  Visible="false">
                  <div  class="table-responsive" style="width:70%;padding-left:20%;">

             <asp:GridView ID="gvInCirculation" class="table w-100"  AutoGenerateColumns="false" runat="server" EmptyDataText="No Data To Show" GridLines="None" OnRowCommand="gvInCirculation_RowCommand"  >
                 <Columns>
                <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="REMOVE FROM CIRCULATION" CommandName="REMOVE" CommandArgument='<%#Eval("InstanceID")%>' CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="InstanceID" HeaderText="Instance ID" />
                
            </Columns>
             </asp:GridView>
                          </div>
         </asp:Panel>

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
                        Book Instance Succesfully Added!
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>
