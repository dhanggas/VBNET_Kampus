Public Class TextStyle

    Public Function Bold(ByVal text As String) As String
        'text = New Font(familyName:=<, 10, FontStyle.Bold)
        Dim txtBold As Font
        txtBold = New Font(New FontFamily("Segoe UI"), 9, FontStyle.Bold)



        Return text
    End Function
End Class
