Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports DocuSign.eSign.Client

Public Class CandidatePage : Implements IPage

    Private httpclient As HttpClient
    Public Property Candidates As ObservableCollection(Of Candidate)
    Public Property Positions As ObservableCollection(Of Position)
    Public Sub New()
        InitializeComponent()
        httpclient = New HttpClient()
        httpclient.BaseAddress = New Uri("https://localhost:50099/")
        Candidates = New ObservableCollection(Of Candidate)()
        Positions = New ObservableCollection(Of Position)()
        LoadCandidate()
    End Sub
    Public Class ApiResponse
        Public Property Data As List(Of Candidate)
    End Class
    Public Async Function LoadCandidate() As Task

        Dim response = Await httpclient.GetAsync("Candidate/GetAll")
        If response.IsSuccessStatusCode Then
            Dim apiResponse = Await response.Content.ReadAsAsync(Of ApiResponse)()
            Candidates = New ObservableCollection(Of Candidate)(apiResponse.Data)
            candidateGridControl.ItemsSource = Candidates
        End If
    End Function
    Public Async Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Try
            Dim comboResponse = Await httpclient.GetAsync("Position/GetAll")
            If comboResponse.IsSuccessStatusCode Then
                Dim positionsApiResponse = Await comboResponse.Content.ReadAsAsync(Of ApiResponse)()
                ' Data tipinin List(Of Position) olduğundan emin olun.
                Positions = New ObservableCollection(Of Position)(positionsApiResponse.Data)
                ' ComboBox'a Positions koleksiyonunu atayın.
                positionComboBox.ItemsSource = Positions
            Else

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub candidateFirstName_GotFocus(sender As Object, e As RoutedEventArgs)
        If firstName.Text = "Adı Giriniz..." Then
            firstName.Text = ""
        End If
    End Sub
    Private Sub candidateFirstName_LostFocus(sender As Object, e As RoutedEventArgs)
        If firstName.Text = "" Then
            firstName.Text = "Adı Giriniz..."
        End If
    End Sub

    Private Sub candidateLastName_GotFocus(sender As Object, e As RoutedEventArgs)
        If lastName.Text = "Soyad Giriniz..." Then
            lastName.Text = ""
        End If
    End Sub
    Private Sub candidateLastName_LostFocus(sender As Object, e As RoutedEventArgs)
        If lastName.Text = "" Then
            lastName.Text = "Soyad Giriniz..."
        End If
    End Sub

    Private Sub candidateResumeLink_GotFocus(sender As Object, e As RoutedEventArgs)
        If resumeLink.Text = "Özgeçmiş Bağlantısını Giriniz..." Then
            resumeLink.Text = ""
        End If
    End Sub
    Private Sub candidateResumeLink_LostFocus(sender As Object, e As RoutedEventArgs)
        If resumeLink.Text = "" Then
            resumeLink.Text = "Özgeçmiş Bağlantısını Giriniz..."
        End If
    End Sub

    Public Function Add() As Task Implements IPage.Add
        Throw New NotImplementedException()
    End Function

    Public Function Delete() As Task Implements IPage.Delete
        Throw New NotImplementedException()
    End Function

    Public Function Update() As Task Implements IPage.Update
        Throw New NotImplementedException()
    End Function
End Class
