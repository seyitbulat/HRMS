Imports System
Imports System.Collections.Generic
Imports Infrastructure

Namespace Models
    Partial Public Class User : Inherits BaseEntity(Of Long)

        Public Property Username As String

        Public Property Password As String

        Public Property Email As String

        Public Property Phone As String

    End Class
End Namespace
