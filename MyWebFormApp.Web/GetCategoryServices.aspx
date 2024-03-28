<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" Async="true" CodeBehind="GetCategoryServices.aspx.vb" Inherits="MyWebFormApp.Web.GetCategoryServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Get Categories</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="row">
                <div class="col-lg-6">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Get Catgories</h6>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="gvCategories" runat="server"></asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Insert Catgories</h6>
                        </div>
                        <div class="card-body">
                            <asp:Literal ID="ltMessage" runat="server" />
                            <div class="form-group">
                                <label for="txtArticleIDEdit">Category Name :</label>
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"
                                    placeholder="Enter Category Name" />

                                <asp:Button Text="Add" ID="btnAdd" CssClass="btn btn-primary btn-sm"
                                    OnClick="btnAdd_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
