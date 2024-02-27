<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CategoriesPage.aspx.vb" Inherits="MyWebFormApp.Web.CategoriesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">List Of Categories</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">List Of Categories</h6>
                </div>
                <div class="card-body">

                    <div class="row">
                        <div class="col-lg-6">
                            <asp:GridView ID="gvCategories"
                                CssClass="table table-hover" DataKeyNames="CategoryID" AutoGenerateColumns="false"
                                OnRowCommand="gvCategories_RowCommand"
                                runat="server">
                                <Columns>
                                    <asp:BoundField DataField="CategoryID" HeaderText="ID" />
                                    <asp:BoundField DataField="CategoryName" HeaderText="Name" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                            <hr />
                            <asp:Label ID="lblCategory" runat="server" />
                        </div>

                        <div class="col-lg-6">
                            <div class="mb-3 mt-3">
                                <label for="txtCategoryID" class="form-label">Category ID :</label>
                                <asp:TextBox ID="txtCategoryID" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtCategoryName" class="form-label">Category Name :</label>
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" />
                            </div>
                            <asp:Button Text="Edit" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>




                </div>
            </div>
        </div>

    </div>
</asp:Content>
