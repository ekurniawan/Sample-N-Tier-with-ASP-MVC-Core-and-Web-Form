Public Class ArticleListManualPage
    Inherits System.Web.UI.Page

#Region "Binding Data"
    Sub LoadDataCategories()
        Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
        Dim results = _categoryBLL.GetAll()
        lvCategories.DataSource = results
        lvCategories.DataBind()
    End Sub

    Sub LoadDataArticles()
        Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL
        Dim results = _articleBLL.GetArticleByCategory(CInt(lvCategories.SelectedValue.ToString))
        lvArticles.DataSource = results
        lvArticles.DataBind()
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadDataCategories()
        End If
    End Sub

    Protected Sub lvCategories_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)
        'Dim categoryid = lvCategories.DataKeys(e.NewSelectedIndex).Value
        'ltMessage.Text = categoryid.ToString()
    End Sub

    Protected Sub lvCategories_SelectedIndexChanged(sender As Object, e As EventArgs)
        'ViewState("CategoryID") = lvCategories.SelectedValue.ToString()
        'ltMessage.Text = lvCategories.SelectedValue.ToString()
        LoadDataCategories()
        LoadDataArticles()
    End Sub


End Class