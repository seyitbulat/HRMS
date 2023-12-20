Imports System.Text
Imports DevExpress.Xpf.Core

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits ThemedWindow

    Public Sub New()
        InitializeComponent()
        ''MainContentFrame.Navigate(New HomePage())
        ''MainContentFrame1.Navigate(New CandidateTable())
        ''MainContentFrame2.Navigate(New EmployeeTable())
        'MainContentFrame3.Navigate(New DepartmentTable())

    End Sub


    Private Sub Department_Click(sender As Object, e As RoutedEventArgs)
        Dim departmentTable As New DepartmentTable()
        pageView.Content = departmentTable
    End Sub
End Class