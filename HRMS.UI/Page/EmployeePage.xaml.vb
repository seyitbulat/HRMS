Imports DocuSign.eSign.Model
Imports Newtonsoft.Json
Imports System.Collections.ObjectModel
Imports System.Net.Http
Imports System.Text

Public Class EmployeePage : Implements IPage

    Public Async Function Add() As Task Implements IPage.Add
        Dim name = FirstName.Text
        Dim lastna = lastname.Text
        Dim birth = birthdate.SelectedDate
        Dim gend = gender.SelectedValue
        Dim hire = hiredate.Text
        Dim mail = email.Text
        Dim phone = phonenumber.Text
        Dim position = positionId.Text
        Dim department = departmenId.Text
        Dim manager = manegerId.Text
        Dim annual = annualleave.Text
        Dim active = ısactive.IsChecked.HasValue




        Dim _httpClient As New HttpClient

        Dim postObject As New With {
           Key .firstname = name,
           Key .lastname = lastna,
           Key .birthdate = birth,
           Key .gender = gend,
           Key .hiredate = hire,
           Key .email = mail,
           Key .phonenumber = phone,
           Key .positionId = position,
           Key .departmentId = department,
           Key .managerId = manager,
           Key .annualleave = annual,
           Key .ısactive = active,
           Key .operation = "ADD"
        }

        Dim jsonContent = JsonConvert.SerializeObject(postObject)
        Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")


        Dim response As HttpResponseMessage = Await _httpClient.PostAsync("https://localhost:50099/Employee/SearchByLastNameAndBirthdate", content)
        If response.StatusCode = Net.HttpStatusCode.OK Then

        Else
            MessageBox.Show("Bir hata oluştu: " & response.StatusCode.ToString(), "Hata", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Function

    Private Async Sub searchEmployeeButton_Click(sender As Object, e As RoutedEventArgs)
        Using client As New HttpClient()
            Dim response As HttpResponseMessage
            Dim selected = birthdate.SelectedDate

            If Not lastname.Text = "Soyad Giriniz:" Then
                If selected Is Nothing Then
                    selected = DateTime.MinValue
                End If

                response = Await client.GetAsync($"https://localhost:50099/Employee/SearchByLastNameAndBirthdate?lastname={lastname.Text}&birthdate={selected}")

                If response.IsSuccessStatusCode Then
                    Dim json As String = Await response.Content.ReadAsStringAsync()
                    Dim wrapper = JsonConvert.DeserializeObject(Of DataWrapper)(json)
                    employeeGrid.ItemsSource = wrapper.Data ' Bu satırı değiştirin
                Else
                    ' Hata durumunu ele alın
                    employeeGrid.ItemsSource = New ObservableCollection(Of Employee)() ' Hata durumunda boş bir koleksiyon atayın
                End If
            Else
                response = Await client.GetAsync("https://localhost:50099/Employee/GetAll")
                If response.IsSuccessStatusCode Then
                    Dim json As String = Await response.Content.ReadAsStringAsync()
                    Dim wrapper = JsonConvert.DeserializeObject(Of DataWrapper)(json)
                    employeeGrid.ItemsSource = wrapper.Data ' Bu satırı değiştirin
                Else
                    ' Hata durumunu ele alın
                    employeeGrid.ItemsSource = New ObservableCollection(Of Employee)() ' Hata durumunda boş bir koleksiyon atayın
                End If
            End If
        End Using
    End Sub

    Public Class DataWrapper
        Public Property Data As ObservableCollection(Of Employee)
    End Class


    Public Function Delete() As Task Implements IPage.Delete
        Throw New NotImplementedException()
    End Function

    Public Function Update() As Task Implements IPage.Update
        Throw New NotImplementedException()
    End Function
    Private Sub LastnameTextBox_GotFocus(sender As Object, e As RoutedEventArgs)
        If lastname.Text = "Soyad Giriniz:" Then
            lastname.Text = ""
        End If
    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub departmentName_LostFocus(sender As Object, e As RoutedEventArgs)
        If lastname.Text = "" Then
            lastname.Text = "Soyad Giriniz:"
        End If
    End Sub


End Class
