Public Class LeafGetDto
    Public Property Startdate As Date?

    Public Property Enddate As Date?

    Public Property Status As String


End Class


Public Class LeafPostDto
    Public Property Startdate As Date?

    Public Property Enddate As Date?

    Public Property Status As String

    Public Property Employeeid As Long?

    Public Property Leavetypeid As Long?
End Class


Public Class LeafPutDto
    Public Property Startdate As Date?

    Public Property Enddate As Date?

    Public Property Status As String

    Public Property Employeeid As Long?

    Public Property Leavetypeid As Long?
End Class