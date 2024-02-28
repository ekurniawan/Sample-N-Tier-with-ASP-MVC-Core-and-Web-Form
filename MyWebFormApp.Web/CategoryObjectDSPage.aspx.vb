Imports MyWebFormApp.BLL
Imports MyWebFormApp.BLL.DTOs

Public Class CategoryObjectDSPage
    Inherits System.Web.UI.Page

    Dim _categoryBLL As New CategoryBLL()

    Dim pageNumber As Integer
    Dim pageSize As Integer

#Region "Initiate"
    Sub InitiateButtonNavigation()
        If CInt(ViewState("PageNumber")) = 1 Then
            btnPrev.Enabled = False
            btnNext.Enabled = True
        ElseIf CInt(ViewState("PageNumber")) = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize"))) + 1 Then
            btnPrev.Enabled = True
            btnNext.Enabled = False
        Else
            btnPrev.Enabled = True
            btnNext.Enabled = True
        End If
    End Sub
#End Region

    'Public Function GetAll(<Control("txtSearch")> categoryName As String) As List(Of CategoryDTO)
    '    Return _categoryBLL.GetByName(categoryName)
    'End Function

    Public Function GetAll() As List(Of CategoryDTO)
        'Return _categoryBLL.GetWithPaging(2, 5)
        Return _categoryBLL.GetWithPaging(CInt(ViewState("PageNumber")), CInt(ViewState("PageSize")))
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
        If Not Page.IsPostBack Then
            Dim recordCount = _categoryBLL.GetCountCategories()
            ViewState("PageNumber") = 1
            ViewState("PageSize") = 5
            ViewState("RecordCount") = recordCount
            ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & Math.Floor(recordCount / CInt(ViewState("PageSize")) + 1)
            InitiateButtonNavigation()
        End If
        pageNumber = CInt(ViewState("PageNumber"))
        pageSize = CInt(ViewState("PageSize"))

        'ltMessage.Text = pageNumber & " " & pageSize
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

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try
            Dim newCategory As New CategoryCreateDTO
            newCategory.CategoryName = txtCategoryName.Text
            _categoryBLL.Insert(newCategory)

            gvCategories.DataBind()
            ltMessage.Text = "<span class='alert alert-success'>Category added successfully</span>"
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span>"
        End Try
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs)

        Dim maxPage = Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize"))) + 1

        If CInt(ViewState("PageNumber")) < maxPage Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) + 1
            gvCategories.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the last page</span>"
        End If
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & maxPage
        InitiateButtonNavigation()
    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs)
        If CInt(ViewState("PageNumber")) > 1 Then
            ViewState("PageNumber") = CInt(ViewState("PageNumber")) - 1
            gvCategories.DataBind()
        Else
            ltMessage.Text = "<span class='alert alert-danger'>You are on the first page</span>"
        End If
        ltPosition.Text = "Page " & ViewState("PageNumber") & " of " & Math.Floor(CInt(ViewState("RecordCount")) / CInt(ViewState("PageSize")) + 1)
        InitiateButtonNavigation()
    End Sub
End Class