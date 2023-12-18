Imports HRMS.Model.Models

Public Class LeavesTypeGetDto
    Public Property Typename As String

    Public Property Description As String

    Public Overridable ReadOnly Property Leaves As ICollection(Of Leaf) = New List(Of Leaf)()
End Class

Public Class LeavesTypePostDto
    Public Property Typename As String

    Public Property Description As String

End Class