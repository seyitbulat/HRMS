Imports System.Net.Http

Public Module HttpClientFactory


    Public Function Create() As HttpClient
        Dim httpClient = New HttpClient()

        httpClient.BaseAddress = New Uri("https://localhost:50099/")

        Return httpClient
    End Function
End Module