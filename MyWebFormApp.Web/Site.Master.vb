Imports MyWebFormApp.BLL.DTOs

Public Class SiteMaster
    Inherits MasterPage

    Function RenderMenu(roleName As String) As String
        Dim _renderAdmin As String = "<div class='sidebar-heading'>Admin</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='Admin/AddUserToRolePage' runat='server'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Add Role</span>
                    </a>
                </li> <hr class='sidebar-divider my-0'>"

        Dim _renderContributor As String = "<div class='sidebar-heading'>Contributor</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='#'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Add Category</span>
                    </a>
                </li> 
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='ArticleListManualPage'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Add Article</span>
                    </a>
                </li>
                <hr class='sidebar-divider my-0'>"


        Dim _renderReader As String = "<div class='sidebar-heading'>Reader</div>
                <li Class='nav-item'>
                    <a Class='nav-link collapsed' href='#'>
                        <i Class='fas fa-fw fa-cog'></i>
                        <span>Read Article</span>
                    </a>
                </li> <hr class='sidebar-divider my-0'>"


        If roleName = "admin" Then
            Return _renderAdmin
        End If

        If roleName = "contributor" Then
            Return _renderContributor
        End If

        If roleName = "reader" Then
            Return _renderReader
        End If

        Return ""
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim sb As New StringBuilder()

        If Not Page.IsPostBack Then
            If Session("User") IsNot Nothing Then
                Dim _userDto As UserDTO = CType(Session("User"), UserDTO)
                ltUsername.Text = _userDto.FirstName & " " & _userDto.LastName
                pnlAnonymous.Visible = False
                pnlLoggedIn.Visible = True

                For Each role As RoleDTO In _userDto.Roles
                    sb.Append(RenderMenu(role.RoleName))
                Next

                ltMenu.Text = sb.ToString()
            Else
                ltUsername.Text = "Guest"
                pnlAnonymous.Visible = True
                pnlLoggedIn.Visible = False
            End If
        End If
    End Sub
End Class