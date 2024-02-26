Public Class ProductsPage
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim listHobby As New List(Of String)
            listHobby.Add("Reading")
            listHobby.Add("Swimming")
            listHobby.Add("Cycling")
            listHobby.Add("Running")
            listHobby.Add("Singing")
            listHobby.Add("Dancing")

            ddHobby.DataSource = listHobby
            ddHobby.DataBind()
        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        lblHobby.Text = "Anda memilih: " & ddHobby.SelectedItem.Text
    End Sub
End Class