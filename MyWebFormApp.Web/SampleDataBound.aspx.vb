Public Class SampleDataBound
    Inherits System.Web.UI.Page

    'Sub LoadDataCategoriesDataList()
    '    Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
    '    Dim results = _categoryBLL.GetAll()

    '    dlCategory.DataSource = results
    '    dlCategory.DataBind()
    'End Sub

    Sub LoadDataCategoriesRepeater()
        Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
        Dim results = _categoryBLL.GetAll()

        rpCategories.DataSource = results
        rpCategories.DataBind()
    End Sub

    Sub LoadDataCategoriesGridView()
        Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
        Dim results = _categoryBLL.GetAll()

        gvCategories.DataSource = results
        gvCategories.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadDataCategoriesGridView()
            LoadDataCategoriesRepeater()
        End If
    End Sub

    Protected Sub gvCategories_SelectedIndexChanged(sender As Object, e As EventArgs)
        ltMessage.Text = "You selected " & gvCategories.SelectedValue & " - " &
            gvCategories.SelectedRow().Cells(1).Text
    End Sub

    Protected Sub gvCategories_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        ltMessage.Text = "You clicked " & e.CommandName
    End Sub

    Protected Sub gvCategories_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvCategories_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub gvCategories_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

    End Sub

    Protected Sub gvCategories_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

    End Sub

    Protected Sub gvCategories_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs)

    End Sub
End Class