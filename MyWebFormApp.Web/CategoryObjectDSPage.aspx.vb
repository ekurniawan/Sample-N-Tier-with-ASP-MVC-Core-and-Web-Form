Imports MyWebFormApp.BLL
Imports MyWebFormApp.BLL.DTOs

Public Class CategoryObjectDSPage
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New CategoryBLL()

    Public Function GetAll() As List(Of CategoryDTO)
        Return _categoryBLL.GetAll()
    End Function

    Public Sub Update(CategoryID As Integer, CategoryName As String)
        Try
            'updateCategory.CategoryName =
            Dim _categoryUpdateDTO As New CategoryUpdateDTO
            _categoryUpdateDTO.CategoryID = CategoryID
            _categoryUpdateDTO.CategoryName = CategoryName

            _categoryBLL.Update(_categoryUpdateDTO)
            lblKeterangan.Text = "Data berhasil diupdate " & CategoryName.ToString()

            gvCategories.DataBind()
        Catch ex As Exception
            lblKeterangan.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ' The id parameter name should match the DataKeyNames value set on the control
    Public Sub Delete(CategoryID As Integer)
        Try
            _categoryBLL.Delete(CategoryID)
            lblKeterangan.Text = "Data berhasil dihapus " & CategoryID.ToString()
            gvCategories.DataBind()
        Catch ex As Exception
            lblKeterangan.Text = ex.Message
        End Try
    End Sub
End Class