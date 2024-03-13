<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SampleDataBound.aspx.vb" Inherits="MyWebFormApp.Web.SampleDataBound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Sample Databound Control</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Sample Databound</h6>
                </div>
                <div class="card-body">
                    <%-- <asp:DataList ID="dlCategory" DataKeyField="CategoryID" RepeatColumns="3" runat="server">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card shadow mb-4">
                                        <div class="card-header py-3">
                                            <h6 class="m-0 font-weight-bold text-primary"><%# Eval("CategoryID") %></h6>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <p><%# Eval("CategoryName") %></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>--%>
                    <asp:Repeater ID="rpCategories" runat="server">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="card shadow mb-4">
                                        <div class="card-header py-3">
                                            <h6 class="m-0 font-weight-bold text-primary"><%# Eval("CategoryID") %></h6>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <p><%# Eval("CategoryName") %></p>
                                                    <p>
                                                        <%--<asp:HyperLink NavigateUrl='<%# Eval("CategoryID", "~/ArticlePage?CategoryID={0}") %>' Text="detail" runat="server" />--%>
                                                        <input type="checkbox" name='<%# Eval("CategoryID", "chk{0}") %>' value='<%# Eval("CategoryID") %>' />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="ltMessage" runat="server" />
                    <asp:GridView ID="gvCategories" AutoGenerateColumns="False"
                        DataKeyNames="CategoryID"  
                        OnSelectedIndexChanged="gvCategories_SelectedIndexChanged"
                        OnRowCommand="gvCategories_RowCommand"
                        OnRowEditing="gvCategories_RowEditing"
                        OnRowUpdated="gvCategories_RowUpdated"
                        OnRowDeleting="gvCategories_RowDeleting"
                        OnRowCancelingEdit="gvCategories_RowCancelingEdit"
                        OnRowUpdating="gvCategories_RowUpdating"
                        runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="Category ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" Text='<%# Bind("CategoryID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="detail" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
