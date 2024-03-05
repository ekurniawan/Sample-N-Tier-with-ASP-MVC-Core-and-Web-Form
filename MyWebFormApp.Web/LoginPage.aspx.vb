Imports MyWebFormApp.BLL

Public Class LoginPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim _userBLL As New UserBLL()
            Dim _userDto = _userBLL.Login(txtUsername.Text, txtPassword.Text)
            If _userDto IsNot Nothing Then
                Session("User") = _userDto

                Dim returnUrl = Request.QueryString("ReturnUrl")

                If Not String.IsNullOrEmpty(returnUrl) Then
                    Response.Redirect("~/" & returnUrl)
                Else
                    Response.Redirect("~/Default.aspx")
                End If
            Else
                ltMessage.Text = "<br/><span class='alert alert-danger'>Error: Invalid Username / Password </span><br/><br/>"
            End If
        Catch ex As Exception
            ltMessage.Text = "<br/><span class='alert alert-danger'>Error: " & ex.Message & "</span><br/><br/>"
        End Try
    End Sub
End Class