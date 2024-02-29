Imports MyWebFormApp.BLL.DTOs

Public Class ArticleListManualPage
    Inherits System.Web.UI.Page

#Region "Binding Data"


    Sub LoadDataCategories()
        Dim _categoryBLL As New MyWebFormApp.BLL.CategoryBLL
        Dim results = _categoryBLL.GetAll()
        lvCategories.DataSource = results
        lvCategories.DataBind()

        ddCategories.DataSource = results
        ddCategories.DataTextField = "CategoryName"
        ddCategories.DataValueField = "CategoryID"
        ddCategories.DataBind()
    End Sub

    Sub LoadDataArticles(categoryID As String)
        Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL
        Dim results = _articleBLL.GetArticleByCategory(categoryID)
        lvArticles.DataSource = results
        lvArticles.DataBind()
    End Sub

#End Region

#Region "Validate"
    Function CheckFileType(ByVal fileName As String) As Boolean
        Dim ext As String = IO.Path.GetExtension(fileName)
        Select Case ext.ToLower()
            Case ".gif"
                Return True
            Case ".png"
                Return True
            Case ".jpg"
                Return True
            Case ".jpeg"
                Return True
            Case ".bmp"
                Return True
            Case Else
                Return False
        End Select
    End Function
#End Region

#Region "Initialize"
    Sub InitializeFormAddArticle()
        txtTitle.Text = String.Empty
        txtDetail.Text = String.Empty
        chkIsApproved.Checked = False
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
        LoadDataArticles(CInt(lvCategories.SelectedValue.ToString))
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Try
            'rename upload file
            Dim fileName As String = Guid.NewGuid.ToString() & fpPic.FileName
            If fpPic.HasFile Then
                If CheckFileType(fileName) Then
                    Dim _path As String = Server.MapPath("~/Pics/")
                    fpPic.SaveAs(_path & fileName)
                Else
                    ltMessage.Text = "<span class='alert alert-danger'>Error: Only images are allowed</span><br/><br/>"
                    Return
                End If
            End If

            Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL
            Dim _article As New ArticleCreateDTO
            _article.CategoryID = CInt(ddCategories.SelectedValue)
            _article.Title = txtTitle.Text
            _article.Details = txtDetail.Text
            _article.IsApproved = If(chkIsApproved.Checked, 1, 0)
            _article.Pic = fileName
            _articleBLL.Insert(_article)

            ltMessage.Text = "<span class='alert alert-success'>Artice added successfully</span><br/><br/>"
            InitializeFormAddArticle()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub


    Protected Sub lvArticles_SelectedIndexChanged(sender As Object, e As EventArgs)
        ltMessage.Text = lvArticles.SelectedValue.ToString()
        ltShowModal.Text = "<script>$('#myModal').modal('show');</script>"
    End Sub
End Class