Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports DevExpress.XtraRichEdit.Model
Imports DocuSign.eSign.Client
Imports DocuSign.eSign.Model

Public Class LeavePage : Implements IPage
    Private httpclient As HttpClient
    Public Property Leaveies As ObservableCollection(Of Leave)

    Public Sub New()
        InitializeComponent()
        httpclient = New HttpClient()
        httpclient.BaseAddress = New Uri("https://localhost:5030/")
        Leaveies = New ObservableCollection(Of Leave)()
        LoadLeave()
    End Sub

    Public Async Function LoadLeave() As Task
        Try
            Dim response = Await httpclient.GetAsync("Leave")
            If response.IsSuccessStatusCode Then
                Dim apiResponse = Await response.Content.ReadAsAsync(Of ApiResponse(Of Leave))()
                Leaveies = New ObservableCollection(Of Leave)(apiResponse.Data)
                leaveGridControl.ItemsSource = Leaveies
            Else
                MessageBox.Show("Bir hata oluştu: " & response.StatusCode.ToString(), "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Bir hata oluştu: " & ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

        'employee combobox
        Dim employeeResponse = Await httpclient.GetAsync("Employee/GetAll")
        If employeeResponse.IsSuccessStatusCode Then
            Dim employeeApiResponse = Await employeeResponse.Content.ReadAsAsync(Of ApiResponse(Of Employee))()

            Dim defaultEmployee As New Employee With {.Id = "-1", .Firstname = "Seçim", .Lastname = "Yapılmadı"}
            Dim employeeies = employeeApiResponse.Data.ToList()
            employeeies.Insert(0, defaultEmployee)

            employeeCombobox.DisplayMemberPath = "FullName"
            employeeCombobox.SelectedValuePath = "Id"
            employeeCombobox.ItemsSource = employeeies

            employeeCombobox.SelectedValue = "-1"
        End If

        'LeaveType combobox
        Dim leaveTypeResponse = Await httpclient.GetAsync("LeaveTypes/GetAll")
        If leaveTypeResponse.IsSuccessStatusCode Then
            Dim leaveTypeApiResponse = Await leaveTypeResponse.Content.ReadAsAsync(Of ApiResponse(Of LeaveType))()
            Dim defaultLeaveType As New LeaveType With {.Id = "-1", .Typename = "Seçim Yapılmadı"}
            Dim leaveTypeies = leaveTypeApiResponse.Data.ToList()
            leaveTypeies.Insert(0, defaultLeaveType)

            leaveTypeCombobox.DisplayMemberPath = "Typename"
            leaveTypeCombobox.SelectedValuePath = "Id"
            leaveTypeCombobox.ItemsSource = leaveTypeies

            leaveTypeCombobox.SelectedValue = "-1"
        End If

    End Function
    Public Class ApiResponse(Of T)
        Public Property Data As List(Of T)
    End Class
    Public Function Add() As Task Implements IPage.Add
        Throw New NotImplementedException()
    End Function

    Public Async Function Delete() As Task Implements IPage.Delete
        Dim selected As Leave = TryCast(leaveGridControl.SelectedItem, Leave)
        If selected Is Nothing Then
            MessageBox.Show("Lütfen silinecek bir veri seçin.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
            Return
        End If
        Dim messageBoxResult As MessageBoxResult = MessageBox.Show("Bu veriyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButton.YesNo, MessageBoxImage.Warning)
        If messageBoxResult = MessageBoxResult.Yes Then
            Try
                Dim response As HttpResponseMessage = Await httpclient.DeleteAsync($"https://localhost:5030/Leave/{selected.Id}")
                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Veri Başarıyla Silindi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information)
                    Await LoadLeave()
                Else
                    MessageBox.Show("Bir hata oluştu:" & response.StatusCode.ToString(), "Hata", MessageBoxButton.OK, MessageBoxImage.Error)

                End If
            Catch ex As Exception
                MessageBox.Show("Hata:" & ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End If
    End Function

    Public Function Update() As Task Implements IPage.Update
        Throw New NotImplementedException()
    End Function



End Class
