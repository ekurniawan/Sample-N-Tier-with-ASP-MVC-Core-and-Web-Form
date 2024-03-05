<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SampleRepeater.aspx.vb" Inherits="MyWebFormApp.Web.SampleRepeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Sample Repeater</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Sample Repeater</h6>
                </div>
                <div class="card-body">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Category ID</th>
                                <th>Category Name</th>
                                <th>&nbsp;</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptCategory" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("CategoryID") %></td>
                                        <td><%# Eval("CategoryName") %></td>
                                        <td>
                                            <asp:HyperLink Text="details"
                                                NavigateUrl='<%# Eval("CategoryID", "~/DetailArticlePage?CategoryID={0}") %>' CssClass="btn btn-success btn-sm" runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
