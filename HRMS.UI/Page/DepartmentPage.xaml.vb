
Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json

Partial Public Class DepartmentPage : Implements IPage

    Public Async Function Add() As Task Implements IPage.Add
        Dim name = departmentName.Text

        Dim _httpClient As New HttpClient

        Dim postObject As New With {
           Key .departmentName = name,
           Key .operation = "ADD"
        }

        Dim jsonContent = JsonConvert.SerializeObject(postObject)
        Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await _httpClient.PostAsync("https://localhost:50099/Department/ManageDepartment", content)

        If response.StatusCode = Net.HttpStatusCode.OK Then

        Else
            MessageBox.Show("Bir hata oluştu: " & response.StatusCode.ToString(), "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Function

    Private Async Sub searchButton_Click(sender As Object, e As RoutedEventArgs)
        Using client As New HttpClient()
            If Not departmentName.Text = "Departman Adı Giriniz:" Then
                Dim response As HttpResponseMessage = Await client.GetAsync($"https://localhost:50099/Department/GetByName?departmentName={departmentName.Text}")
                If response.IsSuccessStatusCode Then
                    Dim json As String = Await response.Content.ReadAsStringAsync()
                    Dim wrapper = JsonConvert.DeserializeObject(Of DataWrapper)(json)
                    departmentGrid.ItemsSource = wrapper.Data ' Bu satırı değiştirin
                Else
                    ' Hata durumunu ele alın
                    departmentGrid.ItemsSource = New ObservableCollection(Of Department)() ' Hata durumunda boş bir koleksiyon atayın
                End If
            Else
                Dim response As HttpResponseMessage = Await client.GetAsync("https://localhost:50099/Department/GetAll")
                If response.IsSuccessStatusCode Then
                    Dim json As String = Await response.Content.ReadAsStringAsync()
                    Dim wrapper = JsonConvert.DeserializeObject(Of DataWrapper)(json)
                    departmentGrid.ItemsSource = wrapper.Data ' Bu satırı değiştirin
                Else
                    ' Hata durumunu ele alın
                    departmentGrid.ItemsSource = New ObservableCollection(Of Department)() ' Hata durumunda boş bir koleksiyon atayın
                End If
            End If
        End Using
    End Sub

    Public Class DataWrapper
        Public Property Data As ObservableCollection(Of Department)
    End Class

    Private Sub departmentName_GotFocus(sender As Object, e As RoutedEventArgs)
        If departmentName.Text = "Departman Adı Giriniz:" Then
            departmentName.Text = ""
        End If
    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub departmentName_LostFocus(sender As Object, e As RoutedEventArgs)
            If departmentName.Text = "" Then
                departmentName.Text = "Departman Adı Giriniz:"
            End If
        End Sub
    End Class


