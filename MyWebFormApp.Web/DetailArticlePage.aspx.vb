Imports MyWebFormApp.BLL

Public Class DetailArticlePage
    Inherits System.Web.UI.Page

    Dim _articleBLL As New ArticleBLL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim _categoryID = Request.QueryString("CategoryID")
            Dim _articles = _articleBLL.GetArticleByCategory(CInt(_categoryID))
            lvArticles.DataSource = _articles
            lvArticles.DataBind()
        End If
    End Sub

End Class