<%@ Page Title="Registration Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistrationPage.aspx.vb" Inherits="MyWebFormApp.Web.RegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Registration</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Registration Page</h6>
                </div>
                <div class="card-body">
                    <asp:Literal ID="ltMessage" runat="server" />
                    <div class="form-group">
                        <label for="txtUsername">Username :</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtPassword">Password :</label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtRepassword">Repassword :</label>
                        <asp:TextBox ID="txtRepassword" TextMode="Password" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtFirstName">Firstname :</label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtLastname">Lastname :</label>
                        <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtAddress">Address :</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtEmail">Email :</label>
                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtTelp">Telp :</label>
                        <asp:TextBox ID="txtTelp" runat="server" CssClass="form-control" />
                    </div>
                    <asp:Button ID="btnRegistration" Text="Register" CssClass="btn btn-success btn-sm" runat="server" OnClick="btnRegistration_Click" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
