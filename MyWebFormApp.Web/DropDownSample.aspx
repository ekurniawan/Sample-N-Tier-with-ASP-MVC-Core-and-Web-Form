<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DropDownSample.aspx.vb" Inherits="MyWebFormApp.Web.DropDownSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Dropdown Sample</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Dropdown Sample</h6>
                </div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:DropDownList ID="ddCategories" AutoPostBack="true" runat="server"
                                    AppendDataBoundItems="true" OnSelectedIndexChanged="ddCategories_SelectedIndexChanged"
                                    CssClass="form-control">
                                    <asp:ListItem Selected="True">-- Select Category --</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:DropDownList ID="ddArticle" Enabled="false" runat="server"
                                    AppendDataBoundItems="true"
                                    CssClass="form-control">
                                    <asp:ListItem Selected="True">-- Select Article --</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>

        </div>

    </div>
</asp:Content>
