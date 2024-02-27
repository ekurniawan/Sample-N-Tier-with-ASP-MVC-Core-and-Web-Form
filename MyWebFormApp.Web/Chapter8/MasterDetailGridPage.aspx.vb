Public Class MasterDetailGridPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub gvCategories_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim categoryID As Integer = Convert.ToInt32(gvCategories.DataKeys(index).Value)
            lblKeterangan.Text = "You selected category with ID: " & categoryID
        End If
    End Sub
End Class