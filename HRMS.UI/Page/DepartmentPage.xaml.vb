
Imports DevExpress.Xpf.Controls.Internal

Partial Public Class DepartmentPage
    Private Sub departmanTextBox_GotFocus(sender As Object, e As RoutedEventArgs)
        If Departmentname.Text = "Departman Adı Giriniz:" Then
            Departmentname.Text = String.Empty
        End If
    End Sub

    Private Sub managerTextBox_GotFocus(sender As Object, e As RoutedEventArgs)
        If managername.Text = "Müdür Adı Giriniz:" Then
            managername.Text = String.Empty
        End If
    End Sub

End Class


