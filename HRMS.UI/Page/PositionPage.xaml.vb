Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text

Public Class PositionPage : Implements IPage
    Private httpClient As HttpClient
    Public Property Positions As ObservableCollection(Of Position)


    Public Sub New()
        InitializeComponent()
        httpClient = New HttpClient()
        ' BaseAddress'i sadece bir kez burada ayarlayın
        httpClient.BaseAddress = New Uri("https://localhost:50099/")
        Positions = New ObservableCollection(Of Position)()
        LoadPositions()
    End Sub
    Public Class ApiResponse
        Public Property Data As List(Of Position)
    End Class

    Public Async Function LoadPositions() As Task
        Try
            ' httpClient.BaseAddress artık burada ayarlanmıyor
            Dim response = Await httpClient.GetAsync("Position/GetAll")
            If response.IsSuccessStatusCode Then
                Dim apiResponse = Await response.Content.ReadAsAsync(Of ApiResponse)()
                Positions = New ObservableCollection(Of Position)(apiResponse.Data)
                positionGridControl.ItemsSource = Positions
            End If
        Catch ex As Exception
            MessageBox.Show("Bir hata oluştu: " & ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Function



    Private Sub positionTitle_GotFocus(sender As Object, e As RoutedEventArgs)
        If positionTitle.Text = "Pozisyon Başlığını Giriniz..." Then
            positionTitle.Text = ""
        End If
    End Sub
    Private Sub positionTitle_LostFocus(sender As Object, e As RoutedEventArgs)
        If positionTitle.Text = "" Then
            positionTitle.Text = "Pozisyon Başlığını Giriniz..."
        End If
    End Sub
    Private Sub description_GotFocus(sender As Object, e As RoutedEventArgs)
        If description.Text = "Kaynağı Giriniz..." Then
            description.Text = ""
        End If
    End Sub
    Private Sub description_LostFocus(sender As Object, e As RoutedEventArgs)
        If description.Text = "" Then
            description.Text = "Kaynağı Giriniz..."
        End If
    End Sub
    Private Sub salaryGrade_GotFocus(sender As Object, e As RoutedEventArgs)
        If salaryGrade.Text = "Maaş Notu Giriniz..." Then
            salaryGrade.Text = ""
        End If
    End Sub
    Private Sub salaryGrade_LostFocus(sender As Object, e As RoutedEventArgs)
        If salaryGrade.Text = "" Then
            salaryGrade.Text = "Maaş Notu Giriniz..."
        End If
    End Sub

    Public Async Function Add() As Task Implements IPage.Add
        Dim title = positionTitle.Text
        Dim PositionDescription = description.Text
        Dim PositionSalaryGrade = salaryGrade.Text

        ' Mevcut httpClient nesnesini kullanın
        Dim postObject As New With {
            Key .Positiontitle = title,
            Key .Description = PositionDescription,
            Key .Salarygrade = PositionSalaryGrade,
            Key .operation = "ADD"
        }

        Dim jsonContent = JsonConvert.SerializeObject(postObject)
        Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await httpClient.PostAsync("https://localhost:50099/Position/ManagePosition", content)

        If response.IsSuccessStatusCode Then
            MessageBox.Show("Pozisyon başarıyla eklendi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information)
            ' Verileri yeniden yükleyin
            Await LoadPositions()
        Else
            MessageBox.Show("Bir hata oluştu: " & response.StatusCode.ToString(), "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Function

    Public Function Delete() As Task Implements IPage.Delete
        Throw New NotImplementedException()
    End Function
End Class

