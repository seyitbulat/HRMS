Imports System
Imports System.Collections.Generic

Namespace Models
    Partial Public Class LeavesType
        Public Property Id As Long

        Public Property Typename As String

        Public Property Description As String

        Public Overridable ReadOnly Property Leaves As ICollection(Of Leaf) = New List(Of Leaf)()
    End Class
End Namespace
