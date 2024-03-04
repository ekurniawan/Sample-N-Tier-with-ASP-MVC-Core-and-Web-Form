<%@ Page Title="Add User To Role" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AddUserToRolePage.aspx.vb" Inherits="MyWebFormApp.Web.AddUserToRolePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">User To Role</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Add User To Role</h6>
                </div>
                <div class="card-body">
                    <asp:Literal ID="ltMessage" runat="server" />
                    <div class="form-group">
                        <asp:DropDownList ID="ddUser" CssClass="form-control" runat="server" /><br />
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddRole" CssClass="form-control" runat="server" />
                    </div>
                    <asp:Button ID="btnSubmit" Text="Add User To Role" CssClass="btn btn-success btn-sm" runat="server" OnClick="btnSubmit_Click" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
