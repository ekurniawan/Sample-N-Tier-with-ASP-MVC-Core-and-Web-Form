<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" 
    CodeBehind="FormParamPage.aspx.vb" Inherits="MyWebFormApp.Web.FormParamPage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row">
      <div class="d-sm-flex align-items-center justify-content-between mb-4">
          <h1 class="h3 mb-0 text-gray-800">Param Page</h1>
      </div>

      <div class="col-lg-12">
          <!-- Basic Card Example -->
          <div class="card shadow mb-4">
              <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Param Page</h6>
              </div>
              <div class="card-body">
                  <asp:SqlDataSource runat="server" ID="sdsCategories" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                      InsertCommand="usp_CreateCategory" InsertCommandType="StoredProcedure" 
                      SelectCommand="usp_GetCategories" SelectCommandType="StoredProcedure" >
                      <InsertParameters>
                          <asp:FormParameter FormField="CategoryName" Name="CategoryName" Type="String" />
                      </InsertParameters>
                  </asp:SqlDataSource>

                  <asp:GridView ID="gvCategories" CssClass="table" runat="server" 
                      AutoGenerateColumns="False" DataKeyNames="CategoryID" 
                      DataSourceID="sdsCategories" AllowPaging="True" AllowSorting="True">
                      <Columns>
                          <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                          <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
                      </Columns>
                  </asp:GridView>
                  <hr />
                  <asp:Label ID="lblKeterangan" runat="server" />
              </div>
          </div>
      </div>

  </div>
</asp:Content>
