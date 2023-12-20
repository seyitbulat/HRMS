Public Class ResponseBody(Of T)
    Public Property Data As T
    Public Property ErrorMessages As List(Of String)
    Public Property StatusCode As Integer
End Class
