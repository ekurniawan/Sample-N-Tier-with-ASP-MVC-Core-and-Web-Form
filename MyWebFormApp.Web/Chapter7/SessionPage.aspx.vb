Public Class SessionPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreateSession_Click(sender As Object, e As EventArgs)
        If Session("CategoryID") Is Nothing Then
            Session("CategoryID") = txtCategoryID.Text
            'Session("User") = New User With {
            '    .Username = "admin",
            '    .UserRole = "Administrator"
            '}

            lblKeterangan.Text = "Session has been created"
        Else
            Session("CategoryID") = txtCategoryID.Text
            lblKeterangan.Text = "Session has been updated"
        End If
    End Sub

    Protected Sub btnReadSession_Click(sender As Object, e As EventArgs)
        If Session("CategoryID") IsNot Nothing Then
            lblKeterangan.Text = "Session Value: " & Session("CategoryID")
        Else
            lblKeterangan.Text = "Session not found"
        End If

        'If Session("User") IsNot Nothing Then
        '    Dim user As User = CType(Session("User"), User)
        '    lblKeterangan.Text = "Username: " & user.Username & ", Role: " & user.UserRole
        'Else
        '    lblKeterangan.Text = "User not found"
        'End If
    End Sub

    Protected Sub btnRemoveSession_Click(sender As Object, e As EventArgs)

        If Session("CategoryID") IsNot Nothing Then
            Session.Remove("CategoryID")
            lblKeterangan.Text = "Session has been removed"
        Else
            lblKeterangan.Text = "Session not found"
        End If
    End Sub
End Class