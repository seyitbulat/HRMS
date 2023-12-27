
Imports Microsoft.AspNetCore.Http

Public Class ImageGetDto
    Public Property Id As Long
    Public Property ImagePath As String

    Public Property ImageName As String

    Public Property CreatedDate As Date
End Class

Public Class ImagePostDto
    Public Property ImagePath As String

    Public Property ImageName As String

    Public Property CreatedDate As Date
    Public Property File As IFormFile
End Class

Public Class ImagePutDto
    Public Property ImagePath As String

    Public Property ImageName As String

    Public Property CreatedDate As Date
    Public Property File As IFormFile
End Class