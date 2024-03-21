Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class CategoriesService
    Implements IDisposable

    Private _httpClient As HttpClient
    Private _apiURL As String

    Public Sub New()
        _httpClient = New HttpClient
        _apiURL = ConfigurationManager.AppSettings("apiURL")
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        _httpClient.Dispose()
    End Sub

    Public Async Function GetCategories() As Task(Of List(Of Category))
        'get value from web.config with configuration manager
        Dim listCategories As List(Of Category) = New List(Of Category)

        Dim _response As HttpResponseMessage = Await _httpClient.GetAsync(_apiURL & "/Categories")
        If _response.IsSuccessStatusCode Then
            Dim content = Await _response.Content.ReadAsStringAsync()
            listCategories = JsonConvert.DeserializeObject(Of List(Of Category))(content)
        End If

        Return listCategories
    End Function

    Public Async Function AddCategory(category As Category) As Task(Of Boolean)
        Dim json = JsonConvert.SerializeObject(category)
        Dim content = New StringContent(json, System.Text.Encoding.UTF8, "application/json")
        Try
            Dim _response = Await _httpClient.PostAsync(_apiURL & "/Categories", content)
            If _response.IsSuccessStatusCode Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    'update
    Public Async Function UpdateCategory(category As Category) As Task(Of Boolean)
        Dim json = JsonConvert.SerializeObject(category)
        Dim content = New StringContent(json, System.Text.Encoding.UTF8, "application/json")
        Try
            Dim _response = Await _httpClient.PutAsync(_apiURL & "/Categories/" & category.categoryID, content)
            If _response.IsSuccessStatusCode Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    'delete
    Public Async Function DeleteCategory(categoryID As Integer) As Task(Of Boolean)
        Try
            Dim _response = Await _httpClient.DeleteAsync(_apiURL & "/Categories/" & categoryID)
            If _response.IsSuccessStatusCode Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

End Class
