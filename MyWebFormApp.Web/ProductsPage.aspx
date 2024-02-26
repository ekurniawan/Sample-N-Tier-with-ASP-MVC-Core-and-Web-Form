<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"  CodeBehind="ProductsPage.aspx.vb" Inherits="MyWebFormApp.Web.ProductsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
         <h1 class="h3 mb-0 text-gray-800">Products</h1>
     </div>

     <div class="col-lg-12">
         <!-- Basic Card Example -->
         <div class="card shadow mb-4">
             <div class="card-header py-3">
                 <h6 class="m-0 font-weight-bold text-primary">About Page</h6>
             </div>
             <div class="card-body">
                 <asp:SqlDataSource ID="sdsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                     OnSelected="sdsArticles_Selected" OnUpdating="sdsArticles_Updating"
                     SelectCommand="SELECT [ArticleID], [CategoryID], [Title], [Details], [PublishDate] FROM [Articles]" 
                     DeleteCommand="DELETE FROM [Articles] WHERE [ArticleID] = @ArticleID" 
                     InsertCommand="INSERT INTO [Articles] ([CategoryID], [Title], [Details], [PublishDate]) VALUES (@CategoryID, @Title, @Details, @PublishDate)" 
                     UpdateCommand="UPDATE [Articles] SET [CategoryID] = @CategoryID, [Title] = @Title, [Details] = @Details, [PublishDate] = @PublishDate WHERE [ArticleID] = @ArticleID" >
                     <DeleteParameters>
                         <asp:Parameter Name="ArticleID" Type="Int32" />
                     </DeleteParameters>
                     <InsertParameters>
                         <asp:Parameter Name="CategoryID" Type="Int32" />
                         <asp:Parameter Name="Title" Type="String" />
                         <asp:Parameter Name="Details" Type="String" />
                         <asp:Parameter DbType="Date" Name="PublishDate" />
                     </InsertParameters>
                     <UpdateParameters>
                         <asp:Parameter Name="CategoryID" Type="Int32" />
                         <asp:Parameter Name="Title" Type="String" />
                         <asp:Parameter Name="Details" Type="String" />
                         <asp:Parameter DbType="Date" Name="PublishDate" />
                         <asp:Parameter Name="ArticleID" Type="Int32" />
                     </UpdateParameters>
                 </asp:SqlDataSource>

                 <asp:GridView ID="gvArticles" AutoGenerateColumns="False" CssClass="table" 
                     runat="server" DataSourceID="sdsArticles" DataKeyNames="ArticleID">
                     <Columns>
                         <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
                         <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                         <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                         <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                         <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" />
                         <asp:CommandField ShowEditButton="True" />
                     </Columns>
                 </asp:GridView>
                 <br />
                 <asp:Label ID="lblError" CssClass="alert-danger" runat="server" />
             </div>
         </div>
     </div>

 </div>
</asp:Content>
