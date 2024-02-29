Imports System.Web.ModelBinding
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
            'ltMessage.Text = categoryid

            'jika menggunakan manual / tanpa model binding
            'Dim results = _articleBLL.GetArticleByCategory(CInt(categoryid))
            'lvArticles.DataSource = results
            'lvArticles.DataBind()
        End If
    End Sub

    ' The return type can be changed to IEnumerable, however to support
    ' paging and sorting, the following parameters must be added:
    '     ByVal maximumRows as Integer
    '     ByVal startRowIndex as Integer
    '     ByRef totalRowCount as Integer
    '     ByVal sortByExpression as String
    Public Function lvArticles_GetData(<Control("lvCategories")> _categoryID As String) As IEnumerable(Of ArticleDTO)
        Dim results = _articleBLL.GetArticleByCategory(CInt(_categoryID))
        Return results
    End Function
End Class