Public Class CookiePage
    Inherits System.Web.UI.Page

    Private CategoryIDCookie As HttpCookie

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSetCookie_Click(sender As Object, e As EventArgs)
        If Request.Cookies("CategoryID") Is Nothing Then
            CategoryIDCookie = New HttpCookie("CategoryID", txtCategoryID.Text)
            CategoryIDCookie.Expires = DateTime.Now.AddMinutes(5)
            Response.AppendCookie(CategoryIDCookie)

            lblCookie.Text = "Cookie has been set"
        Else
            Dim currCookie As HttpCookie = Request.Cookies("CategoryID")
            currCookie.Value = txtCategoryID.Text
            currCookie.Expires = DateTime.Now.AddMinutes(5)
            Response.SetCookie(currCookie)
            lblCookie.Text = "Cookie has been updated"
        End If
    End Sub

    Protected Sub btnGetCookie_Click(sender As Object, e As EventArgs)
        If Request.Cookies("CategoryID") IsNot Nothing Then
            CategoryIDCookie = Request.Cookies("CategoryID")
            lblCookie.Text = "Cookie Value: " & CategoryIDCookie.Value
        Else
            lblCookie.Text = "Cookie not found"
        End If
    End Sub


End Class