Imports MyWebFormApp.BLL
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


    Sub GetEditArticle(id As Integer)
        Dim _categoryBLL As New CategoryBLL
        Dim _categores = _categoryBLL.GetAll()

        Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL
        Dim _article = _articleBLL.GetArticleById(id)


        Try
            ddCategoriesEdit.DataSource = _categores
            ddCategoriesEdit.DataTextField = "CategoryName"
            ddCategoriesEdit.DataValueField = "CategoryID"
            ddCategoriesEdit.DataBind()

            If _article IsNot Nothing Then
                txtArticleIDEdit.Text = _article.ArticleID
                txtTitleEdit.Text = _article.Title
                txtDetailEdit.Text = _article.Details
                chkApprovedEdit.Checked = _article.IsApproved
                ddCategoriesEdit.SelectedValue = _article.CategoryID
                lblPic.Text = _article.Pic
            Else
                ltMessage.Text = "<span class='alert alert-danger'>Error: Article not found</span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
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
            'If Session("User") Is Nothing Then
            '    Response.Redirect("~/LoginPage.aspx")
            'End If

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
            _article.IsApproved = If(chkApprovedEdit.Checked, 1, 0)
            _article.Pic = fileName
            _articleBLL.Insert(_article)

            ltMessage.Text = "<span class='alert alert-success'>Artice added successfully</span><br/><br/>"
            InitializeFormAddArticle()
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub


    Protected Sub lvArticles_SelectedIndexChanged(sender As Object, e As EventArgs)
        'ltMessage.Text = lvArticles.SelectedValue.ToString()
        If ViewState("Command") = "Delete" Then
            Try
                Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL
                _articleBLL.Delete(CInt(lvArticles.SelectedValue.ToString))
                lvArticles.DataBind()

                LoadDataArticles(CInt(lvCategories.SelectedValue.ToString))
                ltMessage.Text = "<span class='alert alert-success'>Artice deleted successfully</span><br/><br/>"
            Catch ex As Exception
                ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
            End Try
        ElseIf ViewState("Command") = "Edit" Then
            ltMessage.Text = "<span class='alert alert-success'>Edit</span><br/><br/>"
            GetEditArticle(CInt(lvArticles.SelectedValue.ToString))
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenModalScript", "$(window).on('load',function(){$('#myModalEdit').modal('show');})", True)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try
            'rename upload file
            Dim fileName As String = Guid.NewGuid.ToString() & fpPicEdit.FileName
            If fpPicEdit.HasFile Then
                If CheckFileType(fileName) Then
                    Dim _path As String = Server.MapPath("~/Pics/")
                    fpPicEdit.SaveAs(_path & fileName)
                End If
            End If

            Dim _articleBLL As New MyWebFormApp.BLL.ArticleBLL
            Dim _article As New ArticleUpdateDTO
            _article.ArticleID = CInt(txtArticleIDEdit.Text)
            _article.CategoryID = CInt(ddCategoriesEdit.SelectedValue)
            _article.Title = txtTitleEdit.Text
            _article.Details = txtDetailEdit.Text
            _article.IsApproved = chkApprovedEdit.Checked
            _article.Pic = If(fpPicEdit.HasFile, fileName, lblPic.Text)
            _articleBLL.Update(_article)

            lvArticles.DataBind()

            LoadDataArticles(CInt(lvCategories.SelectedValue.ToString))
            ltMessage.Text = "<span class='alert alert-success'>Artice updated successfully</span><br/><br/>"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CloseModalScript", "$('#myModalEdit').modal('hide');", True)
        Catch ex As Exception
            ltMessage.Text = "<span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub

    Protected Sub lvArticles_ItemCommand(sender As Object, e As ListViewCommandEventArgs)
        'Dim lvDataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        ViewState("Command") = e.CommandArgument
    End Sub
End Class