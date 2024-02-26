<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"  CodeBehind="ProductsPage.aspx.vb" Inherits="MyWebFormApp.Web.ProductsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
         <h1 class="h3 mb-0 text-gray-800">Products</h1>
     </div>

     <div class="col-lg-12">
         <!-- Basic Card Example -->
         <div class="card shadow mb-4">
             <div class="card-header py-3">
                 <h6 class="m-0 font-weight-bold text-primary">About Page</h6>
             </div>
             <div class="card-body">
                 
                 <asp:DropDownList ID="ddHobby" runat="server"></asp:DropDownList><br />
                 <asp:Label ID="lblHobby" runat="server" /><br />
                 <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" runat="server" OnClick="btnSubmit_Click" />
             </div>
         </div>
     </div>

 </div>
</asp:Content>
