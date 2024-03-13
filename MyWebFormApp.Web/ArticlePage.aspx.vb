Public Class ArticlePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblCategory.Text = "Category ID: " & Request.QueryString("CategoryID")
        End If
    End Sub

End Class