<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CategoryWithListViewPage.aspx.vb" Inherits="MyWebFormApp.Web.CategoryWithListViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Category ListView</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Category ListView</h6>
                </div>
                <div class="card-body">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Category ID</th>
                                <th>Category Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvCategories" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("CategoryID") %></td>
                                        <td><%# Eval("CategoryName") %></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <div style="border: solid 1px black;">
                                        No data available.
                                    </div>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
