Imports System.Data.OleDb

Module Module1
    Public conn As OleDbConnection
    Public cmd As OleDbCommand
    Public ds As New DataSet
    Public DA As OleDbDataAdapter
    Public RD As OleDbDataReader
    Public lokasidata As String


    Sub koneksi()
        lokasidata = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=contohDB.accdb"
        conn = New OleDbConnection(lokasidata)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub


End Module
