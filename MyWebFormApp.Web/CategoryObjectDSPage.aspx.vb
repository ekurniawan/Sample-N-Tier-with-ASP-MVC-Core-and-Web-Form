Imports System.Web.ModelBinding
Imports MyWebFormApp.BLL
Imports MyWebFormApp.BLL.DTOs

Public Class CategoryObjectDSPage
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New CategoryBLL()

    Public Function GetAll(<Control("txtSearch")> categoryName As String) As List(Of CategoryDTO)
        Return _categoryBLL.GetByName(categoryName)
    End Function

    Public Sub Update(CategoryID As Integer, CategoryName As String)
        Try
            'updateCategory.CategoryName =
            Dim _categoryUpdateDTO As New CategoryUpdateDTO
            _categoryUpdateDTO.CategoryID = CategoryID
            _categoryUpdateDTO.CategoryName = CategoryName

            _categoryBLL.Update(_categoryUpdateDTO)
            ltMessage.Text = "<span class='alert alert-success'>Category updated successfully</span>"

            gvCategories.DataBind()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ' The id parameter name should match the DataKeyNames value set on the control
    Public Sub Delete(CategoryID As Integer)
        Try
            _categoryBLL.Delete(CategoryID)
            ltMessage.Text = "<span class='alert alert-success'>Category deleted successfully</span>"
            gvCategories.DataBind()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub
End Class