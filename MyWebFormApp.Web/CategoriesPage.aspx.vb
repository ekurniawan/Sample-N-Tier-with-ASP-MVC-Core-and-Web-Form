Imports MyWebFormApp.DAL

Public Class CategoriesPage
    Inherits System.Web.UI.Page

    Dim categoryDAL As New CategoryDAL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            gvCategories.DataSource = categoryDAL.GetAll()
            gvCategories.DataBind()
        End If
    End Sub

    Protected Sub gvCategories_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim categoryID As Integer = Convert.ToInt32(gvCategories.DataKeys(index).Value)
            lblCategory.Text = "Category ID yg dipilih: " & categoryID.ToString()
        End If
    End Sub
End Class