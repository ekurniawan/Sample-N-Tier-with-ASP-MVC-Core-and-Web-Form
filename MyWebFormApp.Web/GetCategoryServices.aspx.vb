Public Class GetCategoryServices
    Inherits System.Web.UI.Page

    Dim listCategories As List(Of Category)

    Async Sub loadCategories()
        Using catServ As New CategoriesService
            listCategories = Await catServ.GetCategories()
        End Using
        gvCategories.DataSource = listCategories
        gvCategories.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadCategories()
        End If
    End Sub

    Protected Async Sub btnAdd_Click(sender As Object, e As EventArgs)
        'insert with httpclient
        Dim category As New Category
        category.categoryName = txtCategoryName.Text

        Using catServ As New CategoriesService
            Dim result As Boolean = Await catServ.AddCategory(category)
            If result Then
                ltMessage.Text = "<span class='alert alert-success'>Berhasil tambah data Category</span>"
                loadCategories()
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Gagal tambah data Category</span>"
            End If
        End Using
    End Sub
End Class