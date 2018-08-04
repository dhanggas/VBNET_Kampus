Imports System.Data.OleDb
Partial Public Class _Default
    Inherits System.Web.UI.Page
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\ProjectVBNET\UAS\db_uas.mdb;"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim hasil, nil1 As Integer
            Dim jenis As String
            nil1 = txtPendapatan.Text
            If rdo1.Checked = True Then
                hasil = 1.4 * nil1
                jenis = "P"
            Else
                hasil = 1.2 * nil1
                jenis = "W"
            End If


            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "insert into pegawai values('" & txtNama.Text & "','" & txtSatus.Text & "','" & txtPendapatan.Text & "','" & jenis & "','" & hasil & "')"
            objCommand = New OleDbCommand(strSQL, myCon)
            If objCommand.ExecuteNonQuery() Then
                MsgBox("Data Tersimpan")
            Else
                MsgBox("Gagal Disimpan")
            End If


            myCon.Close()
            hapus()

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        hapus()
    End Sub
    Sub hapus()
        txtNama.Text = ""
        rdo1.Checked = False
        rdo2.Checked = False
    End Sub
End Class