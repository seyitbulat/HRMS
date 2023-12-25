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

        Private Property _selector As Integer

        Public Property _page As IPage

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub DataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

        End Sub
        Private Sub DepartmanlarButton_Click(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            _selector = 1
            ' Öncelikle mevcut içeriği temizleyin
            MainContentPanel.Children.Clear()

            ' DepartmentPage UserControl'ünü oluşturun
            Dim departmentPage As New DepartmentPage()

            _page = departmentPage

            ' UserControl'ü ana içerik paneline ekleyin
            MainContentPanel.Children.Add(departmentPage)
        End Sub

        Private Sub BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs)
            If (_selector = 1) Then
                _page.Add()
            End If
        End Sub
    End Class
End Namespace
