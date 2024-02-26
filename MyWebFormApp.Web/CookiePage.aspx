<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CookiePage.aspx.vb" Inherits="MyWebFormApp.Web.CookiePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
         <h1 class="h3 mb-0 text-gray-800">Cookie Sample</h1>
     </div>

     <div class="col-lg-12">
         <!-- Basic Card Example -->
         <div class="card shadow mb-4">
             <div class="card-header py-3">
                 <h6 class="m-0 font-weight-bold text-primary">About Page</h6>
             </div>
             <div class="card-body">
                 <asp:SqlDataSource ID="sdsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                     SelectCommand="usp_GetArticlesByCategoryId" SelectCommandType="StoredProcedure" >
                     <SelectParameters>
                         <asp:CookieParameter CookieName="CategoryID" Name="CategoryID" Type="Int32" />
                     </SelectParameters>
                 </asp:SqlDataSource>
                 <asp:TextBox ID="txtCategoryID" runat="server" /><br />
                 <asp:Button ID="btnSetCookie" Text="Set Cookie" runat="server" OnClick="btnSetCookie_Click" />
                 <asp:Button ID="btnGetCookie" Text="Get Cookie" runat="server" OnClick="btnGetCookie_Click" />
                 <hr />
                 <asp:Label ID="lblCookie" runat="server" Text=""></asp:Label><br />

                 <asp:GridView ID="gvArticles" runat="server" AutoGenerateColumns="False" 
                     DataKeyNames="ArticleID" CssClass="table" DataSourceID="sdsArticles">
                     <Columns>
                         <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
                         <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                         <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                         <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" />
                     </Columns>
                 </asp:GridView>
             </div>
         </div>

     </div>

 </div>
</asp:Content>
