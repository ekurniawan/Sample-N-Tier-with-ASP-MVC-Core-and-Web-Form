Imports MyWebFormApp.BLL.DTOs

Public Class ArticleListPage
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
    Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String

    Public Function lvCategories_GetData() As IEnumerable(Of MyWebFormApp.BLL.DTOs.CategoryDTO)
        Dim results = _categoryBLL.GetAll()
        Return results
    End Function

    Protected Sub lvCategories_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        If e.CommandName = "Select" Then
            'Dim lnkSelect = CType(e.Item.FindControl("lnkSelect"), LinkButton)
            Dim categoryid = e.CommandArgument.ToString()
            ltMessage.Text = categoryid
        End If
    End Sub

    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String
    Public Function lvArticles_GetData() As IEnumerable(Of ArticleDTO)
        Return Nothing
    End Function
End Class