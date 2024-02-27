<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="GetQueryParamPage.aspx.vb" Inherits="MyWebFormApp.Web.GetQueryParamPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row">
      <div class="d-sm-flex align-items-center justify-content-between mb-4">
          <h1 class="h3 mb-0 text-gray-800">Get Query Page</h1>
      </div>

      <div class="col-lg-12">
          <!-- Basic Card Example -->
          <div class="card shadow mb-4">
              <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Get Query Page</h6>
              </div>
              <div class="card-body">
                  <asp:SqlDataSource runat="server" ID="sdsArticles" 
                      ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                      SelectCommand="usp_GetArticlesWithCategoryByID" SelectCommandType="StoredProcedure" >
                      <SelectParameters>
                          <asp:QueryStringParameter Name="CategoryID" QueryStringField="id" />
                      </SelectParameters>
                  </asp:SqlDataSource>

                  <asp:GridView ID="gvArticles" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ArticleID" DataSourceID="sdsArticles">
                      <Columns>
                          <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
                          <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
                          <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                          <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                          <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" />
                      </Columns>
                  </asp:GridView>
                  <hr />
                  <asp:Label ID="lblKetrangan" runat="server" />
              </div>
          </div>

      </div>

  </div>
</asp:Content>
