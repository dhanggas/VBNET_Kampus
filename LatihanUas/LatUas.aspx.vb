Imports System.Data.OleDb
Partial Public Class LatUas
    Inherits System.Web.UI.Page
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Project VBNET\LatihanUas\db_uas.mdb;"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
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
            strSQL = "insert into pegawai values('" & txtNama.Text & "','" & jenis & "','" & txtPendapatan.Text & "','" & hasil & "')"
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

    Protected Sub rdo1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdo1.CheckedChanged

    End Sub
    Sub hapus()
        txtNama.Text = ""
        rdo1.Checked = False
        rdo2.Checked = False
    End Sub

    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        hapus()

    End Sub
End Class