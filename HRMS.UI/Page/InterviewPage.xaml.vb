Imports System.Collections.ObjectModel
Imports System.Net.Http

Public Class InterviewPage : Implements IPage
    Private httpclient As HttpClient
    Public Property Interviews As ObservableCollection(Of Interview)

    Public Sub New()
        InitializeComponent()
        httpclient = New HttpClient()
        httpclient.BaseAddress = New Uri("https://localhost:5030/")
        Interviews = New ObservableCollection(Of Interview)()
        LoadInterview()
    End Sub
    Public Class ApiResponse(Of T)
        Public Property Data As List(Of T)
    End Class
    Public Async Function LoadInterview() As Task
        ' Önce aday isimlerini yükleyin
        Dim candidateNames = Await LoadCandidateNames()

        ' Sonra Interview bilgilerini yükleyin
        Dim response = Await httpclient.GetAsync("Interview/GetAll")
        If response.IsSuccessStatusCode Then
            Dim apiResponse = Await response.Content.ReadAsAsync(Of ApiResponse(Of Interview))()
            For Each interview In apiResponse.Data
                ' CandidateId kullanarak CandidateName'i atayın
                If candidateNames.ContainsKey(interview.Candidateid) Then
                    interview.CandidateName = candidateNames(interview.Candidateid)
                End If
            Next
            Interviews = New ObservableCollection(Of Interview)(apiResponse.Data)
            interviewGridControl.ItemsSource = Interviews
        End If
    End Function

    Public Async Function LoadCandidateNames() As Task(Of Dictionary(Of Long, String))
        Dim candidateNames As New Dictionary(Of Long, String)
        Dim response = Await httpclient.GetAsync("Candidate/GetAll")
        If response.IsSuccessStatusCode Then
            Dim candidates = Await response.Content.ReadAsAsync(Of ApiResponse(Of Candidate))()
            For Each candidate In candidates.Data
                candidateNames.Add(candidate.Id, candidate.Firstname & " " & candidate.Lastname)
            Next
        End If
        Return candidateNames
    End Function




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
