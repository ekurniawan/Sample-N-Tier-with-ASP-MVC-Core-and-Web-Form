<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SessionPage.aspx.vb" Inherits="MyWebFormApp.Web.SessionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Session Page</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Session Page</h6>
                </div>
                <div class="card-body">
                    <asp:SqlDataSource ID="sdsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                        SelectCommand="usp_GetArticlesByCategoryId" SelectCommandType="StoredProcedure" >
                        <SelectParameters>
                            <asp:SessionParameter Name="CategoryID" SessionField="CategoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <label for="txtCategoryID">Category ID :</label>
                    <asp:TextBox ID="txtCategoryID" runat="server" />
                    <asp:Button Text="Create Session" ID="btnCreateSession" runat="server" OnClick="btnCreateSession_Click" /><br />
                    <asp:Button Text="Read Session" ID="btnReadSession" runat="server" OnClick="btnReadSession_Click" /><br />
                    <asp:Button Text="Remove Session" ID="btnRemoveSession" runat="server" OnClick="btnRemoveSession_Click" /><br />

                    <asp:GridView ID="gvArticles" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ArticleID" DataSourceID="sdsArticles">
                        <Columns>
                            <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                            <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" />
                        </Columns>
                    </asp:GridView>

                    <hr />
                    <asp:Label ID="lblKeterangan" runat="server" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
