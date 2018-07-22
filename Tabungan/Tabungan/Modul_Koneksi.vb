Imports MySql.Data.MySqlClient
Module Modul_Koneksi
    Public Conn As MySqlConnection
    Public RD As MySqlDataReader
    Public DA As MySqlDataAdapter
    Public CMD As MySqlCommand
    Public DS As DataSet
    Public DB As MySqlCommandBuilder
    Public DT As DataTable
    Public Sub Koneksi()
        Dim SQLConn As String
        SQLConn = "server=localhost;Uid=root;Pwd=;Database=dbtabungan"
        Conn = New MySqlConnection(SQLConn)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
End Module
