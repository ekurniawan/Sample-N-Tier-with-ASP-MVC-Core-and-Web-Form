Imports MyWebFormApp.BLL
Imports MyWebFormApp.BLL.DTOs

Public Class AddUserToRolePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim _user = CType(Session("User"), UserDTO)
            If _user IsNot Nothing Then
                Dim cek = From r In _user.Roles
                          Where r.RoleName.Contains("admin")
                          Select r

                If cek.Count = 0 Then
                    Response.Redirect("~/LoginPage.aspx")
                End If
            Else
                Response.Redirect("~/LoginPage.aspx?ReturnUrl=Admin/AddUserToRolePage")
            End If

            Dim _userBLL As New UserBLL()
            Dim _userList = _userBLL.GetAll()
            ddUser.DataSource = _userList
            ddUser.DataTextField = "Username"
            ddUser.DataValueField = "Username"
            ddUser.DataBind()

            Dim _roleBLL As New RoleBLL()
            Dim _roleList = _roleBLL.GetAllRoles()
            ddRole.DataSource = _roleList
            ddRole.DataTextField = "RoleName"
            ddRole.DataValueField = "RoleID"
            ddRole.DataBind()
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Try
            Dim _roleBLL As New RoleBLL()
            _roleBLL.AddUserToRole(ddUser.SelectedValue, ddRole.SelectedValue)
            ltMessage.Text = "User added to role successfully"
        Catch ex As Exception
            ltMessage.Text = "Error: " & ex.Message
        End Try
    End Sub
End Class