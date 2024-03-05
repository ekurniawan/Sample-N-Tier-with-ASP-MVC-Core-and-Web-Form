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

                    <asp:Literal ID="ltMessage" runat="server" />
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


                    <div class="row">
                        <div class="col-lg-12">
                            <table class="table table-hover">
                                <asp:ListView ID="lvArticles" DataKeyNames="ArticleID"
                                    OnSelectedIndexChanging="lvCategories_SelectedIndexChanging"
                                    OnSelectedIndexChanged="lvArticles_SelectedIndexChanged"
                                    OnItemCommand="lvArticles_ItemCommand"
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
                        <%--  <div class="col-lg-4">
                            <div class="form-group">
                                <div class="form-group">
                                    <label for="ddCategories">Category :</label>
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtTitle">Title :</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Title" />
                                </div>
                                <div class="form-group">
                                    <label for="txtDetail">Details :</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"
                                        TextMode="MultiLine" placeholder="Enter Detail" />
                                </div>
                                <div class="form-group form-check">
                                    <label class="form-check-label">
                                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="form-check-input" />
                                        Is Approved
                                    </label>
                                </div>
                                <div class="form-group">
                                    <label for="fpPic">Picture :</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                </div>
                                <asp:Button Text="Submit" ID="Button1" CssClass="btn btn-primary btn-sm"
                                    OnClick="btnSubmit_Click" runat="server" />
                            </div>
                        </div>--%>


                        <!-- Modal Add -->
                        <div class="modal" id="myModal">
                            <div class="modal-dialog">
                                <div class="modal-content">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
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
                                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Enter Title" />
                                                </div>
                                                <div class="form-group">
                                                    <label for="txtDetail">Details :</label>
                                                    <asp:TextBox ID="txtDetail" runat="server" CssClass="form-control"
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                </div>
                            </div>
                        </div>

                        <!-- Modal Edit -->
                        <div class="modal" id="myModalEdit">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <!-- Modal Header -->
                                    <div class="modal-header">
                                        <h4 class="modal-title">Edit Article</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <!-- Modal body -->
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="txtArticleIDEdit">Article ID :</label>
                                            <asp:TextBox ID="txtArticleIDEdit" Enabled="false" runat="server" CssClass="form-control"
                                                placeholder="Enter Detail" />
                                        </div>
                                        <div class="form-group">
                                            <label for="ddCategoriesEdit">Category :</label>
                                            <asp:DropDownList ID="ddCategoriesEdit" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label for="txtTitleEdit">Title :</label>
                                            <asp:TextBox ID="txtTitleEdit" runat="server" CssClass="form-control" placeholder="Enter Title" />
                                        </div>
                                        <div class="form-group">
                                            <label for="txtDetailEdit">Details :</label>
                                            <asp:TextBox ID="txtDetailEdit" runat="server" CssClass="form-control"
                                                TextMode="MultiLine" placeholder="Enter Detail" />
                                        </div>
                                        <div class="form-group form-check">
                                            <label class="form-check-label">
                                                <asp:CheckBox ID="chkApprovedEdit" runat="server" CssClass="form-check-input" />
                                                Is Approved
                                            </label>
                                        </div>
                                        <div class="form-group">
                                            <label for="fpPic">Picture :</label>
                                            <asp:Label ID="lblPic" Visible="false" runat="server" />
                                            <asp:FileUpload ID="fpPicEdit" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>

                                    <!-- Modal footer -->
                                    <div class="modal-footer">
                                        <asp:Button Text="Edit" ID="btnEdit" CssClass="btn btn-primary btn-sm"
                                            OnClick="btnEdit_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
            </div>
        </div>
</asp:Content>
