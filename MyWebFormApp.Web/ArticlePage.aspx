<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArticlePage.aspx.vb" Inherits="MyWebFormApp.Web.ArticlePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Article Page</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Article Page</h6>
                </div>
                <div class="card-body">
                    <asp:Label Text="Category ID:" ID="lblCategory" runat="server" /><br />
                    <asp:SqlDataSource ID="sdsCategories" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                        SelectCommand="usp_GetCategories" SelectCommandType="StoredProcedure" />
                    <asp:SqlDataSource ID="sdsArticles" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                        SelectCommand="usp_GetArticlesByCategoryId" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddCategories" Name="CategoryID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <label for="ddCategories">Category Name :</label>
                    <asp:DropDownList ID="ddCategories" runat="server" AutoPostBack="true" 
                        DataSourceID="sdsCategories" DataTextField="CategoryName" 
                        DataValueField="CategoryID">
                    </asp:DropDownList>
                    <br />
                    <asp:GridView ID="gvArticles" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="ArticleID" DataSourceID="sdsArticles">
                        <Columns>
                            <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                            <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" DataFormatString="{0:d}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
