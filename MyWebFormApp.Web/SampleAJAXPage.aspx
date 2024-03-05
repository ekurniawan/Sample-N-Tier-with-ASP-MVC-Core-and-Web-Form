<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SampleAJAXPage.aspx.vb" Inherits="MyWebFormApp.Web.SampleAJAXPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Sample AJAX</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Sample AJAX</h6>
                </div>
                <div class="card-body">
                    <asp:Timer ID="Timer1" Interval="2000" runat="server" />
                    Page Time : <%= DateTime.Now.ToString("T") %>
                    <fieldset>
                        <legend>Quote</legend>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1"
                                    EventName="Tick" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Label ID="lblQuote" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
