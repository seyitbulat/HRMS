Imports System.Text
Imports DevExpress.Pdf.Native
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Core

Namespace HRMS.UI
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits ThemedWindow
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub DataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

        End Sub
        Private Sub DepartmanlarButton_Click(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ' Öncelikle mevcut içeriği temizleyin
            MainContentPanel.Children.Clear()

            ' DepartmentPage UserControl'ünü oluşturun
            Dim departmentPage As New DepartmentPage()

            ' UserControl'ü ana içerik paneline ekleyin
            MainContentPanel.Children.Add(departmentPage)
        End Sub
        Private Sub EmployeeButton_Click(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ' Öncelikle mevcut içeriği temizleyin
            MainContentPanel.Children.Clear()

            ' DepartmentPage UserControl'ünü oluşturun
            Dim employeePage As New EmployeePage()

            ' UserControl'ü ana içerik paneline ekleyin
            MainContentPanel.Children.Add(employeePage)
        End Sub
    End Class
End Namespace
