Imports MyWebFormApp.BLL
Imports MyWebFormApp.BLL.DTOs

Public Class CategoriesPage
    Inherits System.Web.UI.Page

    Dim categoryBLL As New CategoryBLL()

    Sub LoadData()
        gvCategories.DataSource = categoryBLL.GetAll()
        gvCategories.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btnSave.Enabled = False
            LoadData()
        End If
    End Sub

    Protected Sub gvCategories_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim categoryID As Integer = Convert.ToInt32(gvCategories.DataKeys(index).Value)
            'Dim categoryName = gvCategories.DataKeys(index)("CategoryName").ToString()
            txtCategoryID.Text = categoryID.ToString()
            Dim objCategory = categoryBLL.GetById(categoryID)
            txtCategoryName.Text = objCategory.CategoryName
        ElseIf e.CommandName = "Delete" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim categoryID As Integer = Convert.ToInt32(gvCategories.DataKeys(index).Value)
            Try
                categoryBLL.Delete(categoryID)
                LoadData()
                ltMessage.Text = "<span class='alert alert-success'>Category deleted successfully</span>"
            Catch ex As Exception
                ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
            End Try
        End If
    End Sub


    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(txtCategoryID.Text) OrElse String.IsNullOrEmpty(txtCategoryName.Text) Then
                ltMessage.Text = "<span class='alert alert-danger'>Category ID and Name are required</span>"
                Return
            End If

            Dim updateCategory As New CategoryUpdateDTO
            updateCategory.CategoryID = Convert.ToInt32(txtCategoryID.Text)
            updateCategory.CategoryName = txtCategoryName.Text
            categoryBLL.Update(updateCategory)
            LoadData()
            ltMessage.Text = "<span class='alert alert-success'>Category updated successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        txtCategoryID.Text = String.Empty
        txtCategoryName.Text = String.Empty
        btnSave.Enabled = True
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Try
            Dim insertCategory As New CategoryCreateDTO
            insertCategory.CategoryName = txtCategoryName.Text
            categoryBLL.Insert(insertCategory)

            LoadData()
            btnSave.Enabled = False
            ltMessage.Text = "<span class='alert alert-success'>Category added successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub gvCategories_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub
End Class