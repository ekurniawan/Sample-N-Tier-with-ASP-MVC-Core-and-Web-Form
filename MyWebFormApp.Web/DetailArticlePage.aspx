<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailArticlePage.aspx.vb" Inherits="MyWebFormApp.Web.DetailArticlePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Detail Article</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Detail Article</h6>
                </div>
                <div class="card-body">
                    <table class="table table-hover">
                        <asp:ListView ID="lvArticles" DataKeyNames="ArticleID"
                            runat="server">
                            <LayoutTemplate>
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Category</th>
                                        <th>Title</th>
                                        <th>Approval</th>
                                        <th>&nbsp;</th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server"></tr>
                                </tbody>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("ArticleID") %></td>
                                    <td><%# Eval("Category.CategoryName") %></td>
                                    <td><%# Eval("Title") %></td>
                                    <td><%# Eval("IsApproved") %></td>
                                    <td>
                                        <asp:Image ImageUrl='<%# Eval("Pic", "~/Pics/{0}") %>' Width="100" runat="server" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" CssClass="btn btn-outline-warning btn-sm"
                                            CommandName="Select" CommandArgument="Edit" runat="server" />
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" CssClass="btn btn-outline-danger btn-sm"
                                            CommandName="Select" CommandArgument="Delete"
                                            OnClientClick="return confirm('Apakah anda yakin untuk delete data ?')" runat="server" />
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
