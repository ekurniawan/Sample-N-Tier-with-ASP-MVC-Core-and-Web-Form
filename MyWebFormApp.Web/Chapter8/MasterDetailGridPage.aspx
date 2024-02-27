<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MasterDetailGridPage.aspx.vb" Inherits="MyWebFormApp.Web.MasterDetailGridPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Master Detail</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Mater Detail Page</h6>
                </div>
                <div class="card-body">
                    <asp:SqlDataSource ID="sdsCategories" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                        SelectCommand="usp_GetCategories" SelectCommandType="StoredProcedure" 
                        DeleteCommand="DELETE FROM [Categories] WHERE [CategoryID] = @CategoryID" 
                        InsertCommand="INSERT INTO [Categories] ([CategoryName]) VALUES (@CategoryName)" 
                        UpdateCommand="UPDATE [Categories] SET [CategoryName] = @CategoryName WHERE [CategoryID] = @CategoryID">
                        <DeleteParameters>
                            <asp:Parameter Name="CategoryID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CategoryName" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CategoryName" Type="String" />
                            <asp:Parameter Name="CategoryID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>" 
                        SelectCommand="SELECT Categories.CategoryID, Categories.CategoryName, Articles.Title, Articles.Details, Articles.PublishDate,Articles.ArticleID, Articles.IsApproved, Articles.Pic FROM Categories INNER JOIN Articles ON Categories.CategoryID = Articles.CategoryID where Articles.CategoryID=@CategoryID" 
                        DeleteCommand="DELETE FROM [Articles] WHERE [ArticleID] = @ArticleID" 
                        InsertCommand="INSERT INTO [Articles] ([CategoryID], [Title], [Details], [PublishDate], [IsApproved], [Pic]) VALUES (@CategoryID, @Title, @Details, @PublishDate, @IsApproved, @Pic)" 
                        UpdateCommand="UPDATE [Articles] SET [CategoryID] = @CategoryID, [Title] = @Title, [Details] = @Details, [PublishDate] = @PublishDate, [IsApproved] = @IsApproved, [Pic] = @Pic WHERE [ArticleID] = @ArticleID">
                        <DeleteParameters>
                            <asp:Parameter Name="ArticleID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CategoryID" Type="Int32" />
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="Details" Type="String" />
                            <asp:Parameter DbType="Date" Name="PublishDate" />
                            <asp:Parameter Name="IsApproved" Type="Boolean" />
                            <asp:Parameter Name="Pic" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="gvCategories" Name="CategoryID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CategoryID" Type="Int32" />
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="Details" Type="String" />
                            <asp:Parameter DbType="Date" Name="PublishDate" />
                            <asp:Parameter Name="IsApproved" Type="Boolean" />
                            <asp:Parameter Name="Pic" Type="String" />
                            <asp:Parameter Name="ArticleID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>


                    <asp:FormView runat="server" DefaultMode="Insert" DataKeyNames="CategoryID" DataSourceID="sdsCategories">
                        <InsertItemTemplate>
                            CategoryName:
                            <asp:TextBox ID="CategoryNameTextBox" runat="server" Text='<%# Bind("CategoryName") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                    </asp:FormView>
                    <hr />

                    <asp:GridView ID="gvCategories" CssClass="table" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="CategoryID" DataSourceID="sdsCategories" OnRowCommand="gvCategories_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                            <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>

                    <br />
                    <asp:GridView ID="gvArticles" CssClass="table" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="ArticleID" DataSourceID="sdsArticles">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:ImageField DataImageUrlField="Pic" DataImageUrlFormatString="~/Pics/{0}">
                                <ControlStyle Width="200px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
                            <asp:TemplateField HeaderText="CategoryName" SortExpression="CategoryName">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddCategories" runat="server" DataSourceID="sdsCategories" 
                                        DataTextField="CategoryName" DataValueField="CategoryID" 
                                        SelectedValue='<%# Bind("CategoryID") %>'></asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                            <asp:BoundField DataField="PublishDate" HeaderText="PublishDate" SortExpression="PublishDate" DataFormatString="{0:d}" />
                            <asp:CheckBoxField DataField="IsApproved" HeaderText="Approved" SortExpression="IsApproved" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="alert alert-warning" role="alert">
                                No data found.
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <hr />
                    <asp:Label ID="lblKeterangan" EnableViewState="false" runat="server" />

                </div>
            </div>

        </div>

    </div>
</asp:Content>
