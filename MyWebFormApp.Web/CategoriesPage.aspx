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

                    <asp:Literal ID="ltMessage" runat="server" /><br />
                    <br />

                    <div class="row">
                        <br />
                        <div class="col-lg-6">
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" />
                                </div>
                                <div class="col">
                                    <asp:Button ID="btnSearch" Text="Search" CssClass="btn btn-success" runat="server" />
                                </div>
                            </div><br />
                            <asp:GridView ID="gvCategories"
                                CssClass="table table-hover" DataKeyNames="CategoryID" AutoGenerateColumns="False"
                                OnRowCommand="gvCategories_RowCommand" OnRowDeleting="gvCategories_RowDeleting" 
                                runat="server">
                                <Columns>
                                    <asp:BoundField DataField="CategoryID" HeaderText="ID" />
                                    <asp:BoundField DataField="CategoryName" HeaderText="Name" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-outline-danger btn-sm" CausesValidation="False" CommandName="Delete" Text="Delete" />
                                            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn btn-outline-primary btn-sm" CausesValidation="False" CommandName="Select" Text="Select" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <hr />

                        </div>

                        <div class="col-lg-6">
                            <div class="mb-3 mt-3">
                                <label for="txtCategoryID" class="form-label">Category ID :</label>
                                <asp:TextBox ID="txtCategoryID" runat="server" ReadOnly="true" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtCategoryName" class="form-label">Category Name :</label>
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" />
                            </div>
                            <asp:Button ID="btnEdit" Text="Edit" CssClass="btn btn-primary" runat="server" OnClick="btnEdit_Click" />&nbsp;
                            <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-danger" runat="server" OnClick="btnAdd_Click" />&nbsp;
                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" Enabled="false" runat="server" OnClick="btnSave_Click" />&nbsp;
                   
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
