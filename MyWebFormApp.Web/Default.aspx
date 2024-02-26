<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.vb" Inherits="MyWebFormApp.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <!-- Basic Card Example -->

            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Category List</h6>
                    </div>
                    <div class="card-body">
                        <asp:SqlDataSource ID="sdsCategory" runat="server"
                            ConnectionString="<%$ ConnectionStrings:LatihanDbConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:LatihanDbConnectionString.ProviderName %>"
                            SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]"></asp:SqlDataSource>
                        <br />


                        <asp:GridView ID="gvCategories" CssClass="table table-striped" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="CategoryID" DataSourceID="sdsCategory">
                            <Columns>
                                <asp:BoundField DataField="CategoryID" HeaderText="Category ID"
                                    InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                                <asp:BoundField DataField="CategoryName" HeaderText="Name"
                                    SortExpression="CategoryName" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
