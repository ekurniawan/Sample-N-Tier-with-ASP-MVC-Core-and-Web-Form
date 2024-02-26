Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    'Protected Sub btnInsert_Click(sender As Object, e As EventArgs)
    '    sdsCategory.InsertParameters("CategoryName").DefaultValue = txtCategoryName.Text
    '    sdsCategory.Insert()
    '    gvCategories.DataBind()
    'End Sub

    Protected Sub sdsCategory_Inserted(sender As Object, e As SqlDataSourceStatusEventArgs) Handles sdsCategory.Inserted
        If e.Exception Is Nothing Then
            lblKeterangan.Text = "Category inserted successfully"
        End If
    End Sub

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs)
        sdsCategory.Insert()
        gvCategories.DataBind()
    End Sub
End Class