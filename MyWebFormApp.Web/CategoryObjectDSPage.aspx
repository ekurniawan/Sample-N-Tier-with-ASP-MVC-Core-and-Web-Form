<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CategoryObjectDSPage.aspx.vb" Inherits="MyWebFormApp.Web.CategoryObjectDSPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Contoh Object Datasource</h1>
    </div>

    <div class="col-lg-12">
        <!-- Basic Card Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Contoh Object Datasource</h6>
            </div>
            
            <div class="card-body">
               <%-- <asp:ObjectDataSource ID="odsCategories" TypeName="MyWebFormApp.BLL.CategoryBLL"
                   SelectMethod="GetAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete" runat="server">
                    <InsertParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>--%>

                <asp:GridView ID="gvCategories" ItemType="MyWebFormApp.BLL.DTOs.CategoryDTO" 
                    SelectMethod="GetAll" UpdateMethod="Update" DataKeyNames="CategoryID,CategoryName" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="CategoryName">
                            <ItemTemplate>
                                <asp:Label ID="lblCategoryName" runat="server" Text='<%# Item.CategoryName %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# BindItem.CategoryName %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView><br />
                <asp:Label ID="lblKeterangan" runat="server" /><br />
                <asp:Button Text="Insert" ID="btnInsert" runat="server" />
            </div>
        </div>

    </div>
</asp:Content>
