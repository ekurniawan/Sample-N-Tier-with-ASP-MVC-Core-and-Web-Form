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
                            ConnectionString="<%$ ConnectionStrings:MyDbConnectionString %>"
                            SelectCommand="usp_GetCategories" 
                            DeleteCommand="DELETE FROM [Categories] WHERE [CategoryID] = @CategoryID" 
                            InsertCommand="usp_CreateCategory" 
                            FilterExpression="CategoryName LIKE '{0}%'"
                            UpdateCommand="UPDATE [Categories] SET [CategoryName] = @CategoryName WHERE [CategoryID] = @CategoryID" InsertCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
                            <DeleteParameters>
                                <asp:Parameter Name="CategoryID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:ControlParameter ControlID="txtCategoryName" Name="CategoryName" PropertyName="Text" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CategoryName" Type="String" />
                                <asp:Parameter Name="CategoryID" Type="Int32" />
                            </UpdateParameters>
                            <FilterParameters>
                                <asp:ControlParameter ControlID="txtSearch" Name="CategoryName" PropertyName="Text" Type="String" />
                            </FilterParameters>
                        </asp:SqlDataSource>
                        <br />
                        <label>Search Category By Name :</label><br />
                        <asp:TextBox ID="txtSearch" CssClass="form-control" ToolTip="Insert Category Name" runat="server" />
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" />
                        <br />
                        <hr />
                        <label>Insert Category Name :</label><br />
                        <asp:TextBox ID="txtCategoryName" CssClass="form-control" ToolTip="Insert Category Name" runat="server" />
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="btnInsert_Click" /><br />
                        <br />
                        <asp:GridView ID="gvCategories" CssClass="table table-striped" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="CategoryID" DataSourceID="sdsCategory" AllowPaging="True" AllowSorting="True" PageSize="3">
                            <Columns>
                                <asp:BoundField DataField="CategoryID" HeaderText="Category ID"
                                    InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                                <asp:BoundField DataField="CategoryName" HeaderText="Name"
                                    SortExpression="CategoryName" />
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            </Columns>
                        </asp:GridView><br />
                        <asp:Label ID="lblKeterangan" Text="Keterangan" CssClass="text-danger" runat="server" />
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
