Imports System.Net.Http
Imports Newtonsoft.Json

Public Class GetCategoryServices
    Inherits System.Web.UI.Page

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim listCategories As List(Of Category) = New List(Of Category)
            Dim _httpClient As New HttpClient
            Dim _response As HttpResponseMessage = Await _httpClient.GetAsync("http://localhost:5272/api/v1/Categories")
            If _response.IsSuccessStatusCode Then
                Dim content = Await _response.Content.ReadAsStringAsync()
                listCategories = JsonConvert.DeserializeObject(Of List(Of Category))(content)
            End If

            gvCategories.DataSource = listCategories
            gvCategories.DataBind()
        End If
    End Sub

End Class