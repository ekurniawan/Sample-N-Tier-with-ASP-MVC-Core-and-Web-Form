Imports MyWebFormApp.BLL

Public Class DropDownSample
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New CategoryBLL
    Dim _articleBLL As New ArticleBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim _categories = _categoryBLL.GetAll()
            ddCategories.DataSource = _categories
            ddCategories.DataTextField = "CategoryName"
            ddCategories.DataValueField = "CategoryID"
            ddCategories.DataBind()
        End If
    End Sub

    Protected Sub ddCategories_SelectedIndexChanged(sender As Object, e As EventArgs)
        ddArticle.Items.Clear()
        Dim articles = _articleBLL.GetArticleByCategory(ddCategories.SelectedValue)

        If articles.Count = 0 Then
            ddArticle.Items.Add(New ListItem("No articles found", "0"))
            ddArticle.Enabled = False
            Return
        End If

        ddArticle.DataSource = articles
        ddArticle.DataTextField = "Title"
        ddArticle.DataValueField = "ArticleID"
        ddArticle.DataBind()
        ddArticle.Enabled = True
    End Sub
End Class