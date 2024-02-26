Imports System.Data.SqlClient

Public Class ProductsPage
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub sdsArticles_Selected(sender As Object, e As SqlDataSourceStatusEventArgs)
        If e.Exception IsNot Nothing Then
            lblError.Text = "An error occurred while retrieving data. " & e.Exception.Message
            e.ExceptionHandled = True
        End If
    End Sub

    Protected Sub sdsArticles_Updating(sender As Object, e As SqlDataSourceCommandEventArgs)

        Dim sb As New StringBuilder
        For Each p As SqlParameter In e.Command.Parameters
            If p.Value Is Nothing Then
                e.Cancel = True
                sb.Append(p.ParameterName & " is null" & "<br />")
            End If
        Next
        lblError.Text = sb.ToString
    End Sub
End Class