Imports System.Data.SqlClient

Module Koneksi
    Public QConnDb As String = "Data Source= . ; " _
      & " Initial Catalog=DbTokoBuku; Persist Security Info=True; User ID=sa; Password=123456"
    Public StrSQL As String
    Public kodepanggil As String
    Public namapanggil As String



    Public Function Koneksi() As SqlConnection
        Dim Conn As New SqlConnection
        Conn = New SqlConnection(QConnDb)
        Conn.Open()
        Return Conn
    End Function
End Module
