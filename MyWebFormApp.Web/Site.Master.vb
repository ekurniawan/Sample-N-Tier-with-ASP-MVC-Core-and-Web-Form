Imports MyWebFormApp.BLL.DTOs

Public Class SiteMaster
    Inherits MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("User") IsNot Nothing Then
                Dim _userDto As UserDTO = CType(Session("User"), UserDTO)
                ltUsername.Text = _userDto.FirstName & " " & _userDto.LastName
                pnlAnonymous.Visible = False
                pnlLoggedIn.Visible = True
            Else
                ltUsername.Text = "Guest"
                pnlAnonymous.Visible = True
                pnlLoggedIn.Visible = False
            End If
        End If
    End Sub
End Class