Public Class QueryParamPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGet_Click(sender As Object, e As EventArgs)
        Dim dv As DataView = CType(sdsCategories.Select(DataSourceSelectArguments.Empty), DataView)
        For Each drv As DataRow In dv.Table.Rows
            lblGetData.Text &= drv("CategoryID").ToString & " - " & drv("CategoryName").ToString & "<br />"
        Next
    End Sub

    Protected Sub sdsCategories_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs)
        lblKeterangan.Text = "Get data from database...."
    End Sub
End Class