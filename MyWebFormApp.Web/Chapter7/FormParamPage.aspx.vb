Public Class FormParamPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Form("action") IsNot Nothing Then
            'sdsCategories.InsertParameters("CategoryName").DefaultValue = Request.Form("CategoryName")
            sdsCategories.Insert()
            lblKeterangan.Text = "Insert data " & Request.Form("CategoryName") & " berhasil"
        End If
    End Sub

End Class