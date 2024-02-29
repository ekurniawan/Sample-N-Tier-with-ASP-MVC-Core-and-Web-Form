Imports MyWebFormApp.BLL

Public Class CategoryWithListViewPage
    Inherits System.Web.UI.Page


    Dim _categoryBLL As New CategoryBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lvCategories.DataSource = _categoryBLL.GetAll()
            lvCategories.DataBind()
        End If
    End Sub

End Class