Imports DevExpress.Xpf.Grid
Imports Newtonsoft.Json
Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports System.Threading.Tasks

Partial Public Class DepartmentTable
    Inherits Page

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Loaded, AddressOf Page_Loaded
    End Sub

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Dim departments As ObservableCollection(Of Department) = Await GetDepartmentsAsync()
        DepartmentGrid.ItemsSource = departments
    End Sub

    Public Async Function GetDepartmentsAsync() As Task(Of ObservableCollection(Of Department))
        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync("https://localhost:50099/Department/GetAll")
            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of ObservableCollection(Of Department))(json)
            Else
                ' Handle error situation
                Return New ObservableCollection(Of Department)()
            End If
        End Using
    End Function
End Class
