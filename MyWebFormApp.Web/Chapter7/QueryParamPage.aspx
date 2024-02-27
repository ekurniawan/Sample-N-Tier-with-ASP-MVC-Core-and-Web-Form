<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="QueryParamPage.aspx.vb" Inherits="MyWebFormApp.Web.QueryParamPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Param Page</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Param Page</h6>
                </div>
                <div class="card-body">
                    <asp:SqlDataSource runat="server" ID="sdsCategories" ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>"
                        SelectCommand="usp_GetCategories" SelectCommandType="StoredProcedure" CacheDuration="3600" EnableCaching="True"
                        OnSelecting="sdsCategories_Selecting">
                    </asp:SqlDataSource>

                    <asp:GridView ID="gvCategories" CssClass="table" runat="server"
                        AutoGenerateColumns="False" DataKeyNames="CategoryID" AllowPaging="True" AllowSorting="True"
                        DataSourceID="sdsCategories">
                        <Columns>
                            <asp:BoundField DataField="CategoryID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                            <asp:HyperLinkField DataNavigateUrlFields="CategoryID" 
                                DataNavigateUrlFormatString="GetQueryParamPage.aspx?id={0}" 
                                DataTextField="CategoryName" HeaderText="Name" />
                        </Columns>
                    </asp:GridView>
                    <hr />
                    <asp:Label ID="lblKeterangan" EnableViewState="false" runat="server" />
                    <hr />
                    <asp:Button ID="btnGet" Text="Get Data" runat="server" OnClick="btnGet_Click" /><br />
                    <asp:Label ID="lblGetData" runat="server" />
                    <hr />
                    <asp:RadioButtonList RepeatColumns="2" ID="rdlCategories" runat="server" DataSourceID="sdsCategories" 
                        DataTextField="CategoryName" DataValueField="CategoryID">
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
