Imports MyWebFormApp.BO
Imports MyWebFormApp.DAL

Public Class CategoriesPage
    Inherits System.Web.UI.Page

    Dim categoryDAL As New CategoryDAL()

    Sub LoadData()
        gvCategories.DataSource = categoryDAL.GetAll()
        gvCategories.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()
        End If
    End Sub

    Protected Sub gvCategories_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim categoryID As Integer = Convert.ToInt32(gvCategories.DataKeys(index).Value)
            'Dim categoryName = gvCategories.DataKeys(index)("CategoryName").ToString()
            txtCategoryID.Text = categoryID.ToString()
            Dim objCategory = categoryDAL.GetById(categoryID)
            txtCategoryName.Text = objCategory.CategoryName
        End If
    End Sub


    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(txtCategoryID.Text) OrElse String.IsNullOrEmpty(txtCategoryName.Text) Then
                ltMessage.Text = "<span class='alert alert-danger'>Category ID and Name are required</span>"
                Return
            End If

            Dim updateCategory As New Category
            updateCategory.CategoryID = Convert.ToInt32(txtCategoryID.Text)
            updateCategory.CategoryName = txtCategoryName.Text
            categoryDAL.Update(updateCategory)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Category updated successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub
End Class