Imports MyWebFormApp.BLL

Public Class SampleRepeater
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New CategoryBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim categories = _categoryBLL.GetAll()
            rptCategory.DataSource = categories
            rptCategory.DataBind()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "tablesorter", "$(document).ready(function() {$('#dataTable').DataTable();});", True)
        End If
    End Sub

End Class