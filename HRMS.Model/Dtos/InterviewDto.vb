Public Class InterviewGetDto
    Public Property Interviewdate As Date

    Public Property Interviewnotes As String

    Public Property Interviewoutcome As String

End Class

Public Class InterviewPostDto
    Public Property Interviewdate As Date

    Public Property Interviewnotes As String

    Public Property Interviewoutcome As String

    Public Property Candidateid As Long

    Public Property Interviewerid As Long
End Class


Public Class InterviewPutDto
    Public Property Id As Long
    Public Property Interviewdate As Date

    Public Property Interviewnotes As String

    Public Property Interviewoutcome As String

    Public Property Candidateid As Long

    Public Property Interviewerid As Long
End Class