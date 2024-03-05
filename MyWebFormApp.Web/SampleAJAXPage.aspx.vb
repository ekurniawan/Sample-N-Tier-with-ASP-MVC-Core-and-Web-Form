Public Class SampleAJAXPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim quotes As New List(Of String)
        quotes.Add("ASP.NET 4.6 MVC Release ...")
        quotes.Add("LINQ to SQL in Action ...")
        quotes.Add("Actual Training ...")
        Dim rnd As New Random()
        lblQuote.Text = quotes(rnd.Next(quotes.Count))
    End Sub

End Class