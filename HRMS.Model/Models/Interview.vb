Imports System
Imports System.Collections.Generic

Namespace Models
    Partial Public Class Interview
        Public Property Id As Long

        Public Property Interviewdate As Date

        Public Property Interviewnotes As String

        Public Property Interviewoutcome As String

        Public Property Candidateid As Long

        Public Property Interviewerid As Long

        Public Overridable Property Candidate As Candidate

        Public Overridable Property Interviewer As Employee
    End Class
End Namespace
