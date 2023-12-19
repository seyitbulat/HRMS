Imports System.Text
Imports DevExpress.Xpf.Core

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits ThemedWindow
    Public Sub New()
        InitializeComponent()
        'MainContentFrame.Navigate(New HomePage())
        'MainContentFrame1.Navigate(New CandidateTable())
        MainContentFrame2.Navigate(New EmployeeTable())

    End Sub
End Class