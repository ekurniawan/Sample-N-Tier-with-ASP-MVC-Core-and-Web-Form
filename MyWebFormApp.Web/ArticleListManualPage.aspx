<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ArticleListManualPage.aspx.vb" 
    Inherits="MyWebFormApp.Web.ArticleListManualPage" %>

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
                    <asp:Literal ID="ltMessage" runat="server" EnableViewState="false" />
                    <div class="row">
                        <asp:ListView ID="lvCategories" DataKeyNames="CategoryID"
                            OnSelectedIndexChanging="lvCategories_SelectedIndexChanging"
                            OnSelectedIndexChanged="lvCategories_SelectedIndexChanged" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-2 mb-2">
                                    <asp:LinkButton ID="lnkSelect" Text='<%# Eval("CategoryName") %>' CommandName="Select"
                                        runat="server" CssClass="btn btn-outline-info btn-sm" />
                                </div>
                            </ItemTemplate>
                            <SelectedItemTemplate>
                                <div class="col-lg-2 mb-2">
                                    <asp:LinkButton ID="lnkSelect" Text='<%# Eval("CategoryName") %>'
                                        runat="server" CssClass="btn btn-info btn-sm" />
                                </div>
                            </SelectedItemTemplate>
                        </asp:ListView>
                    </div>
                    <br />
                    <button type="button" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#myModal">
                        Add Article
                    </button>
                    <table class="table table-hover">
                        <asp:ListView ID="lvArticles" DataKeyNames="ArticleID" runat="server">
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
                                    <td><%# Eval("ArticleID") %></td>
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

                    <!-- The Modal -->
                    <div class="modal" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">

                                <!-- Modal Header -->
                                <div class="modal-header">
                                    <h4 class="modal-title">Add Article</h4>
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                </div>

                                <!-- Modal body -->
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label for="ddCategories">Category :</label>
                                        <asp:DropDownList ID="ddCategories" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <label for="txtTitle">Title :</label>
                                        <asp:TextBox ID="txtTitle" runat="server" EnableViewState="false" CssClass="form-control" placeholder="Enter Title" />
                                    </div>
                                    <div class="form-group">
                                        <label for="txtDetail">Details :</label>
                                        <asp:TextBox ID="txtDetail" runat="server" EnableViewState="false" CssClass="form-control"
                                            TextMode="MultiLine" placeholder="Enter Detail" />
                                    </div>
                                    <div class="form-group form-check">
                                        <label class="form-check-label">
                                            <asp:CheckBox ID="chkIsApproved" runat="server" CssClass="form-check-input" />
                                            Is Approved
                                        </label>
                                    </div>
                                    <div class="form-group">
                                        <label for="fpPic">Picture :</label>
                                        <asp:FileUpload ID="fpPic" runat="server" CssClass="form-control" />
                                    </div>
                                </div>

                                <!-- Modal footer -->
                                <div class="modal-footer">
                                    <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-primary btn-sm"
                                        OnClick="btnSubmit_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
