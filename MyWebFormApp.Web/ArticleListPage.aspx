<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArticleListPage.aspx.vb" Inherits="MyWebFormApp.Web.ArticleListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Articles</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Article Page</h6>
                </div>
                <div class="card-body">
                    <asp:Literal ID="ltMessage" runat="server" /><br />
                    <div class="row">
                        <asp:ListView ID="lvCategories" ItemType="MyWebFormApp.BLL.DTOs.CategoryDTO"
                            SelectMethod="lvCategories_GetData" DataKeyNames="CategoryID" OnItemCommand="lvCategories_ItemCommand" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-2 mb-2">
                                    <asp:LinkButton ID="lnkSelect" Text='<%# Eval("CategoryName") %>' CommandName="Select"
                                        CommandArgument='<%# Eval("CategoryID") %>'
                                        runat="server" CssClass="btn btn-outline-info btn-sm" />
                                </div>
                            </ItemTemplate>
                            <SelectedItemTemplate>
                                <div class="col-lg-2 mb-2">
                                    <asp:LinkButton ID="lnkSelect" Text='<%# Eval("CategoryName") %>' CommandName="Select"
                                        runat="server" CssClass="btn btn-info btn-sm" />
                                </div>
                            </SelectedItemTemplate>
                        </asp:ListView>
                    </div>
                    <br />
                    <table class="table table-hover">
                        <asp:ListView ID="lvArticles" ItemType="MyWebFormApp.BLL.DTOs.ArticleDTO"
                            SelectMethod="lvArticles_GetData" runat="server">
                            <LayoutTemplate>
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Category</th>
                                        <th>Title</th>
                                        <th>Details</th>
                                        <th>Created</th>
                                        <th>Approval</th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CategoryID") %></td>
                                    <td><%# Eval("Category.CategoryName") %></td>
                                    <td><%# Eval("Title") %></td>
                                    <td><%# Eval("Details") %></td>
                                    <td><%# Eval("PublishDate", "{0:d}") %></td>
                                    <td><%# Eval("IsApproved") %></td>
                                    <td>
                                        <asp:Image ImageUrl='<%# Eval("Pic", "~/Pics/{0}") %>' Width="100" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyItemTemplate>
                                <tr>
                                    <td colspan="7">No records found</td>
                                </tr>
                            </EmptyItemTemplate>
                        </asp:ListView>

                    </table>

                </div>
            </div>

        </div>

    </div>
</asp:Content>
